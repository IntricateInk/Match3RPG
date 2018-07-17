using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter
{
    public class BoardState : EncounterSubState
    {
        public TileState[,] tiles;
        
        public int sizeX { get { return this.tiles.GetLength(0); } }
        public int sizeY { get { return this.tiles.GetLength(1); } }
        
        internal BoardState(EncounterState parent, int size_x, int size_y) : base(parent)
        {
            this.tiles = new TileState[size_x, size_y];

            for (int x = 0; x < size_x; x++)
            {
                for (int y = 0; y < size_y; y++)
                {
                    this.tiles[x, y] = new TileState(this, x, y);
                }
            }

            this.fillBoard();
            this.HighlightMatching();
        }

        internal void DoTurn()
        {
            this.DoTokenFall();

            UIAnimationManager.AddAnimation(new UIAnimation_BeginBatch());
            foreach (TokenState token in this.GetMatching())
            {
                token.Match();
            }
            UIAnimationManager.AddAnimation(new UIAnimation_EndBatch());

            this.DoTokenFall();

            this.encounter.playerState.Turn++;
        }

        internal void HighlightMatching()
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

            for (int x = 0; x < this.sizeX; x++)
                for (int y = 0; y < this.sizeY; y++)
                {
                    TokenState token = this.tiles[x, y].token;
                    
                    if (x >= 2 && token.type == tiles[x-1, y].token.type && token.type == tiles[x-2, y].token.type)
                    {
                        if (!tokens_matched.Contains(token)) tokens_matched.Add(token);
                        if (!tokens_matched.Contains(tiles[x-1, y].token)) tokens_matched.Add(tiles[x-1, y].token);
                        if (!tokens_matched.Contains(tiles[x-2, y].token)) tokens_matched.Add(tiles[x-2, y].token);
                    }

                    if (y >= 2 && token.type == tiles[x, y-1].token.type && token.type == tiles[x, y-2].token.type)
                    {
                        if (!tokens_matched.Contains(token)) tokens_matched.Add(token);
                        if (!tokens_matched.Contains(tiles[x, y-1].token)) tokens_matched.Add(tiles[x, y-1].token);
                        if (!tokens_matched.Contains(tiles[x, y-2].token)) tokens_matched.Add(tiles[x, y-2].token);
                    }
                }

            return tokens_matched;
        }

        internal void DoTokenFall()
        {
            TokenType?[,] types = new TokenType?[this.sizeX, this.sizeY];

            UIAnimationManager.AddAnimation(new UIAnimation_BeginBatch());
            for (int x = 0; x < this.sizeX; x++)
            {
                int first_empty = -1;
                
                for (int y = 0; y < this.sizeY; y++)
                {
                    if (first_empty == -1)
                    {
                        if (this.tiles[x, y].token == null) first_empty = y;
                    } else
                    {
                        TokenState token = this.tiles[x, y].token;

                        if (token != null)
                        {
                            UIAnimationManager.AddAnimation(new UIAnimation_MoveToken(token.x, token.y, x, first_empty));

                            token.SetPosition(x, first_empty, false);
                            first_empty += 1;
                        }
                    }
                }

                if (first_empty == -1) continue;

                while (first_empty < this.sizeY)
                {
                    this.tiles[x, first_empty].token = new TokenState(this, this.DrawToken(), x, first_empty);
                    types[x, first_empty] = this.tiles[x, first_empty].token.type;
                    first_empty++;
                }
            }

            UIAnimationManager.AddAnimation(new UIAnimation_EndBatch());
            UIAnimationManager.AddAnimation(new UIAnimation_DropTokens(types));

            this.HighlightMatching();
        }
        
        private void fillBoard()
        {
            TokenType?[,] types = new TokenType?[this.sizeX, this.sizeY];

            for (int x = 0; x < this.sizeX; x++)
                for (int y = 0; y < this.sizeY; y++)
                {
                    this.tiles[x, y].token = new TokenState(this, this.DrawToken(), x, y);
                    types[x, y] = this.tiles[x, y].token.type;
                }

            UIAnimationManager.AddAnimation( new UIAnimation_DropTokens(types) );
        }

        public readonly List<TokenType> tokenList = new List<TokenType>();

        public void ResetToken()
        {
            this.tokenList.AddRange(this.encounter.playerSheet.tokenDrawList);
            this.tokenList.Shuffle();
        }

        public TokenType DrawToken()
        {
            if (this.tokenList.Count == 0) this.ResetToken();

            TokenType token = this.tokenList[0];
            this.tokenList.RemoveAt(0);
            return token;
        }

    }
}