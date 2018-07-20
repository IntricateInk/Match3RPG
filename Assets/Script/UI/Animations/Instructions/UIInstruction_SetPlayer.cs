using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_SetPlayer : UIInstruction
    {
        public UIInstruction_SetPlayer(ITooltip tooltip)
        {
            this.tooltip = tooltip;
        }

        private readonly ITooltip tooltip;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.player.SetTooltip(this.tooltip);
        }
    }
}