using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_SetEncounter : UIInstruction
    {
        public UIInstruction_SetEncounter(ITooltip tooltip)
        {
            this.tooltip = tooltip;
        }

        private readonly ITooltip tooltip;

        public void Run(UIAnimationManager manager, float dt)
        {
            manager.encounterLabel.text  = this.tooltip.name;
            manager.encounterIcon.sprite = this.tooltip.GetSprite();
        }
    }
}