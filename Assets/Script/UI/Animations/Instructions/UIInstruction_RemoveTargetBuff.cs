using Match3.Encounter.Effect.Passive;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_RemoveTargetBuff : UIInstruction
    {
        public UIInstruction_RemoveTargetBuff(int uid, TargetPassive buff)
        {
            this.uid = uid;
            this.buff = buff;
        }

        public UIInstruction_RemoveTargetBuff(int x, int y, TargetPassive buff)
        {
            this.x = x;
            this.y = y;
            this.buff = buff;
        }

        private readonly int uid = -1;
        private readonly int x = -1;
        private readonly int y = -1;
        private readonly TargetPassive buff;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            if (uid != -1)
            {
                UITokenController token = manager.board.GetToken(uid);
                manager.buffContainer.RemoveTokenBuff(buff, token);
            }
            else
            {
                UITileController tile = manager.board.tiles[x, y];
                manager.buffContainer.RemoveTileBuff(buff, tile);
            }
        }
    }
}