using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter
{
    public class TokenState
    {
        private bool _isSelected = false;
        private bool _isMatching = false;

        public readonly BoardState board;

        private TokenType _type = TokenType.NULL;
        public TokenType type
        {
            get { return _type; }
            set
            {
                if (type != value)
                {
                    _type = value;
                }
            }
        }

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

        // Game Methods
        
        internal TokenState GetAdjacent(int dx, int dy)
        {
            int x = this.x + dx;
            int y = this.y + dy;

            if (x < 0 || y < 0) return null;
            if (x >= board.sizeX || y >= board.sizeY) return null;

            return board.tokens[x, y];
        }
        
        internal void Swap(TokenState other)
        {
            UIAnimationManager.AddAnimation(new UIAnimation_SwapToken(this.x, this.y, other.x, other.y));

            int this_x = this.x;
            int this_y = this.y;

            this.SetPosition(other.x, other.y, false);
            other.SetPosition(this_x, this_y, false);
        }

        internal void SetPosition(int new_x, int new_y, bool doAnimate = true)
        {
            if (doAnimate)
                UIAnimationManager.AddAnimation(new UIAnimation_MoveToken(this.x, this.y, new_x, new_y));
            
            this.x = new_x;
            this.y = new_y;

            board.tokens[this.x, this.y] = this;
        }
        
        internal void Destroy()
        {
            board.tokens[this.x, this.y] = null;

            UIAnimationManager.AddAnimation(new UIAnimation_RemoveTokens(this.x, this.y));
        }

        // Private UI methods

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