using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_OverlayText : UIInstruction
    {
        public UIInstruction_OverlayText(string text)
        {
            this.text = text;
        }

        private readonly string text;

        void UIInstruction.Run(UIAnimationManager manager, float dt)
        {
            manager.textOverlay.Show(text);
        }
    }
}