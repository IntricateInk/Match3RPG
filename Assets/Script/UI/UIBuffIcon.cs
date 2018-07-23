using System;
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

        [SerializeField]
        private Text numberLabel;

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

        private List<UITokenController> tokens = new List<UITokenController>();
        private List<UITileController>  tiles  = new List<UITileController>();

        private void UpdateText()
        {
            if (tokens.Count != 0)
            {
                this.numberLabel.text = this.tokens.Count.ToString();
            } else if (tiles.Count != 0)
            {
                this.numberLabel.text = this.tiles.Count.ToString();
            } else
            {
                this.numberLabel.text = "";
            }
        }

        internal void RemoveToken(UITokenController token)
        {
            if (this.tokens.Contains(token))
            {
                this.tokens.Remove(token);
                this.UpdateText();

                if (this.tokens.Count == 0)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }

        internal void RemoveTile(UITileController tile)
        {
            if (this.tiles.Contains(tile))
            {
                this.tiles.Remove(tile);
                this.UpdateText();

                if (this.tiles.Count == 0)
                {
                    this.gameObject.SetActive(false);
                }
            }
        }

        internal void AddToken(UITokenController token)
        {
            if (!this.tokens.Contains(token))
            {
                this.tokens.Add(token);
                this.UpdateText();
                this.gameObject.SetActive(true);
            }
        }

        internal void AddTile(UITileController tile)
        {
            if (!this.tiles.Contains(tile))
            {
                this.tiles.Add(tile);
                this.UpdateText();
                this.gameObject.SetActive(true);
            }
        }

        public new void OnPointerEnter()
        {
            base.OnPointerEnter();

            foreach (UITokenController token in this.tokens)
            {
                token.Highlight(true);
            }

            foreach (UITileController tile in this.tiles)
            {
                tile.Highlight(true);
                if (tile.token != null) tile.token.Highlight(true);
            }
        }

        public new void OnPointerExit()
        {
            base.OnPointerExit();

            foreach (UITokenController token in this.tokens)
            {
                token.Highlight(false);
            }

            foreach (UITileController tile in this.tiles)
            {
                tile.Highlight(false);
                if (tile.token != null) tile.token.Highlight(false);
            }
        }
    }
}
