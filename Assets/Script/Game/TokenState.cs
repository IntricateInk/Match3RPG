using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Game
{
    public class TokenState
    {
        private bool _isSelected = false;
        private bool _isMatching = false;

        public readonly BoardState board;
        public readonly TokenType type;

        public int x { get; internal set; }
        public int y { get; internal set; }
        public bool isSelected
        {
            get { return this._isSelected; }
            set
            {
                this._isSelected = value;
                this.Recolor();
            }
        }
        public bool isMatching
        {
            get { return this._isMatching; }
            set {
                this._isMatching = value;
                this.Recolor();
            }
        }

        // constructor

        internal TokenState(BoardState board, TokenType type, int x, int y)
        {
            this.x = x;
            this.y = y;

            this.type = type;
            this.board = board;
        }

        private void Recolor()
        {
            Color color = Color.white;
            bool isQueued = true;

            if (this.isSelected)
            {
                color = Color.yellow;
                isQueued = false;
            }
            else if (this.isMatching)
            {
                color = Color.green;
            }

            UIAnimationManager.AddAnimation(new UIInstruction_ShadeToken(x, y, color), isQueued);
        }
    }
}