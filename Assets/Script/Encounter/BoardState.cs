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

        internal void DoTurnEnd()
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
                            UIAnimationManager.AddAnimation(new UIAnimation_MoveToken(token.uid, x, first_empty));

                            token.SetPosition(x, first_empty, false);
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

        // Helper Methods

        internal List<TokenState> GetCol(int x)
        {
            List<TokenState> row = new List<TokenState>();

            for (int y = 0; y < sizeY; y++) {
                TokenState token = this.tiles[x, y].token;

                if (token != null) row.Add(token);
            }

            return row;
        }

        internal List<TokenState> GetRow(params int[] row_indices)
        {
            List<TokenState> rows = new List<TokenState>();

            foreach (int x in row_indices)
            {
                int idx = x;
                if (idx < 0) idx = sizeX + idx;

                rows.AddRange(this.GetRow(idx));
            }

            return rows;
        }

        internal List<TokenState> GetRow(int y)
        {
            List<TokenState> col = new List<TokenState>();

            for (int x = 0; x < sizeX; x++)
            {
                TokenState token = this.tiles[x, y].token;

                if (token != null) col.Add(token);
            }

            return col;
        }

        internal List<TokenState> GetCol(params int[] y_indices)
        {
            List<TokenState> cols = new List<TokenState>();

            foreach (int y in y_indices)
            {
                int idx = y;
                if (idx < 0) idx = sizeY + idx;

                cols.AddRange(this.GetCol(idx));
            }

            return cols;
        }

        internal TokenState GetToken(int x, int y)
        {
            return this.tiles[x, y].token;
        }

        internal List<TokenState> GetTokensExcluding(params TokenType[] types)
        {
            return GetTokens(TokenTypeHelper.AllResource().Except(types).ToArray());
        }

        internal List<TokenState> GetTokens(params TokenType[] types)
        {
            if (types.Length == 0)
            {
                types = TokenTypeHelper.AllResource();
            }

            List<TokenState> tokens = new List<TokenState>();

            foreach (TileState tile in this.tiles)
            {
                if (Array.IndexOf(types, tile.token.type) != -1)
                {
                    tokens.Add(tile.token);
                }
            }
            return tokens;
        }
        
    }
}