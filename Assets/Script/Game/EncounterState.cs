using Match3.Character;
using Match3.Game.Encounter;
using Match3.Game.Skill;
using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Match3.Game
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

        public PlayerSheet characterSheet { get; private set; }
        public EncounterSheet encounterSheet { get; private set; }
        
        // sub states

        internal PlayerState playerState { get; private set; }
        internal BoardState boardState { get; private set; }
        internal InputState inputState { get; private set; }

        // constructor

        public static void NewEncounter
            ( PlayerSheet characterSheet, EncounterSheet encounterSheet )
        {
            EncounterState.Current = new EncounterState(characterSheet, encounterSheet);
            
            SceneManager.LoadScene("encounter");
        }

        private EncounterState
            (PlayerSheet characterSheet, EncounterSheet encounterSheet)
        {
            this.encounterSheet = encounterSheet;
            this.characterSheet = characterSheet;

            this.playerState = new PlayerState(this);
            this.boardState  = new BoardState(this, 8, 8);
            this.inputState  = new InputState(this);

            for (int i = 0; i < this.playerState.skillList.Count; i++)
            {
                GameSkill skill = this.playerState.skillList[i];
                UIAnimationManager.AddAnimation(new UIInstruction_AddSkillIcon(skill, i));
            }

            foreach (TrophySheet trophy in this.characterSheet.trophies)
            {
                //UIAnimationManager.AddAnimation(new UIInstruction_AddTrophy(trophy));
            }

            foreach (EncounterObjective objective in this.encounterSheet.mainObjectives)
            {
                UIAnimationManager.AddAnimation(new UIInstruction_AddObjective(objective, true));
            }

            foreach (EncounterObjective objective in this.encounterSheet.bonusObjectives)
            {
                UIAnimationManager.AddAnimation(new UIInstruction_AddObjective(objective, false));
            }
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
        }

        // public to UI classes

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
