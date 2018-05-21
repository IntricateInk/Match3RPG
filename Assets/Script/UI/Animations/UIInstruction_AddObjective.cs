using System;
using System.Collections;
using System.Collections.Generic;
using Match3.Game.Encounter;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_AddObjective : UIInstruction
    {

        public UIInstruction_AddObjective(ITooltip objective, bool isMain)
        {
            this.tooltip = objective;
            this.isMain = isMain;
        }
        
        private readonly bool isMain;
        private readonly ITooltip tooltip;

        public void Run(UIAnimationManager manager, float dt)
        {
            if (isMain)
                manager.mainObjectives.AddObjective(this.tooltip);
            else
                manager.bonusObjectives.AddObjective(this.tooltip);
        }
    }
}