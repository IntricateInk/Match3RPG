using Match3.Encounter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIAnimation_RemoveTargetAnimation : UIAnimation
    {
        public UIAnimation_RemoveTargetAnimation(string animation_name, TileState tile)
        {
            this.tile = tile;
            this.animation_name = animation_name;

            this.is_token = false;
            this.isDone = false;
        }

        public UIAnimation_RemoveTargetAnimation(string animation_name, TokenState token)
        {
            this.token = token;
            this.animation_name = animation_name;

            this.is_token = true;
            this.isDone = false;
        }

        private readonly string animation_name;
        private readonly TokenState token;
        private readonly TileState tile;
        private readonly bool is_token;

        private Animator animation = null;


        internal override void Run(UIAnimationManager manager, float dt)
        {
            Transform buff = null;

            if (is_token)
            {
                UITokenController ui_token = manager.board.GetToken(token.uid);
                if (ui_token != null)
                    buff = ui_token.transform.Find(animation_name);

            }
            else
            {
                buff = manager.board.tiles[tile.x, tile.y].transform.Find(animation_name);
            }

            if (buff != null) GameObject.Destroy(buff.gameObject);

            isDone = true;
            return;
        }
    }
}
