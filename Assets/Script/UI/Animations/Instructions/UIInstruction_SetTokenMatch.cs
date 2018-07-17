using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_SetTokenMatch : UIInstruction
    {
        public UIInstruction_SetTokenMatch(int x, int y, bool is_match)
        {
            this.x = x;
            this.y = y;
            this.is_match = is_match;
        }

        private readonly int x;
        private readonly int y;
        private readonly bool is_match;

        public void Run(UIAnimationManager manager, float dt)
        {
            manager.board.tokens[x, y].is_match = is_match;
        }
    }
}