using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_ShadeToken : UIInstruction
    {
        public UIInstruction_ShadeToken(int x, int y, Color color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        private readonly int x;
        private readonly int y;
        private readonly Color color;

        public void Run(UIAnimationManager manager, float dt)
        {
            manager.board.tokens[x, y].SetColor(color);
        }
    }
}