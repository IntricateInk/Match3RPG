using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_AddSkillIcon : UIInstruction
    {

        public UIInstruction_AddSkillIcon(ITooltip tooltip, int index)
        {
            this.tooltip = tooltip;
            this.index = index;
        }

        private readonly ITooltip tooltip;
        private readonly int index;

        public void Run(UIAnimationManager manager, float dt)
        {
            manager.skillbar.AddSkill(tooltip, index);
        }
    }
}