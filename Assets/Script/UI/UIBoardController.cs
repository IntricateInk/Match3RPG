using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Encounter;
using System;

namespace Match3.UI
{

    public class UIBoardController : MonoBehaviour
    {
        [SerializeField]
        private Transform[] layers;

        internal UITileController[,] tiles;
        
        public float token_size_x { get { return this.GetComponent<RectTransform>().sizeDelta[0] / sizeX; } }
        public float token_size_y { get { return this.GetComponent<RectTransform>().sizeDelta[1] / sizeY; } }
        public Vector2 token_size { get { return new Vector2(token_size_x, token_size_y); } }

        public int sizeX { get { return this.tiles.GetLength(0); } }
        public int sizeY { get { return this.tiles.GetLength(1); } }

        internal Vector3 GetPosition(int x, int y)
        {
            RectTransform rt = this.GetComponent<RectTransform>();

            float vx = Mathf.Lerp(0, rt.sizeDelta.x, (float)x / this.sizeX) + token_size_x / 2;
            float vy = Mathf.Lerp(0, rt.sizeDelta.y, (float)y / this.sizeY) + token_size_y / 2;

            return this.transform.position + new Vector3(vx, vy);
        }
        
        internal void SetPosition(UITokenController token, int x, int y)
        {
            token.x = x;
            token.y = y;
            this.tiles[x, y].token = token;

            RectTransform rt = token.GetComponent<RectTransform>();

            rt.anchorMin = new Vector2
                (
                    (float)x / this.sizeX,
                    (float)y / this.sizeY
                );
            rt.anchorMax = new Vector2
                (
                    ((float)x + 1) / this.sizeX,
                    ((float)y + 1) / this.sizeY
                );

            rt.offsetMin = Vector2.zero;
            rt.offsetMax = Vector2.zero;
        }

        internal UITileController[,] CreateTiles (int sx, int sy)
        {
            this.tiles = new UITileController[sx, sy];

            for (int x = 0; x < sx; x++)
            {
                for (int y = 0; y < sy; y++)
                {
                    this.tiles[x, y] = UIFactory.CreateTile(x, y, this);
                    this.SetLayer(this.tiles[x, y].transform, 0);
                }
            }

            return this.tiles;
        }

        internal UITokenController[,] CreateToken(TokenType?[,] tokens)
        {
            int sx = tokens.GetLength(0);
            int sy = tokens.GetLength(1);
            if (this.tiles == null) CreateTiles(sx, sy);
            UITokenController[,] uiTokens = new UITokenController[sx, sy];

            for (int x = 0; x < sx; x++)
                for (int y = 0; y < sy; y++)
                    if (tokens[x, y].HasValue)
                        uiTokens[x, y] = this.CreateToken(x, y, tokens[x, y].Value);

            return uiTokens;
        }
        
        private UITokenController CreateToken(int x, int y, TokenType type)
        {
            this.tiles[x, y].token = UIFactory.CreateToken(x, y, type, this);
            return this.tiles[x, y].token;
        }

        internal void SetLayer(Transform item, int depth)
        {
            item.SetParent(this.layers[depth]);

            foreach (Transform layer in this.layers)
            {
                if (layer.childCount != 0)
                {
                    layer.gameObject.SetActive(true);
                }
                else
                {
                    layer.gameObject.SetActive(false);
                }
            }
        }
    }

}