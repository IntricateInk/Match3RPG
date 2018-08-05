using Match3.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.Overworld
{
    public class SkillController : MonoBehaviour
    {
        [SerializeField]
        private Image icon;

        private ITooltip _tooltip;
        public ITooltip tooltip
        {
            get { return _tooltip; }
            set
            {
                _tooltip = value;

                if (_tooltip != null)
                {
                    this.icon.sprite = this.tooltip.GetSprite();
                }
            }
        }


        public void OnPointerEnter()
        {
            RectTransform rt = this.GetComponent<RectTransform>();
            Vector3 show_pos = this.transform.position + (Vector3)rt.rect.max;
            UITooltipController.Show(tooltip, show_pos, new Vector2(0, 1));
        }

        public void OnPointerExit()
        {
            UITooltipController.Hide();
        }
    }
}