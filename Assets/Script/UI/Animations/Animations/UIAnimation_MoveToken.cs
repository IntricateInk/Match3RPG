using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIAnimation_MoveToken : UIAnimation
    {
        public UIAnimation_MoveToken(int uid, int new_x, int new_y)
        {
            this.uid = uid;
            this.new_x = new_x;
            this.new_y = new_y;
        }

        private readonly int uid;
        private readonly int new_x;
        private readonly int new_y;

        private UITokenController token;
        private float t = 0f;

        private const float DURATION = 0.2f;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            if (t == 0f)
            {
                this.token = manager.board.GetToken(uid);
            }

            Vector3 p0 = this.token.transform.position;
            Vector3 p1 = manager.board.GetPosition(this.new_x, this.new_y);
            
            this.t += dt;

            token.transform.position = Vector3.Lerp(p0, p1, t / DURATION);

            if (this.t > DURATION)
            {
                manager.board.SetPosition(token, this.new_x, this.new_y);
                this.isDone = true;
            }
        }
    }
}