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
                targets[0].tile.AttachAnimation("dust3");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.DettachAnimation("dust3");
            },

            OnDestroy: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                List<TokenState> row = encounter.boardState.GetRow(token.x);
                List<TokenState> col = encounter.boardState.GetCol(token.y);

                row.AddRange(col);

                GameEffect.BeginAnimationBatch();

                foreach (TokenState other in row)
                {
                    if (other == token) continue;

                    other.PlayAnimation("fire2");
                    other.Destroy();
                }

                GameEffect.EndAnimationBatch();
            }
        );

    }
}
