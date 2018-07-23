using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Match3.UI
{
    public class UIBuffContainer : MonoBehaviour
    {
        private Dictionary<TargetPassive, UIBuffIcon> tokenBuffs = new Dictionary<TargetPassive, UIBuffIcon>();
        private Dictionary<TargetPassive, UIBuffIcon> tileBuffs  = new Dictionary<TargetPassive, UIBuffIcon>();

        internal void AddTokenBuff(TargetPassive buff, UITokenController token)
        {
            UIBuffIcon icon;

            if (this.tokenBuffs.ContainsKey(buff))
            {
                icon = this.tokenBuffs[buff];
            }
            else
            {
                icon = UIFactory.CreateBuffIcon(buff, this);
                this.tokenBuffs.Add(buff, icon);
            }

            icon.AddToken(token);
        }

        internal void AddTileBuff(TargetPassive buff, UITileController tile)
        {
            UIBuffIcon icon;

            if (this.tileBuffs.ContainsKey(buff))
            {
                icon = this.tileBuffs[buff];
            }
            else
            {
                icon = UIFactory.CreateBuffIcon(buff, this);
                this.tileBuffs.Add(buff, icon);
            }

            icon.AddTile(tile);
        }
        
        internal void RemoveTokenBuff(TargetPassive buff, UITokenController token)
        {
            if (!this.tokenBuffs.ContainsKey(buff)) return;

            UIBuffIcon icon = this.tokenBuffs[buff];
            icon.RemoveToken(token);
        }

        internal void RemoveTileBuff(TargetPassive buff, UITileController tile)
        {
            if (!this.tileBuffs.ContainsKey(buff)) return;

            UIBuffIcon icon = this.tileBuffs[buff];
            icon.RemoveTile(tile);
        }

        internal void AddBuff(ITooltip buff)
        {
            UIFactory.CreateBuffIcon(buff, this);
        }
    }
}
