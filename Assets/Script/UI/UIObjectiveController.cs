using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    public class UIObjectiveController : MonoBehaviour
    {
        [SerializeField]
        private Text label;

        [SerializeField]
        private Image image;

        private ITooltip _tooltip;
        internal ITooltip tooltip
        {
            get { return this._tooltip; }
            set
            {
                this._tooltip = value;

                if (this.tooltip != null)
                {
                    this.label.text = this.tooltip.name;
                    this.image.sprite = Resources.Load<Sprite>(this.tooltip.sprite); 
                }
            }
        }
    }
}