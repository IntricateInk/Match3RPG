using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    public class UITooltipController : MonoBehaviour
    {

        private static ITooltip _Current = null;
        public static ITooltip Current
        {
            get { return _Current; }
            set
            {
                _Current = value;

                if (OnTooltipChange != null) OnTooltipChange();
            }
        }

        public static event Action OnTooltipChange;

        [SerializeField]
        private Image icon;

        [SerializeField]
        private Text header;

        [SerializeField]
        private Text body;

        private void Start()
        {
            this.Redraw();
            UITooltipController.OnTooltipChange += Redraw;
        }

        private void Redraw()
        {
            if (UITooltipController.Current == null)
            {
                this.gameObject.SetActive(false);
            } else
            {
                this.gameObject.SetActive(true);
                this.header.text = UITooltipController.Current.name;
                this.body.text   = UITooltipController.Current.tooltip;
                this.icon.sprite = UITooltipController.Current.GetSprite();
            }
        }
    }
}