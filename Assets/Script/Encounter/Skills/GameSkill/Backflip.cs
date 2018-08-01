using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    // top with bottom and left with right
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill BACKFLIP = new GameSkill
        (
            name: "Backflip",
            sprite: "skills/sleight",
            tooltip: "Swap the token on the left with the token on the right. Then swap the token above with the token below.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                TokenState left = token.GetAdjacent(-1, 0);
                TokenState right = token.GetAdjacent(1, 0);
                TokenState above = token.GetAdjacent(0, 1);
                TokenState below = token.GetAdjacent(0, -1);

                GameEffect.BeginAnimationBatch();
                if (left != null && right != null)
                {
                    left.PlayAnimation("stargate", normalized_size: 3f);
                    right.PlayAnimation("stargate", normalized_size: 3f);
                    left.Swap(right);
                }

                if (above != null && below != null)
                {
                    above.PlayAnimation("stargate", normalized_size: 3f);
                    below.PlayAnimation("stargate", normalized_size: 3f);
                    above.Swap(below);
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}