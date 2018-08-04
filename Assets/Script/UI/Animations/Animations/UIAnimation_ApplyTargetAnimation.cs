using Match3.Encounter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIAnimation_ApplyTargetAnimation : UIAnimation
    {
        public UIAnimation_ApplyTargetAnimation(string animation_name, TileState tile, float normalized_size = 1f)
        {
            this.tile = tile;
            this.normalized_size = normalized_size;
            this.animation_name = animation_name;

            this.is_token = false;
            this.isDone = false;
        }

        public UIAnimation_ApplyTargetAnimation(string animation_name, TokenState token, float normalized_size = 1f)
        {
            this.token = token;
            this.normalized_size = normalized_size;
            this.animation_name = animation_name;

            this.is_token = true;
            this.isDone = false;
        }
        
        private readonly string animation_name;
        private readonly TokenState token;
        private readonly TileState tile;
        private readonly float normalized_size;
        private readonly bool is_token;
        
        internal override void Run(UIAnimationManager manager, float dt)
        {
            string path = "animations/" + animation_name + "/prefab";
            Animator prefab = Resources.Load<Animator>(path);

            Transform parent;

            if (this.is_token)
            {
                UITokenController uiToken = manager.board.GetToken(token.uid);
                if (uiToken == null)
                {
                    isDone = true;
                    return;
                }
                parent = manager.board.GetToken(token.uid).transform;
            }
            else
                parent = manager.board.tiles[tile.x, tile.y].transform;

            Animator animation = GameObject.Instantiate<Animator>(prefab, parent);

            RectTransform rt = animation.GetComponent<RectTransform>();

            rt.sizeDelta = this.normalized_size * manager.board.token_size;

            animation.name = animation_name;
            isDone = true;
        }
    }
}
