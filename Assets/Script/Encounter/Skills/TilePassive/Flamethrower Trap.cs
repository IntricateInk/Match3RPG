using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive FLAMETHROWER_TRAP = new TargetPassive
        (
            name: "Flamethrower Trap",
            sprite: "skills/bash",
            tooltip: "If the token is destroyed, destroy all other tokens in the row and column.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.AttachAnimation("trap2");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.DettachAnimation("trap2");
            },

            OnDestroy: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                List<TileState> row = encounter.boardState.GetTileRow(token.y);
                List<TileState> col = encounter.boardState.GetTileCol(token.x);

                row.AddRange(col);

                GameEffect.BeginAnimationBatch();

                foreach (TileState tile in row)
                {
                    tile.PlayAnimation("fire2", 0.2f);

                    if (tile.token != null)
                        tile.token.Destroy();
                }

                GameEffect.EndAnimationBatch();
            }
        );

    }
}
