using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_SetTokenSprite : UIInstruction
    {
        public UIInstruction_SetTokenSprite(int x, int y, TokenType type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

        private readonly int x;
        private readonly int y;
        private readonly TokenType type;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.board.tiles[x, y].token.SetType(type);
        }
    }
}