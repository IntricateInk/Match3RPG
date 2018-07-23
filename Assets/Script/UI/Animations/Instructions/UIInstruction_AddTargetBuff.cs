using Match3.Encounter.Effect.Passive;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_AddTargetBuff : UIInstruction
    {
        public UIInstruction_AddTargetBuff(int x, int y, TargetPassive buff, bool is_token)
        {
            this.x = x;
            this.y = y;
            this.buff = buff;

            this.is_token = is_token;
        }

        private readonly int x, y;
        private readonly TargetPassive buff;
        private readonly bool is_token;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            if (is_token)
            {
                UITokenController token = manager.board.tiles[x, y].token;
                manager.buffContainer.AddTokenBuff(buff, token);
            }
            else
            {
                UITileController tile = manager.board.tiles[x, y];
                manager.buffContainer.AddTileBuff(buff, tile);
            }
        }
    }
}