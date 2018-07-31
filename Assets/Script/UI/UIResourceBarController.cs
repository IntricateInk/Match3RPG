using Match3.UI.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Match3.UI
{
    internal class UIResourceBarController : MonoBehaviour {

        [SerializeField]
        private Text amountLabel;

        [SerializeField]
        private Image icon;

        [SerializeField]
        private RectTransform bar;

        [SerializeField]
        private Text rangeLowerLabel;

        [SerializeField]
        private RectTransform rangeLowerMarker;

        [SerializeField]
        private Text rangeUpperLabel;

        [SerializeField]
        private RectTransform rangeUpperMarker;
        
        private TokenType _field;
        internal TokenType field {
            get { return this._field; }
            set
            {
                this._field = value;

                this.icon.sprite = this.field.GetSprite();
            }
        }

        private void Awake()
        {
            UIAnimationManager.OnResourceChange += this.OnResourceChange;
            UIAnimationManager.OnTurnChange     += this.OnTurnChange;
        }

        private void OnDestroy()
        {
            UIAnimationManager.OnResourceChange -= this.OnResourceChange;
            UIAnimationManager.OnTurnChange     -= this.OnTurnChange;
        }
        
        public void OnTurnChange(int amount)   { this.OnResourceChange(TokenType.TURN, amount); }
        public void OnResourceChange(TokenType type, int amount)
        {
            if (type == this.field)
            {
                this.amountLabel.text = amount.ToString();
                
                this.bar.anchorMin = new Vector2((float)0 / type.MaxValue(), 0.35f);
                this.bar.anchorMax = new Vector2((float)amount / type.MaxValue(), 0.65f);
                this.bar.offsetMin = Vector2.zero;
                this.bar.offsetMax = Vector2.zero;
                
            }
        }

        internal void SetRange(int min, int max)
        {
            if (min == 0)
            {
                this.rangeLowerLabel.gameObject.SetActive(false);
                this.rangeLowerMarker.gameObject.SetActive(false);
            }
            else
            {
                this.rangeLowerLabel.text = min.ToString();
                this.rangeLowerMarker.anchorMin = new Vector2((float)min / this.field.MaxValue(), 0);
                this.rangeLowerMarker.anchorMax = new Vector2((float)min / this.field.MaxValue(), 1);
                this.rangeLowerMarker.anchoredPosition = Vector2.zero;
            }

            if (max == 99)
            {
                this.rangeUpperLabel.gameObject.SetActive(false);
                this.rangeUpperMarker.gameObject.SetActive(false);
            }
            else
            {
                this.rangeUpperLabel.text = max.ToString();
                this.rangeUpperMarker.anchorMin = new Vector2((float)max / this.field.MaxValue(), 0);
                this.rangeUpperMarker.anchorMax = new Vector2((float)max / this.field.MaxValue(), 1);
                this.rangeUpperMarker.anchoredPosition = Vector2.zero;
            }

            this.OnResourceChange(this.field, 0);
        }
    }
}