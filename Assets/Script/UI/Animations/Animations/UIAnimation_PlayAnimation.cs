using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIAnimation_AddAnimation : UIAnimation
    {
        public UIAnimation_AddAnimation(string animation_name, IPosition position, float normalized_size = 1f)
        {
            this.position = position;
            this.normalized_size = normalized_size;
            this.animation_name = animation_name;

            this.isDone = false;
        }

        private readonly string animation_name;
        private readonly IPosition position;
        private readonly float normalized_size;

        private Animator animation = null;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            if (animation == null)
            {
                string path = "animations/" + animation_name + "/prefab";
                Animator prefab = Resources.Load<Animator>(path);
                animation = GameObject.Instantiate<Animator>(prefab, manager.canvas);

                RectTransform rt = animation.GetComponent<RectTransform>();

                rt.sizeDelta = this.normalized_size * manager.board.token_size;
                animation.transform.position = position.GetPosition(manager);
            }

            if (animation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            {
                isDone = true;
                GameObject.Destroy(animation.gameObject);
            }
        }
    }
}