using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIAnimation_AddAnimation : UIAnimation
    {
        public enum AnimationType {
            None,
            Token_Add,
            Token_Remove,
            Tile_Add,
            Tile_Remove
        }

        public UIAnimation_AddAnimation(string animation_name, int x, int y, AnimationType anim_type, float normalized_size = 1f)
        {
            this.x = x;
            this.y = y;
            this.normalized_size = normalized_size;
            this.animation_name = animation_name;
            this.anim_type = anim_type;

            this.isDone = false;
        }

        private readonly string animation_name;
        private readonly int x;
        private readonly int y;
        private readonly float normalized_size;
        private readonly AnimationType anim_type;

        private Animator animation = null;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            if (animation == null)
            {
                UITileController tile = manager.board.tiles[x, y];

                switch (anim_type)
                {
                    case AnimationType.Tile_Remove:
                    case AnimationType.Token_Remove:
                        Transform buff = null;

                        if (anim_type == AnimationType.Tile_Remove) 
                            buff = tile.transform.Find(animation_name);
                        else if (anim_type == AnimationType.Token_Remove)
                            buff = tile.token.transform.Find(animation_name);

                        if (buff != null)
                            GameObject.Destroy(buff.gameObject);

                        isDone = true;
                        return;

                    case AnimationType.None:
                    case AnimationType.Token_Add:
                    case AnimationType.Tile_Add:

                        string path = "animations/" + animation_name + "/prefab";
                        Animator prefab = Resources.Load<Animator>(path);
                        animation = GameObject.Instantiate<Animator>(prefab, manager.canvas);

                        RectTransform rt = animation.GetComponent<RectTransform>();

                        rt.sizeDelta = this.normalized_size * manager.board.token_size;
                        animation.transform.position = manager.board.GetPosition(x, y);

                        if (anim_type == AnimationType.Token_Add || anim_type == AnimationType.Tile_Add)
                        {
                            if (anim_type == AnimationType.Token_Add)
                                animation.transform.SetParent(tile.token.transform);
                            else if (anim_type == AnimationType.Tile_Add)
                                animation.transform.SetParent(tile.transform);

                            animation.name = animation_name;
                            isDone = true;
                            return;
                        }
                        break;
                }
            }

            if (animation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            {
                isDone = true;
                GameObject.Destroy(animation.gameObject);
            }
        }
    }
}