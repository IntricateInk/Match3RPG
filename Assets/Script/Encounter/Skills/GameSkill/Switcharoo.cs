using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill SWITCHAROO = new GameSkill
        (
            name: "Switcharoo",
            sprite: "skills/sleight",
            tooltip: "Select a token. Switch the tile on its left with its right.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                TokenState left = token.GetAdjacent(-1, 0);
                TokenState right = token.GetAdjacent(1, 0);

                GameEffect.BeginAnimationBatch();
                if (left != null && right != null)
                {
                    left.PlayAnimation("stargate", normalized_size: 3f);
                    right.PlayAnimation("stargate", normalized_size: 3f);
                    left.Swap(right);
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}