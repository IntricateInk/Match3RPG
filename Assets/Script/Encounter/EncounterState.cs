using Match3.Character;
using Match3.Encounter.Encounter;
using Match3.Encounter.Passive;
using Match3.Encounter.Skill;
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
        protected EncounterState encounter { get; private set; }

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

            this.playerState = new PlayerState(this);
            this.boardState  = new BoardState(this, 8, 8);
            this.inputState  = new InputState(this);

            for (int i = 0; i < this.playerState.Skills.Count; i++)
            {
                GameSkill skill = this.playerState.Skills[i];
                UIAnimationManager.AddAnimation(new UIInstruction_AddSkillIcon(skill, i));
            }
            
            foreach (EncounterObjective objective in this.encounterSheet.mainObjectives)
            {
                UIAnimationManager.AddAnimation(new UIInstruction_AddObjective(objective, true));
            }

            foreach (EncounterObjective objective in this.encounterSheet.bonusObjectives)
            {
                UIAnimationManager.AddAnimation(new UIInstruction_AddObjective(objective, false));
            }

            UIAnimationManager.AddAnimation(new UIInstruction_SetPlayer(this.playerSheet));
            UIAnimationManager.AddAnimation(new UIInstruction_SetEncounter(this.encounterSheet));
        }

        // private

        private void DoTurn()
        {
            this.inputState.DoSkill();

            this.boardState.DoTurn();

            this.encounterSheet.CheckBonusObjectives();

            if (this.encounterSheet.MainObjectiveMet(this))
            {
                Debug.Log("Won");
            } else
            {
                this.inputState.Reset();
            }

            foreach (GamePassive passive in playerState.Passives)
            {
                if (passive is IPassive_OnTurnStart)
                    ((IPassive_OnTurnStart)passive).OnTurnStart(this);
            }
        }

        // public to UI classes


        public void TimeTick(float deltaTime)
        {
            this.playerState.Time += deltaTime;
        }

        public void SelectToken(int x, int y)
        {
            if (this.inputState.InputToken(this.boardState.tokens[x, y]))
                this.DoTurn();
        }

        public void SelectSkill(int skill_index)
        {
            this.inputState.SetSkill(skill_index);
        }
    }
}
