using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive CRAB = new TargetPassive
        (
            name: "Crab",
            sprite: "skills/bash",
            tooltip: "At the end of the turn, swap to the left. If already at the left end of the board, swap to the right end instead.",

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
                int right = encounter.boardState.sizeX - 1;

                if (token.x != 0)
                {
                    token.Swap(-1, 0);
                }
                else
                {
                    token.Swap(encounter.boardState.GetToken(right, token.y));
                }
            }
        );
    }
}
