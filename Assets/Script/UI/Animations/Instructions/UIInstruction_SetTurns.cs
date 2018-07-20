using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_SetTurns : UIInstruction
    {
        public UIInstruction_SetTurns(int turns)
        {
            this.turns = turns;
        }

        private readonly int turns;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.RaiseTurnChange(turns);
        }
    }
}
