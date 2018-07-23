using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_FloatingText : UIInstruction
    {
        public UIInstruction_FloatingText(string text, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.text = text;
        }

        private readonly string text;
        private readonly int x, y;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            UIFactory.CreateFloatingText(text, manager.board.GetPosition(x, y), manager.board);
        }
    }
}