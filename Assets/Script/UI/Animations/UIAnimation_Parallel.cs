using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIAnimation_Parallel : UIAnimation
    {
        public UIAnimation_Parallel(params UIAnimation[] animations)
            : this(new List<UIAnimation>(animations)) { }

        public UIAnimation_Parallel(List<UIAnimation> animations)
        {
            this.animations = animations;
            this.isDone = false;
        }

        public bool isDone { get; private set; }

        private List<UIAnimation> animations = new List<UIAnimation>();

        public void Run(UIAnimationManager manager, float dt)
        {
            int i = 0;

            while (i < this.animations.Count)
            {
                this.animations[i].Run(manager, dt);

                if (this.animations[i].isDone)
                    this.animations.RemoveAt(i);
                else
                    i++;
            }

            if (this.animations.Count == 0) this.isDone = true;
        }
    }
}