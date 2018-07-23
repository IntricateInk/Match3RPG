using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_SetTokenSelected : UIInstruction
    {
        public UIInstruction_SetTokenSelected(int x, int y, bool is_selected)
        {
            this.x = x;
            this.y = y;
            this.is_selected = is_selected;
        }

        private readonly int x;
        private readonly int y;
        private readonly bool is_selected;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.board.tiles[x, y].token.is_selected = is_selected;
        }
    }
}