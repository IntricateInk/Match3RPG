using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_FloatingText : UIInstruction
    {
        public UIInstruction_FloatingText(string text, IPosition p)
        {
            this.p = p;
            this.text = text;
        }

        private readonly string text;
        private readonly IPosition p;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            UIFactory.CreateFloatingText(text, p.GetPosition(manager), manager.board);
        }
    }
}