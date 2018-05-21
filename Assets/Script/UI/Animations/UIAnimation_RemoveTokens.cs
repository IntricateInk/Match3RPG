using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIAnimation_RemoveTokens : UIAnimation
    {

        public UIAnimation_RemoveTokens(int x, int y) :
            this(new int[] { x }, new int[] { y })
        { }

        public UIAnimation_RemoveTokens(int[] x, int[] y)
        {
            this.x = x;
            this.y = y;
            this.isDone = false;
        }

        public bool isDone { get; private set; }

        private readonly int[] x;
        private readonly int[] y;

        public void Run(UIAnimationManager manager, float dt)
        {
            for (int i = 0; i < x.Length; i++)
                manager.board.RemoveToken(x[i], y[i]);

            this.isDone = true;
        }
    }
}