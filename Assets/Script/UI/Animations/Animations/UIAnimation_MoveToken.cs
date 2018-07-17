using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIAnimation_MoveToken : UIAnimation
    {
        public UIAnimation_MoveToken(int x, int y, int new_x, int new_y, float animation_duration = 0.1f)
        {
            this.x = x;
            this.y = y;
            this.new_x = new_x;
            this.new_y = new_y;

            this.animation_duration = animation_duration;
        }

        public bool isDone { get; private set; }

        private readonly int new_x;
        private readonly int new_y;
        private readonly int x;
        private readonly int y;
        private readonly float animation_duration;

        private UITokenController token;
        private float t = 0f;

        public void Run(UIAnimationManager manager, float dt)
        {
            if (t == 0f)
                this.token = manager.board.tokens[this.x, this.y];

            Vector3 p0 = manager.board.GetPosition(this.x, this.y);
            Vector3 p1 = manager.board.GetPosition(this.new_x, this.new_y);
            
            this.t += dt;

            token.transform.position = Vector3.Lerp(p0, p1, t / this.animation_duration);

            if (this.t > this.animation_duration)
            {
                manager.board.SetPosition(token, this.new_x, this.new_y);
                this.isDone = true;
            }
        }
    }
}