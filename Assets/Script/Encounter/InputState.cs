using Match3.Encounter.Effect.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Match3.UI.Animation;

namespace Match3.Encounter
{
    internal class InputState : EncounterSubState
    {
        private int _selectedSkillIndex = -1;
        public int selectedSkillIndex
        {
            get { return _selectedSkillIndex; }
            set
            {
                _selectedSkillIndex = value;
                UIAnimationManager.AddAnimation(new UIInstruction_SelectSkill(selectedSkillIndex));
            }
        }
        public GameSkill selectedSkill { get { return this.encounter.playerState.Skills[this.selectedSkillIndex]; } }

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
            if (this.selectedSkillIndex == -1)
            {
                UIAnimationManager.AddAnimation(new UIInstruction_OverlayText("Select a skill first!"));
                return false;
            }

            this.selectedSkill.Select(this, selected);

            return this.selectedSkill.ShouldRun(this.selectedTokens);
        }

        internal void DoSkill()
        {
            foreach (TokenState token in this.selectedTokens)
            {
                token.isSelected = false;
            }
            this.selectedSkill.Run(this.encounter);
            this.selectedTokens.Clear();

            if (!this.selectedSkill.CanPayCost(this.encounter))
            {
                this.selectedSkillIndex = -1;
            }
        }
        
        internal void SetSkill(int skill_index)
        {
            if (this.encounter.playerState.Skills[skill_index].CanPayCost(this.encounter))
            {
                foreach (TokenState token in this.selectedTokens)
                {
                    token.isSelected = false;
                }

                this.selectedTokens.Clear();
                this.selectedSkillIndex = skill_index;
            } else
            {
                UIAnimationManager.AddAnimation(new UIInstruction_OverlayText("Need more Resources to use that skill."));
            }
        }
    }
}