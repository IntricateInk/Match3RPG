using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive EXPLOSIVE_TRAP = new TargetPassive
        (
            name: "Explosive Trap",
            sprite: "skills/bash",
            tooltip: "If the token is destroyed, destroy all other tokens in a 3 by 3 grid around it.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.AttachAnimation("dust2");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.DettachAnimation("dust2");
            },

            OnDestroy: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                GameEffect.BeginAnimationBatch();
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        TileState tile = token.tile.GetAdjacent(dx, dy);

                        if (tile == null) continue;

                        tile.PlayAnimation("fire2", 0.2f);

                        if (tile.token == null) continue;

                        tile.token.Destroy();
                    }
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}
