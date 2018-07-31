using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    public class UITooltipController : MonoBehaviour
    {
        internal static void Show(ITooltip tooltip, Vector3 position, Vector2 anchor)
        {
            if (OnShow != null)
                OnShow(tooltip, position, anchor);
        }

        internal static void Hide()
        {
            if (OnHide != null)
                OnHide();
        }

        public static event Action OnHide;
        public static event Action<ITooltip, Vector3, Vector2> OnShow;

        [SerializeField]
        private Image icon;

        [SerializeField]
        private Text header;

        [SerializeField]
        private Text body;

        private void Start()
        {
            this.HideTooltip();
            UITooltipController.OnShow += ShowTooltip;
            UITooltipController.OnHide += HideTooltip;
        }
        
        private void OnDestroy()
        {
            UITooltipController.OnShow -= ShowTooltip;
            UITooltipController.OnHide -= HideTooltip;
        }

        private void ShowTooltip(ITooltip tooltip, Vector3 position, Vector2 pivot)
        {
            this.gameObject.SetActive(true);
            this.header.text = tooltip.name;
            this.body.text = tooltip.tooltip;
            this.icon.sprite = tooltip.GetSprite();

            RectTransform rt = this.GetComponent<RectTransform>();
            rt.pivot = pivot;
            this.transform.position = position;
        }

        private void HideTooltip() { 
            this.gameObject.SetActive(false);
        }
        
    }
}