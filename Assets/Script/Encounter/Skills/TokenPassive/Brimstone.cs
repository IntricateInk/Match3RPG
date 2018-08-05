using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive BRIMSTONE = new TargetPassive
        (
            name: "Brimstone",
            sprite: "icons/bomb_1",
            tooltip: "When destroyed, destroy all other tokens in a 3 by 3 grid around it.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].AttachAnimation("plasma");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("plasma");
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
