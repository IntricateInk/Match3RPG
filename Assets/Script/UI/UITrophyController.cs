using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    internal class UITrophyController : MonoBehaviour
    {
        [SerializeField]
        private Image icon;

        [SerializeField]
        private Text label;

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
                    this.label.text  = this.tooltip.name;
                }
            }
        }

        public void OnPointerEnter()
        {
            if (this.tooltip != null) this.tooltip.Show();
        }
        
        public void OnPointerExit()
        {
            if (this.tooltip != null) this.tooltip.Show(false);
        }
    }
}