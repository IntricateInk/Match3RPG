using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter
{
    public class BoardState : EncounterSubState
    {
        public TokenState[,] tokens;

        public int sizeX { get { return this.tokens.GetLength(0); } }
        public int sizeY { get { return this.tokens.GetLength(1); } }
        
        internal BoardState(EncounterState parent, int size_x, int size_y) : base(parent)
        {
            this.tokens = new TokenState[size_x, size_y];
            this.fillBoard();
            this.HighlightMatching();
        }

        internal void DoTurn()
        {
            this.DoTokenFall();
            
            foreach (TokenState token in this.GetMatching())
            {
                this.Remove(token);
                encounter.playerState.GainResource(token.type, 1);
            }

            this.DoTokenFall();
            this.HighlightMatching();

            this.encounter.playerState.Turn++;
        }

        private void HighlightMatching()
        {
            List<TokenState> matches = this.GetMatching();

            foreach (TokenState token in matches)
            {
                token.isMatching = true;
            }
        }

        private List<TokenState> GetMatching()
        {
            List<TokenState> tokens_matched = new List<TokenState>();

            for (int x = 0; x < this.tokens.GetLength(0); x++)
                for (int y = 0; y < this.tokens.GetLength(1); y++)
                {
                    TokenState token = this.tokens[x, y];

                    if (x >= 2 && token.type == tokens[x-1, y].type && token.type == tokens[x-2, y].type)
                    {
                        if (!tokens_matched.Contains(token)) tokens_matched.Add(token);
                        if (!tokens_matched.Contains(tokens[x-1, y])) tokens_matched.Add(tokens[x-1, y]);
                        if (!tokens_matched.Contains(tokens[x-2, y])) tokens_matched.Add(tokens[x-2, y]);
                    }

                    if (y >= 2 && token.type == tokens[x, y-1].type && token.type == tokens[x, y-2].type)
                    {
                        if (!tokens_matched.Contains(token)) tokens_matched.Add(token);
                        if (!tokens_matched.Contains(tokens[x, y-1])) tokens_matched.Add(tokens[x, y-1]);
                        if (!tokens_matched.Contains(tokens[x, y-2])) tokens_matched.Add(tokens[x, y-2]);
                    }
                }

            return tokens_matched;
        }

        internal void SwapToken(TokenState token1, TokenState token2)
        {
            UIAnimationManager.AddAnimation(new UIAnimation_SwapToken(token1.x, token1.y, token2.x, token2.y));

            int tmp_x = token1.x;
            int tmp_y = token1.y;

            this.SetPosition(token1, token2.x, token2.y, false);
            this.SetPosition(token2, tmp_x, tmp_y, false);
        }

        internal void SetPosition(TokenState token, int new_x, int new_y, bool doAnimate = true)
        {
            if (doAnimate)
                UIAnimationManager.AddAnimation(new UIAnimation_MoveToken(token.x, token.y, new_x, new_y));

            token.x = new_x;
            token.y = new_y;
            
            this.tokens[token.x, token.y] = token;
        }
        
        internal void Remove(int x, int y) { this.Remove(this.tokens[x, y]); }
        internal void Remove(TokenState token)
        {
            this.tokens[token.x, token.y] = null;

            UIAnimationManager.AddAnimation( new UIAnimation_RemoveTokens(token.x, token.y) );
        }

        private void DoTokenFall()
        {
            TokenType?[,] types = new TokenType?[this.sizeX, this.sizeY];
            List<UIAnimation> drop_animations = new List<UIAnimation>();

            for (int x = 0; x < this.sizeX; x++)
            {
                int first_empty = -1;
                
                for (int y = 0; y < this.sizeY; y++)
                {
                    if (first_empty == -1)
                    {
                        if (this.tokens[x, y] == null) first_empty = y;
                    } else
                    {
                        TokenState token = this.tokens[x, y];

                        if (token != null)
                        {
                            drop_animations.Add(new UIAnimation_MoveToken(token.x, token.y, x, first_empty));

                            this.SetPosition(token, x, first_empty, false);
                            first_empty += 1;
                        }
                    }
                }

                if (first_empty == -1) continue;

                while (first_empty < this.sizeY)
                {
                    this.tokens[x, first_empty] = new TokenState(this, this.encounter.playerState.DrawToken(), x, first_empty);
                    types[x, first_empty] = this.tokens[x, first_empty].type;
                    first_empty++;
                }
            }

            UIAnimationManager.AddAnimation(new UIAnimation_Parallel(drop_animations));
            UIAnimationManager.AddAnimation(new UIAnimation_DropTokens(types));
        }

        private void fillBoard()
        {
            TokenType?[,] types = new TokenType?[this.sizeX, this.sizeY];

            for (int x = 0; x < this.sizeX; x++)
                for (int y = 0; y < this.sizeY; y++)
                {
                    this.tokens[x, y] = new TokenState(this, this.encounter.playerState.DrawToken(), x, y);
                    types[x, y] = this.tokens[x, y].type;
                }

            UIAnimationManager.AddAnimation( new UIAnimation_DropTokens(types) );
        }

    }
}