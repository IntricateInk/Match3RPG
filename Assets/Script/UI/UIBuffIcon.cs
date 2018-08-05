using Match3.Encounter.Effect.Passive;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    internal class UIBuffIcon : MonoBehaviour
    {
        [SerializeField]
        private Image icon;

        [SerializeField]
        private Text numberLabel;

        private TargetPassive _target_buff = null;
        internal TargetPassive target_buff
        {
            get { return this._target_buff; }
            set
            {
                this._target_buff = value;

                if (this.target_buff != null)
                {
                    this.icon.sprite = this.target_buff.GetSprite();
                }
            }
        }

        private CharacterPassive _buff;
        internal CharacterPassive buff
        {
            get { return this._buff; }
            set
            {
                this._buff = value;

                if (this.buff != null)
                {
                    this.icon.sprite = this.buff.GetSprite();
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

        public void OnPointerEnter()
        {
            foreach (UITokenController token in this.tokens)
            {
                token.Highlight(true);
            }

            foreach (UITileController tile in this.tiles)
            {
                tile.Highlight(true);
                if (tile.token != null) tile.token.Highlight(true);
            }

            RectTransform rt = this.transform.GetComponent<RectTransform>();
            Vector3 position = transform.position + new Vector3(rt.rect.xMin, rt.rect.yMax) + new Vector3(0, 0);

            if (this.buff != null)
            {
                UITooltipController.Show(this.buff, position, new Vector2(1, 1));
            } else
            {
                UITooltipController.Show(this.target_buff, position, new Vector2(1, 1));
            }
        }

        public void OnPointerExit()
        {
            foreach (UITokenController token in this.tokens)
            {
                token.Highlight(false);
            }

            foreach (UITileController tile in this.tiles)
            {
                tile.Highlight(false);
                if (tile.token != null) tile.token.Highlight(false);
            }

            UITooltipController.Hide();
        }
    }
}
