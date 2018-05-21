using Match3.Game.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Match3.Game
{
    internal class InputState : EncounterSubState
    {
        public int selectedSkillIndex = 0;
        public GameSkill selectedSkill { get { return this.encounter.playerState.skillList[this.selectedSkillIndex]; } }

        public InputState(EncounterState parent) : base(parent)
        {
        }

        internal readonly List<TokenState> selectedTokens = new List<TokenState>();

        internal void SelectToken(TokenState selected, bool isSelected)
        {
            if (isSelected && !this.selectedTokens.Contains(selected))
                this.selectedTokens.Add(selected);
            else if (!isSelected && this.selectedTokens.Contains(selected))
                this.selectedTokens.Remove(selected);
            
            selected.isSelected = isSelected;
        }

        internal bool InputToken(TokenState selected)
        {
            this.selectedSkill.Select(this, selected);

            return this.selectedSkill.ShouldRun(this.selectedTokens);
        }

        internal void DoSkill()
        {
            this.selectedSkill.Run(this.encounter);
        }

        internal void Reset()
        {
            foreach (TokenState token in this.selectedTokens)
            {
                token.isSelected = false;
            }

            this.selectedTokens.Clear();
        }

        internal void SetSkill(int skill_index)
        {
            this.Reset();
            this.selectedSkillIndex = skill_index;
        }
    }
}