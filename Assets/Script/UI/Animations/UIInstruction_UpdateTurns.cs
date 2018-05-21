using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_UpdateTurns : UIInstruction
    {
        public UIInstruction_UpdateTurns(int turns)
        {
            this.turns = turns;
        }

        private readonly int turns;

        public void Run(UIAnimationManager manager, float dt)
        {
            manager.player.TurnLabelChange(turns);
        }
    }
}
