using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_AddSkill : UIInstruction
    {

        public UIInstruction_AddSkill(ITooltip tooltip, string resource_cost, int index)
        {
            this.tooltip = tooltip;
            this.resource_cost = resource_cost;
            this.index = index;
        }

        private readonly ITooltip tooltip;
        private readonly string resource_cost;
        private readonly int index;

        public void Run(UIAnimationManager manager, float dt)
        {
            manager.skillContainer.AddSkill(tooltip, resource_cost, index);
        }
    }
}