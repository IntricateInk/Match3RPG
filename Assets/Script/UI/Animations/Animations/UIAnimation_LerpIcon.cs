using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI.Animation
{

    public class UIAnimation_LerpIcon : UIAnimation
    {
        public UIAnimation_LerpIcon(TokenType token, float speed, IPosition p0, IPosition p1)
            : this(token.GetSpritePath(), speed, p0, p1) { }

        public UIAnimation_LerpIcon(string sprite_path, float speed, IPosition p0, IPosition p1)
        {
            this.sprite_path = sprite_path;
            this.speed = speed;
            this.p0 = p0;
            this.p1 = p1;
        }

        private readonly string sprite_path;
        private readonly float speed;
        private readonly IPosition p0;
        private readonly IPosition p1;

        private Image ui_image;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            Vector3 pos1 = p1.GetPosition(manager);
            Vector3 pos0 = p0.GetPosition(manager);

            if (ui_image == null)
            {
                GameObject obj = new GameObject();
                ui_image = obj.AddComponent<Image>();
                ui_image.sprite = Resources.Load<Sprite>(sprite_path);
                ui_image.preserveAspect = true;

                ui_image.transform.SetParent(manager.canvas);
                ui_image.GetComponent<RectTransform>().sizeDelta = manager.board.token_size;
                ui_image.transform.position = pos0;
            }

            Vector3 diff = pos1 - ui_image.transform.position;
            float v = dt * this.speed;
            
            if (diff.sqrMagnitude <= v*v)
            {
                this.isDone = true;
                GameObject.Destroy(ui_image.gameObject);
            } else
            {
                ui_image.transform.position += diff.normalized * v;
                ui_image.transform.rotation = Quaternion.FromToRotation(Vector3.right, diff);
            }
        }
    }
}