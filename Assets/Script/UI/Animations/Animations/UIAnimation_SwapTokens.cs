using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIAnimation_SwapToken : UIAnimation
    {
        public UIAnimation_SwapToken(int x0, int y0, int x1, int y1, float animation_duration = 0.2f)
        {
            this.x0 = x0;
            this.y0 = y0;
            this.x1 = x1;
            this.y1 = y1;
            this.animation_duration = animation_duration;

            this.t = 0f;
            this.isDone = false;
        }

        private readonly int x0;
        private readonly int y0;
        private readonly int x1;
        private readonly int y1;
        private readonly float animation_duration;

        private float t = 0f;

        UITokenController token0;
        UITokenController token1;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            if (this.t == 0f)
            {
                this.token0 = manager.board.tokens[x0, y0];
                this.token1 = manager.board.tokens[x1, y1];
            }

            this.t += dt;

            Vector3 p0 = manager.board.GetPosition(x0, y0);
            Vector3 p1 = manager.board.GetPosition(x1, y1);

            this.token0.transform.position = Vector3.Lerp(p0, p1, t / this.animation_duration);
            this.token1.transform.position = Vector3.Lerp(p1, p0, t / this.animation_duration);

            if (this.t > this.animation_duration)
            {
                manager.board.SetPosition(token0, x1, y1);
                manager.board.SetPosition(token1, x0, y0);

                this.isDone = true;
            }
        }
    }
}