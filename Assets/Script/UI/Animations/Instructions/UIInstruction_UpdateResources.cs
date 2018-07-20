using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_UpdateResources : UIInstruction
    {
        public UIInstruction_UpdateResources(TokenType type, int amount)
        {
            this.type = type;
            this.amount = amount;
        }

        private readonly TokenType type;
        private readonly int amount;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.RaiseResourceChange(type, amount);
        }
    }
}
