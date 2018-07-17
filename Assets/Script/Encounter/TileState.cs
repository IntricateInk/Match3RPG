using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        
        internal void ApplyBuff(string buff_name) { ApplyBuff(TargetPassive.GetPassive(buff_name)); }
        internal void ApplyBuff(TargetPassive buff)
        {
            this.Passives.Add(buff);
            buff.OnApplyPassive(this.board.encounter, new List<TokenState>() { this.token });
        }

        internal void RemoveBuff(string buff_name) { RemoveBuff(TargetPassive.GetPassive(buff_name)); }
        internal void RemoveBuff(TargetPassive buff)
        {
            buff.OnRemovePassive(this.board.encounter, new List<TokenState>() { this.token });
            this.Passives.Remove(buff);
        }
    }
}