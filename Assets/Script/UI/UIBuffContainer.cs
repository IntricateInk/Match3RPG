using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Match3.UI
{
    public class UIBuffContainer : MonoBehaviour
    {
        private Dictionary<CharacterPassive, UIBuffIcon> charBuffs = new Dictionary<CharacterPassive, UIBuffIcon>();
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
                icon = UIFactory.CreateTargetBuffIcon(buff, this);
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
                icon = UIFactory.CreateTargetBuffIcon(buff, this);
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

        internal void AddBuff(CharacterPassive buff)
        {
            if (this.charBuffs.ContainsKey(buff))
            {
                this.charBuffs[buff].gameObject.SetActive(true);
            }
            else
            {
                UIBuffIcon uibuff = UIFactory.CreateCharBuffIcon(buff, this);
                this.charBuffs.Add(buff, uibuff);
            }
        }

        internal void RemoveBuff(CharacterPassive buff)
        {
            if (!this.charBuffs.ContainsKey(buff)) return;

            this.charBuffs[buff].gameObject.SetActive(false);
        }

        internal Vector3 GetBuffPosition(CharacterPassive passive)
        {
            if (this.charBuffs.ContainsKey(passive))
            {
                return this.charBuffs[passive].transform.position;
            }
            else
            {
                throw new ArgumentException(string.Format("No such passive: {0}", passive));
            }
        }

        internal Vector3 GetBuffPosition(TargetPassive passive)
        {
            if (this.tokenBuffs.ContainsKey(passive))
            {
                return this.tokenBuffs[passive].transform.position;
            } else if (this.tileBuffs.ContainsKey(passive))
            {
                return this.tileBuffs[passive].transform.position;
            } else
            {
                throw new ArgumentException(string.Format("No such passive: {0}", passive));
            }
        }

    }
}
