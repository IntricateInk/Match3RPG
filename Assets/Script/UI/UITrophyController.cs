﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    internal class UITrophyController : MonoBehaviour
    {
        [SerializeField]
        private Image icon;

        private ITooltip _tooltip;
        public ITooltip tooltip
        {
            get { return this._tooltip; }
            set
            {
                this._tooltip = value;

                if (this.tooltip != null)
                {
                    this.icon.sprite = this.tooltip.GetSprite();
                }
            }
        }

        public void OnPointerEnter()
        {
            if (this.tooltip != null)
            {
                RectTransform rt = this.transform.GetComponent<RectTransform>();
                Vector3 position = transform.position + (Vector3)rt.rect.max + new Vector3(5, 0);

                UITooltipController.Show(this.tooltip, position, new Vector2(0, 1));
            }
        }
        
        public void OnPointerExit()
        {
            UITooltipController.Hide();
        }
    }
}