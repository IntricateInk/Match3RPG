using Match3.Encounter.Effect.Passive;
using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter
{
    public class TokenState
    {
        private bool _isSelected = false;
        public bool IsDestroyed { get; private set; }

        public readonly BoardState board;

        private TokenType _type = TokenType.NULL;
        public TokenType type
        {
            get { return _type; }
            set
            {
                if (type != value)
                {
                    if (type != TokenType.NULL) UIAnimationManager.AddAnimation(new UIInstruction_SetTokenSprite(x, y, value));
                    _type = value;
                }
            }
        }

        public int x { get; internal set; }
        public int y { get; internal set; }

        private static int next_uid = 0;
        public readonly int uid;


        public bool isSelected
        {
            get { return this._isSelected; }
            set
            {
                this._isSelected = value;
                UIAnimationManager.AddInstruction(new UIInstruction_SetTokenSelected(x, y, isSelected));
            }
        }
        
        internal TileState tile {
            get { return this.board.tiles[x, y]; }
        }

        internal List<TargetPassive> Passives = new List<TargetPassive>();

        // constructor

        internal TokenState(BoardState board, TokenType type, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.uid = next_uid;
            this.IsDestroyed = false;

            next_uid++;

            this.type = type;
            this.board = board;
        }

        #region HELPER

        internal List<TokenState> GetAllAdjacent()
        {
            List<TokenState> adjs = new List<TokenState>();
            TokenState adj;

            adj = this.GetAdjacent(0, -1);
            if (adj != null) adjs.Add(adj);

            adj = this.GetAdjacent(0, 1);
            if (adj != null) adjs.Add(adj);

            adj = this.GetAdjacent(1, 0);
            if (adj != null) adjs.Add(adj);

            adj = this.GetAdjacent(-1, 0);
            if (adj != null) adjs.Add(adj);

            return adjs;
        }

        internal TokenState GetAdjacent(int dx, int dy)
        {
            int x = this.x + dx;
            int y = this.y + dy;

            if (x < 0 || y < 0) return null;
            if (x >= board.sizeX || y >= board.sizeY) return null;

            return board.tiles[x, y].token;
        }

        #endregion HELPER

        // Game Methods

        internal void Swap(int dx, int dy) { Swap(GetAdjacent(dx, dy)); }
        internal void Swap(TokenState other)
        {
            UIAnimationManager.AddAnimation(new UIAnimation_SwapToken(this.x, this.y, other.x, other.y));

            int this_x = this.x;
            int this_y = this.y;

            this.SetPosition(other.x, other.y, false);
            other.SetPosition(this_x, this_y, false);
        }

        internal void SetPosition(int new_x, int new_y, bool doAnimate = true)
        {
            if (doAnimate)
                UIAnimationManager.AddAnimation(new UIAnimation_MoveToken(this.x, this.y, new_x, new_y));
            
            this.x = new_x;
            this.y = new_y;

            board.tiles[this.x, this.y].token = this;
        }
        
        internal void Match()
        {
            if (this.IsDestroyed) return;

            ShowResourceGain(this.type, 1);
            Destroy();
            board.encounter.playerState.GainResource(this.type, 1);
        }

        internal void Destroy()
        {
            if (this.IsDestroyed) return;

            this.IsDestroyed = true;
            board.tiles[this.x, this.y].token = null;
            
            foreach (TargetPassive passive in this.Passives.ToArray())
            {
                passive.OnDestroy(board.encounter, new List<TokenState>() { this });
                this.RemoveBuff(passive);
            }
            
            foreach (TargetPassive passive in this.tile.Passives)
            {
                passive.OnDestroy(board.encounter, new List<TokenState>() { this });
            }
            UIAnimationManager.AddAnimation(new UIAnimation_RemoveToken(this.x, this.y));
        }
        
        internal void ApplyBuff(TargetPassive buff)
        {
            if (!this.Passives.Contains(buff))
            {
                this.Passives.Add(buff);
                buff.OnApplyPassive(this.board.encounter, new List<TokenState>() { this });
                UIAnimationManager.AddAnimation(new UIInstruction_AddTargetBuff(this.x, this.y, buff, true));
            }
        }
        
        internal void RemoveBuff(TargetPassive buff)
        {
            if (this.Passives.Contains(buff))
            {
                buff.OnRemovePassive(this.board.encounter, new List<TokenState>() { this });
                this.Passives.Remove(buff);
                UIAnimationManager.AddAnimation(new UIInstruction_RemoveTargetBuff(this.x, this.y, buff, true));
            }
        }

        // UI methods
        
        internal void ShowResourceGain(int amount) { ShowResourceGain(this.type, amount); }
        internal void ShowResourceGain(TokenType token, int amount)
        {
            if (token == TokenType.BLANK) return;

            string sign = "";
            if (amount > 0) sign = "+";
            if (amount < 0) sign = "-";

            ShowText(string.Format("{0}{1}{2}", sign, Mathf.Abs(amount), token.AsStr()));

            if (amount > 0) UIAnimationManager.AddAnimation(new UIAnimation_LerpIcon(token, 800f, this.AsIPosition(), token.AsIPosition()), 0f);
            if (amount < 0) UIAnimationManager.AddAnimation(new UIAnimation_LerpIcon(token, 800f, token.AsIPosition(), this.AsIPosition()), 0f);
        }

        internal void ShowText(string text)
        {
            UIAnimationManager.AddAnimation(new UIInstruction_FloatingText(text, this.x, this.y));
        }

        internal void PlayAnimation(string animation_name)
        {
            UIAnimation anim = new UIAnimation_AddAnimation(animation_name, this.x, this.y, UIAnimation_AddAnimation.AnimationType.None);
            UIAnimationManager.AddAnimation(anim);
        }

        internal void PlayAnimation(string animation_name, float play_time)
        {
            UIAnimation anim = new UIAnimation_AddAnimation(animation_name, this.x, this.y, UIAnimation_AddAnimation.AnimationType.None);
            UIAnimationManager.AddAnimation(anim, play_time);
        }

        internal void AttachAnimation(string animation_name, float normalized_size = 1f)
        {
            UIAnimation anim = new UIAnimation_AddAnimation(animation_name, this.x, this.y, UIAnimation_AddAnimation.AnimationType.Token_Add, normalized_size);
            UIAnimationManager.AddAnimation(anim);
        }

        internal void DettachAnimation(string animation_name)
        {
            UIAnimation anim = new UIAnimation_AddAnimation(animation_name, this.x, this.y, UIAnimation_AddAnimation.AnimationType.Token_Remove);
            UIAnimationManager.AddAnimation(anim);
        }
        
    }
}