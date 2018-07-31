using Match3.Encounter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIAnimation_DropTokens : UIAnimation
    {
        public UIAnimation_DropTokens(TokenState[,] tokens, float animation_duration = 0.4f)
        {
            this.tokens = tokens;
            this.animation_duration = animation_duration;

            this.isDone = false;
        }
        
        private readonly TokenState[,] tokens;
        private readonly float animation_duration;

        private UITokenController[,] uiTokens;
        private float t = 0f;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            float fallHeight = manager.board.GetComponent<RectTransform>().rect.size.y;

            if (t == 0f)
            {
                this.uiTokens = manager.board.CreateToken(this.tokens);
                
                foreach (UITokenController uiToken in this.uiTokens)
                {
                    if (uiToken == null) continue;

                    RectTransform rt = uiToken.GetComponent<RectTransform>();
                    rt.anchoredPosition = new Vector3(0, fallHeight);
                }
            }

            this.t += dt;

            foreach (UITokenController uiToken in this.uiTokens)
            {
                if (uiToken == null) continue;

                RectTransform rt = uiToken.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector3(0, Mathf.Lerp(fallHeight, 0, t / this.animation_duration));
            }

            if (this.t > this.animation_duration) this.isDone = true;
        }
    }
}
