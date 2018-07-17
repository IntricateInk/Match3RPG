using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIAnimation_RemoveTokens : UIAnimation
    {

        public UIAnimation_RemoveTokens(int x, int y, float wait_time = 0.6f) :
            this(new int[] { x }, new int[] { y }, wait_time)
        { }

        public UIAnimation_RemoveTokens(int[] x, int[] y, float wait_time = 0.6f)
        {
            this.x = x;
            this.y = y;
            this.wait_time = wait_time;
            this.isDone = false;
        }

        public bool isDone { get; private set; }

        private readonly int[] x;
        private readonly int[] y;
        private readonly float wait_time;

        private float t = 0;

        public void Run(UIAnimationManager manager, float dt)
        {
            if (t == 0)
            {
                for (int i = 0; i < x.Length; i++)
                    manager.board.tokens[x[i], y[i]].RemoveToken();
            }

            t += dt;

            if (t > wait_time)
            {
                isDone = true;
            }
        }
    }
}