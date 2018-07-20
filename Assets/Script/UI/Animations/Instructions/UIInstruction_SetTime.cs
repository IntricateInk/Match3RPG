using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.UI.Animation
{
    public class UIInstruction_SetTime : UIInstruction
    {
        public UIInstruction_SetTime(float time)
        {
            this.time = time;
        }

        private readonly float time;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.RaiseTimeChange(time);
        }
    }
}
