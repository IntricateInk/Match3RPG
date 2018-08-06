using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        }
        
        internal void DoMatch()
        {
            UIAnimationManager.AddAnimation(new UIAnimation_BeginBatch());
            foreach (TokenState token in this.GetMatching())
            {
                token.Match();
            }
            UIAnimationManager.AddAnimation(new UIAnimation_EndBatch());
        }

        internal void DoTurnEnd()
        {
            this.DoTokenFall();

            this.DoMatch();

            this.DoTokenFall();

            this.encounter.playerState.Turn++;
        }
        
        private List<TokenState> GetMatching()
        {
            List<TokenState> tokens_matched = new List<TokenState>();

            for (int x = 0; x < this.sizeX; x++)
                for (int y = 0; y < this.sizeY; y++)
                {
                    TokenState token = this.tiles[x, y].token;

                    if (token.type == TokenType.BLANK) continue;

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
            TokenState[,] tokens = new TokenState[this.sizeX, this.sizeY];

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
                            token.SetPosition(x, first_empty);
                            first_empty += 1;
                        }
                    }
                }

                if (first_empty == -1) continue;

                while (first_empty < this.sizeY)
                {
                    this.tiles[x, first_empty].token = new TokenState(this, this.DrawToken(), x, first_empty);
                    tokens[x, first_empty] = this.tiles[x, first_empty].token;
                    first_empty++;
                }
            }

            UIAnimationManager.AddAnimation(new UIAnimation_EndBatch());
            UIAnimationManager.AddAnimation(new UIAnimation_DropTokens(tokens));
        }
        

        private void fillBoard()
        {
            TokenState[,] tokens = new TokenState[this.sizeX, this.sizeY];

            for (int x = 0; x < this.sizeX; x++)
                for (int y = 0; y < this.sizeY; y++)
                {
                    this.tiles[x, y].token = new TokenState(this, this.DrawToken(), x, y);
                    tokens[x, y] = this.tiles[x, y].token;
                }

            UIAnimationManager.AddAnimation( new UIAnimation_DropTokens(tokens) );
        }

        public readonly List<TokenType> tokenList = new List<TokenType>();

        public void ResetToken()
        {
            this.tokenList.AddRange(TokenTypeHelper.AllResource());
            this.tokenList.Shuffle();
        }

        public TokenType DrawToken()
        {
            if (this.tokenList.Count == 0) this.ResetToken();

            TokenType token = this.tokenList[0];
            this.tokenList.RemoveAt(0);
            return token;
        }

        // Helper Methods

        internal List<TileState> GetTileCol(int x)
        {
            List<TileState> col = new List<TileState>();

            for (int y = 0; y < sizeY; y++)
            {
                col.Add(this.tiles[x, y]);
            }

            return col;
        }

        internal List<TileState> GetTileRow(int y)
        {
            List<TileState> row = new List<TileState>();

            for (int x = 0; x < sizeX; x++)
            {
                row.Add(this.tiles[x, y]);
            }

            return row;
        }
        internal List<TokenState> GetTokenCol(int x)
        {
            List<TokenState> col = new List<TokenState>();

            for (int y = 0; y < sizeY; y++) {
                TokenState token = this.tiles[x, y].token;

                if (token != null) col.Add(token);
            }

            return col;
        }

        internal List<TokenState> GetTokenRow(params int[] row_indices)
        {
            List<TokenState> rows = new List<TokenState>();

            foreach (int x in row_indices)
            {
                int idx = x;
                if (idx < 0) idx = sizeX + idx;

                rows.AddRange(this.GetTokenRow(idx));
            }

            return rows;
        }

        internal List<TokenState> GetTokenRow(int y)
        {
            List<TokenState> row = new List<TokenState>();

            for (int x = 0; x < sizeX; x++)
            {
                TokenState token = this.tiles[x, y].token;

                if (token != null) row.Add(token);
            }

            return row;
        }

        internal List<TokenState> GetTokenCol(params int[] y_indices)
        {
            List<TokenState> cols = new List<TokenState>();

            foreach (int y in y_indices)
            {
                int idx = y;
                if (idx < 0) idx = sizeY + idx;

                cols.AddRange(this.GetTokenCol(idx));
            }

            return cols;
        }

        internal IEnumerable<TileState> GetTileBox(int x_min, int y_min, int x_max, int y_max)
        {
            int x, y;

            if (y_max < sizeY)
            {
                y = y_max;
                for (int x_loop = Mathf.Max(0, x_min); x_loop <= Mathf.Min(sizeX - 1, x_max); x_loop++)
                {
                    yield return this.tiles[x_loop, y];
                }
            }

            if (x_max < sizeX)
            {
                x = x_max;
                for (int y_loop = Mathf.Min(sizeY - 1, y_max - 1); y_loop >= Mathf.Max(0, y_min); y_loop--)
                {
                    yield return this.tiles[x, y_loop];
                }
            }

            if (y_min >= 0)
            {
                y = y_min;
                for (int x_loop = Mathf.Min(sizeX - 1, x_max - 1); x_loop >= Mathf.Max(0, x_min); x_loop--)
                {
                    yield return this.tiles[x_loop, y];
                }
            }

            if (x_min >= 0)
            {
                x = x_min;
                for (int y_loop = Mathf.Max(0, y_min + 1); y_loop <= Mathf.Min(sizeY - 1, y_max - 1); y_loop++)
                {
                    yield return this.tiles[x, y_loop];
                }
            }
        }

        internal TokenState GetToken(int x, int y)
        {
            return this.tiles[x, y].token;
        }

        internal List<TokenState> GetTokensExcluding(params TokenType[] types)
        {
            return GetTokens(TokenTypeHelper.AllTokenType().Except(types).ToArray());
        }

        internal List<TokenState> GetTokens(params TokenType[] types)
        {
            if (types.Length == 0)
            {
                types = TokenTypeHelper.AllTokenType();
            }

            List<TokenState> tokens = new List<TokenState>();

            foreach (TileState tile in this.tiles)
            {
                if (tile.token != null && Array.IndexOf(types, tile.token.type) != -1)
                {
                    tokens.Add(tile.token);
                }
            }
            return tokens;
        }
        
    }
}