using System;
using System.Collections;
using System.Collections.Generic;
using Match3.Encounter.Effect.Passive;
using UnityEngine;
using Match3.Encounter;

namespace Match3.UI.Animation
{
    public class UIAnimation_LineAnimation : UIAnimation
    {
        public UIAnimation_LineAnimation(string animation_name, TokenState target1, TokenState target2)
            : this(animation_name, new UITokenPosition(target1.x, target1.y), new UITokenPosition(target2.x, target2.y)) { }

        public UIAnimation_LineAnimation(string animation_name, CharacterPassive target1, TokenState target2)
            : this(animation_name, new UIBuffPosition(target1), new UITokenPosition(target2.x, target2.y)) { }

        public UIAnimation_LineAnimation(string animation_name, TokenState target1, CharacterPassive target2)
            : this(animation_name, new UITokenPosition(target1.x, target1.y), new UIBuffPosition(target2)) { }

        public UIAnimation_LineAnimation(string animation_name, IPosition start_pos, IPosition end_pos)
        {
            this.start_pos = start_pos;
            this.end_pos = end_pos;
            this.animation_name = animation_name;

            this.isDone = false;
        }
        
        private readonly IPosition start_pos;
        private readonly IPosition end_pos;
        private readonly string animation_name;

        private Animator animation = null;
        private TokenType type;
        private CharacterPassive target1;
        private TokenType target2;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            if (animation == null)
            {
                string path = "animations/" + animation_name + "/prefab";
                Animator prefab = Resources.Load<Animator>(path);
                animation = GameObject.Instantiate<Animator>(prefab, manager.canvas);

                RectTransform rt = animation.GetComponent<RectTransform>();

                Vector3 p_start = start_pos.GetPosition(manager);
                Vector3 p_end = end_pos.GetPosition(manager);

                rt.PositionFrom(p_start, p_end);
            }

            if (animation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            {
                isDone = true;
                GameObject.Destroy(animation.gameObject);
            }
        }
        
    }
}
