using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIAnimation_RemoveToken : UIAnimation
    {

        public UIAnimation_RemoveToken(int x, int y, float wait_time = 0.2f)
        {
            this.x = x;
            this.y = y;
            this.wait_time = wait_time;
            this.isDone = false;
        }

        private readonly int x;
        private readonly int y;
        private readonly float wait_time;

        private float t = 0;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            if (t == 0)
            {
                manager.board.tokens[x, y].RemoveToken();
            }

            t += dt;

            if (t > wait_time)
            {
                isDone = true;
            }
        }
    }
}