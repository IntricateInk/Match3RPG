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

            this.DoEncounterStart();
        }

        // private

        private void DoEncounterStart ()
        {
            this.DoTurnStart();
        }

        private void DoTurnStart()
        {
            foreach (GamePassive passive in playerState.Passives)
            {
                passive.OnTurnStart(this);
            }
        }

        private void DoTurn()
        {
            this.inputState.DoSkill();

            this.boardState.DoTurn();

            this.encounterSheet.CheckBonusObjectives(this);

            if (this.encounterSheet.MainObjectiveMet(this))
            {
                this.DoEncounterEnd();
            } else
            {
                this.inputState.Reset();
            }

            this.DoTurnStart();
        }

        private void DoEncounterEnd()
        {
            UIAnimationManager.ClearAnimation();
            OverworldState.Current.GoToOverworld();
        }

        // public to UI classes

        public void TimeTick(float deltaTime)
        {
            this.playerState.Time += deltaTime;
        }

        public void SelectToken(int x, int y)
        {
            if (this.inputState.InputToken(this.boardState.tokens[x, y]))
            {
                this.DoTurn();
            }
        }

        public void SelectSkill(int skill_index)
        {
            this.inputState.SetSkill(skill_index);
        }
    }
}
