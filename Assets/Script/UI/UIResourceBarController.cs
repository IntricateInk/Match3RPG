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
        private RectTransform bar;

        [SerializeField]
        private Image icon;

        [SerializeField]
        private Text rangeLabel;

        [SerializeField]
        private Image rangeHighlight;

        private int rangeLower;
        private int rangeUpper;

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
            UIAnimationManager.OnTimeChange     += this.OnTimeChange;
            UIAnimationManager.OnTurnChange     += this.OnTurnChange;
        }

        private void OnDestroy()
        {
            UIAnimationManager.OnResourceChange -= this.OnResourceChange;
            UIAnimationManager.OnTimeChange     -= this.OnTimeChange;
            UIAnimationManager.OnTurnChange     -= this.OnTurnChange;
        }
        

        private void Flip(int amount)
        {
            int anchor1 = 0;
            int anchor2 = 0;
            int sign = 1;
            if (amount > rangeUpper)
            {
                this.amountLabel.alignment = TextAnchor.MiddleLeft;
                this.rangeLabel.alignment = TextAnchor.MiddleRight;

                anchor1 = 1;
                sign = -1;
            } else if (amount < rangeLower)
            {
                this.amountLabel.alignment = TextAnchor.MiddleRight;
                this.rangeLabel.alignment = TextAnchor.MiddleLeft;
                
                anchor2 = 1;
            } else
            {
                this.rangeHighlight.color = Color.green;
                this.rangeLabel.color = Color.green;
                this.amountLabel.color = Color.green;
                return;
            }

            this.rangeHighlight.color = Color.white;
            this.rangeLabel.color = Color.white;
            this.amountLabel.color = Color.white;

            RectTransform rt = this.amountLabel.rectTransform;
            rt.anchorMin = new Vector2(anchor1, 0);
            rt.anchorMax = new Vector2(anchor1, 1);
            rt.pivot     = new Vector2(anchor2, 0.5f);
            rt.anchoredPosition = new Vector2(sign * -5, 0);

            rt = this.icon.rectTransform;
            rt.pivot = new Vector2(anchor2, 0.5f);

            rt = this.rangeLabel.rectTransform;
            rt.anchorMin = new Vector2(anchor2, 0);
            rt.anchorMax = new Vector2(anchor2, 1);
            rt.pivot     = new Vector2(anchor1, 0.5f);
            rt.anchoredPosition = new Vector2(sign * 2, 0);
        }

        private void OnTurnChange(int amount)   { this.OnResourceChange(TokenType.TURN, amount); }
        private void OnTimeChange(float amount) { this.OnResourceChange(TokenType.TIME, (int)amount); }
        private void OnResourceChange(TokenType type, int amount)
        {
            if (type == this.field)
            {
                this.Flip(amount);

                this.amountLabel.text = amount.ToString();

                RectTransform rt = this.icon.rectTransform;
                rt.anchorMin = new Vector2((float)amount / type.MaxValue(), 0);
                rt.anchorMax = new Vector2((float)amount / type.MaxValue(), 1);
                rt.offsetMin = Vector2.zero;
                rt.offsetMax = Vector2.zero;
                rt.sizeDelta = new Vector2(20, -10);

                if (amount < rangeLower)
                {
                    this.bar.anchorMin = new Vector2((float)amount / type.MaxValue(), 0.5f);
                    this.bar.anchorMax = new Vector2((float)rangeLower / type.MaxValue(), 0.5f);
                } else
                {
                    this.bar.anchorMin = new Vector2((float)rangeUpper / type.MaxValue(), 0.5f);
                    this.bar.anchorMax = new Vector2((float)amount / type.MaxValue(), 0.5f);
                }
                this.bar.offsetMin = new Vector2(0, -2);
                this.bar.offsetMax = new Vector2(0, 2);
                
            }
        }

        internal void SetRange(int min, int max)
        {
            this.rangeLower = min;
            this.rangeUpper = max;

            this.rangeLabel.text = min.ToString() + " - " + max.ToString();

            this.rangeHighlight.rectTransform.anchorMin = new Vector2((float)min / this.field.MaxValue(), 0);
            this.rangeHighlight.rectTransform.anchorMax = new Vector2((float)max / this.field.MaxValue(), 1);
            this.rangeHighlight.rectTransform.anchoredPosition = Vector2.zero;

            this.OnResourceChange(this.field, 0);
        }
    }
}