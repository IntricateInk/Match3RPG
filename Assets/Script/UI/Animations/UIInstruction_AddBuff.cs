using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_AddBuff : UIInstruction
    {
        public UIInstruction_AddBuff(ITooltip tooltip) {
            this.tooltip = tooltip;
        }

        private readonly ITooltip tooltip;

        public void Run(UIAnimationManager manager, float dt)
        {
            manager.buffContainer.AddBuff(this.tooltip);
        }
    }
}