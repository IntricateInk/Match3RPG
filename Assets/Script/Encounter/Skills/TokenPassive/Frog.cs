using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive FROG = new TargetPassive
        (
            name: "Frog",
            sprite: "skills/bash",
            tooltip: "At the end of the turn, swap the token above it to the top row.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.AttachAnimation("explosion5");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.DettachAnimation("explosion5");
            },

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                BoardState board = encounter.boardState;

                if (token.y < board.sizeY - 2)
                {
                    token.GetAdjacent(0, 1).Swap(board.GetToken(token.x, board.sizeY - 1));
                }
            }
        );
    }
}
