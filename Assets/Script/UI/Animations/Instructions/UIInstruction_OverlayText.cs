using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_OverlayText : UIInstruction
    {

        public UIInstruction_OverlayText(string text, bool pause_until_click = false)
            : this("", "", text, pause_until_click) { }

        public UIInstruction_OverlayText(string title, string sprite, string text, bool pause_until_click = false)
        {
            this.title = title;
            this.sprite = sprite;
            this.text = text;
            this.pause_until_click = pause_until_click;
        }

        private readonly string title;
        private readonly string sprite;
        private readonly string text;
        private readonly bool pause_until_click;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.textOverlay.Show(title, sprite, text, pause_until_click);
        }
    }
}