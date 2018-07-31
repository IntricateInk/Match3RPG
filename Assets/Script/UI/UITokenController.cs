using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Match3.Encounter;
using System;

namespace Match3.UI
{
    [RequireComponent(typeof(Image))]
    public class UITokenController : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        [SerializeField]
        private Image focusImage;

        [SerializeField]
        private Animator animator;

        internal int uid;

        internal int x;
        internal int y;
        
        private bool _is_selected = false;
        internal bool is_selected
        {
            get { return _is_selected; }
            set
            {
                _is_selected = value;
                Recolor();
            }
        }

        internal UITileController tile { get { return this.board.tiles[x, y]; } }

        private bool is_mouse = false;

        internal UIBoardController board;

        internal void RemoveToken()
        {
            this.board.RemoveToken(this);
            this.animator.Play("Kill");
            Destroy(this.gameObject, this.animator.GetCurrentAnimatorStateInfo(0).length);
        }

        internal void SetType(TokenType type)
        {
            this.image.sprite = type.GetSprite();
        }

        internal void SetColor(Color color) { this.image.color = color; }

        public void OnButtonDown()
        {
            EncounterState.Current.SelectToken(this.x, this.y);
        }

        public void OnMouseEnter()
        {
            is_mouse = true;
            Recolor();
        }

        public void OnMouseExit()
        {
            is_mouse = false;
            Recolor();
        }

        private void Recolor()
        {
            Color color = new Color(0, 0, 0, 0);

            if (is_selected)
            {
                color = Color.yellow;
            }
            else if (is_mouse)
            {
                color = Color.grey;
            }

            this.focusImage.color = color;
        }

        internal void Highlight(bool is_highlight)
        {
            if (is_highlight)
                board.SetLayer(this.transform, 1);
            else
                board.SetLayer(this.transform, 0);
        }
    }
}