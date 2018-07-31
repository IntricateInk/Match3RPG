using Match3.Character;
using Match3.Encounter.Encounter;
using Match3.Encounter.Effect.Passive;
using Match3.Encounter.Effect.Skill;
using Match3.Overworld;
using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Match3.Encounter
{
    public abstract class EncounterSubState
    {
        internal EncounterState encounter { get; private set; }

        public EncounterSubState(EncounterState parent)
        {
            this.encounter = parent;
        }
    }

    public class EncounterState
    {
        
        public static EncounterState Current { get; private set; }
        
        public PlayerSheet playerSheet { get; private set; }
        public EncounterSheet encounterSheet { get; private set; }
        
        // sub states

        internal PlayerState playerState { get; private set; }
        internal BoardState boardState { get; private set; }
        internal InputState inputState { get; private set; }

        // constructor

        public static void NewEncounter(EncounterSheet encounterSheet)
        {
            EncounterState.Current = new EncounterState(OverworldState.Current.player, encounterSheet);
            SceneManager.LoadScene("encounter");
        }

        private EncounterState
            (PlayerSheet playerSheet, EncounterSheet encounterSheet)
        {
            this.encounterSheet = encounterSheet;
            this.playerSheet = playerSheet;

            this.inputState = new InputState(this);
            this.boardState  = new BoardState(this, 8, 8);
            this.playerState = new PlayerState(this);

            this.playerState.Initialize();
            
            this.DoEncounterStart();
        }
        
        // private

        private void DoEncounterStart ()
        {
            this.DoTurnStart();

            foreach (EncounterObjective objective in this.encounterSheet.objectives)
            {
                UIAnimationManager.AddInstruction(new UIInstruction_AddObjective(objective));
            }

            UIAnimationManager.AddInstruction(new UIInstruction_SetPlayer(this.playerSheet));
            UIAnimationManager.AddInstruction(new UIInstruction_SetEncounter(this.encounterSheet));

            UIAnimationManager.AddAnimation(new UIInstruction_OverlayText(this.encounterSheet.name, this.encounterSheet.sprite, this.encounterSheet.tooltip, true));

        }

        private void DoTurnStart()
        {
            this.playerState.Energy = this.playerState.MaximumEnergy;

            foreach (CharacterPassive passive in playerState.Passives)
            {
                passive.OnTurnStart(this, new List<TokenState>());
            }

            foreach (TileState tile in this.boardState.tiles)
            {
                List<TokenState> target = new List<TokenState>();
                target.Add(tile.token);

                foreach (TargetPassive passive in tile.Passives.ToArray())
                {
                    passive.OnTurnStart(this, target);
                }

                foreach (TargetPassive passive in tile.token.Passives.ToArray())
                {
                    passive.OnTurnStart(this, target);
                }
            }
            this.boardState.DoTokenFall();

            this.inputState.CheckIfCanPaySkill();

            UIAnimationManager.AddAnimation(new UIAnimation_ToggleInputMode(false));
        }

        private void DoTurnEnd()
        {
            UIAnimationManager.AddAnimation(new UIAnimation_ToggleInputMode(true));

            this.boardState.DoTokenFall();
            this.boardState.DoTurnEnd();

            foreach (CharacterPassive passive in playerState.Passives.ToArray())
            {
                passive.OnTurnEnd(this, new List<TokenState>());
            }

            List<TokenState> tokens = new List<TokenState>();
            List<TargetPassive> passives = new List<TargetPassive>();

            foreach (TileState tile in this.boardState.tiles)
            {
                List<TokenState> target = new List<TokenState>();
                target.Add(tile.token);

                foreach (TargetPassive passive in tile.Passives)
                {
                    tokens.Add(tile.token);
                    passives.Add(passive);
                }

                if (tile.token != null)
                {
                    foreach (TargetPassive passive in tile.token.Passives)
                    {
                        tokens.Add(tile.token);
                        passives.Add(passive);
                    }
                }
            }

            for (int i = 0; i < tokens.Count; i++)
            {
                TokenState token = tokens[i];
                TargetPassive passive = passives[i];

                passive.OnTurnEnd(this, new List<TokenState>() { token });
            }

            this.boardState.DoTokenFall();

            if (this.encounterSheet.MainObjectiveMet(this))
            {
                this.DoEncounterEnd();
                return;
            }

            this.DoTurnStart();
            this.boardState.DoTokenFall();
        }

        private void DoSkill()
        {
            this.inputState.DoSkill();
            this.boardState.DoTokenFall();
            this.inputState.CheckIfCanPaySkill();
        }

        private void DoEncounterEnd()
        {
            this.inputState.IsBlockInput = true;
            
            List<EncounterObjective> completed = new List<EncounterObjective>();

            completed.Add(encounterSheet.GetMainObjective(this.playerState));

            foreach (EncounterObjective obj in encounterSheet.objectives)
            {
                if (obj.isCompleted(playerState) && obj.type == EncounterObjective.Type.BONUS)
                    completed.Add(obj);
            }
            
            UIAnimationManager.AddAnimation(new UIInstruction_ShowEncounterSummary(completed));
        }

        // public to UI classes

        internal void BlockInput(bool is_block)
        {
            this.inputState.IsBlockInput = is_block;
        }
 
        internal void ReturnToOverworld()
        {
            OverworldState.Current.GoToOverworld();
        }

        public void TimeTick(float deltaTime)
        {
            this.playerState.Time += deltaTime;
        }

        public void SelectToken(int x, int y)
        {
            if (this.inputState.InputToken(this.boardState.tiles[x, y].token))
            {
                this.DoSkill();
            }
        }

        public void SelectSkill(int skill_index)
        {
            if (this.inputState.SetSkill(skill_index))
            {
                this.DoSkill();
            }
        }

        internal void EndTurn()
        {
            if (!this.inputState.IsBlockInput)
            {
                this.DoTurnEnd();
            }
        }

    }
}
