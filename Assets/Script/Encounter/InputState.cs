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
                UIAnimationManager.AddInstruction(new UIInstruction_SelectSkill(selectedSkillIndex));
            }
        }

        public GameSkill selectedSkill { get { return this.encounter.playerState.Skills[this.selectedSkillIndex]; } }

        internal bool IsBlockInput = false;

        public InputState(EncounterState parent) : base(parent)
        {
        }

        internal readonly List<TokenState> selectedTokens = new List<TokenState>();

        internal void SelectToken(TokenState selected, bool isSelected)
        {
            if (IsBlockInput) return;

            if (isSelected && !this.selectedTokens.Contains(selected))
                this.selectedTokens.Add(selected);
            else if (!isSelected && this.selectedTokens.Contains(selected))
                this.selectedTokens.Remove(selected);

            selected.isSelected = isSelected;
        }

        internal bool InputToken(TokenState selected)
        {
            if (IsBlockInput) return false;

            if (this.selectedSkillIndex == -1)
            {
                UIAnimationManager.AddInstruction(new UIInstruction_OverlayText("Select a skill first!"));
                return false;
            }

            this.selectedSkill.Select(this, selected);

            return this.selectedSkill.ShouldRun(this.selectedTokens);
        }

        internal void CheckIfCanPaySkill()
        {
            if (selectedSkillIndex == -1) return;

            if (!this.selectedSkill.CanPayCost(this.encounter))
            {
                this.selectedSkillIndex = -1;
            }
        }

        internal void DoSkill()
        {
            if (IsBlockInput) return;

            foreach (TokenState token in this.selectedTokens)
            {
                token.isSelected = false;
            }
            this.selectedSkill.Run(this.encounter);
            this.selectedTokens.Clear();
        }
        
        internal bool SetSkill(int skill_index)
        {
            if (IsBlockInput) return false;
            if (skill_index >= this.encounter.playerState.Skills.Count) return false;


            if (this.encounter.playerState.Skills[skill_index].CanPayCost(this.encounter))
            {
                foreach (TokenState token in this.selectedTokens)
                {
                    token.isSelected = false;
                }

                this.selectedTokens.Clear();
                this.selectedSkillIndex = skill_index;

                return this.selectedSkill.ShouldRun(this.selectedTokens);
            } else
            {
                UIAnimationManager.AddInstruction(new UIInstruction_OverlayText("Need more energy to use that skill."));

                return false;
            }
        }
    }
}