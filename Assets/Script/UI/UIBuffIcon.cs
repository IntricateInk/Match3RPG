using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    internal class UIBuffIcon : UITooltip
    {
        [SerializeField]
        private Image icon;

        private ITooltip _tooltip;
        internal override ITooltip tooltip
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
    }
}
