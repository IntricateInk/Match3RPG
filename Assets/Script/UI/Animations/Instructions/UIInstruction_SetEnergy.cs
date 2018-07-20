using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_SetEnergy : UIInstruction
    {
        public UIInstruction_SetEnergy(int energy)
        {
            this.energy = energy;
        }

        private readonly int energy;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.RaiseEnergyChange(energy);
        }
    }
}