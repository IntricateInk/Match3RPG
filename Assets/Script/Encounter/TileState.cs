using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Match3.UI.Animation;

namespace Match3.Encounter
{
    public class TileState
    {
        public readonly BoardState board;

        internal TokenState token;

        public int x { get; internal set; }
        public int y { get; internal set; }

        internal List<TargetPassive> Passives = new List<TargetPassive>();

        // constructor

        internal TileState(BoardState board, int x, int y)
        {
            this.x = x;
            this.y = y;

            this.board = board;
        }

        // Game Methods

        internal TileState GetAdjacent(int dx, int dy)
        {
            int x = this.x + dx;
            int y = this.y + dy;

            if (x < 0 || y < 0) return null;
            if (x >= board.sizeX || y >= board.sizeY) return null;

            return board.tiles[x, y];
        }
        
        // Private UI methods
        
        internal void ApplyBuff(TargetPassive buff)
        {
            if (!this.Passives.Contains(buff))
            {
                this.Passives.Add(buff);
                buff.OnApplyPassive(this.board.encounter, new List<TokenState>() { this.token });
                UIAnimationManager.AddAnimation(new UIInstruction_AddTargetBuff(this.x, this.y, buff));
            }
        }
        
        internal void RemoveBuff(TargetPassive buff)
        {
            if (this.Passives.Contains(buff))
            {
                buff.OnRemovePassive(this.board.encounter, new List<TokenState>() { this.token });
                this.Passives.Remove(buff);
                UIAnimationManager.AddAnimation(new UIInstruction_RemoveTargetBuff(this.x, this.y, buff));
            }
        }

        internal void PlayAnimation(string animation_name, float play_time = -1, float normalized_size = 1f)
        {
            UIAnimation anim =
                new UIAnimation_AddAnimation(animation_name, this.AsIPosition(), normalized_size: normalized_size);

            if (play_time == -1)
                UIAnimationManager.AddAnimation(anim);
            else
                UIAnimationManager.AddAnimation(anim, play_time);
        }

        internal void AttachAnimation(string animation_name, float normalized_size = 1f)
        {
            UIAnimation anim = new UIAnimation_ApplyTargetAnimation(animation_name, this, normalized_size);
            UIAnimationManager.AddAnimation(anim);
        }

        internal void DettachAnimation(string animation_name)
        {
            UIAnimation anim = new UIAnimation_RemoveTargetAnimation(animation_name, this);
            UIAnimationManager.AddAnimation(anim);
        }

    }
}