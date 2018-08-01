using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill LEAP = new GameSkill
        (
            name: "Leap",
            sprite: "skills/sleight",
            tooltip: "Select a token. Swap all tokens of that type with the token above it.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in encounter.boardState.GetTokens(targets[0].type))
                {
                    TokenState above = token.GetAdjacent(0, 1);

                    if (above != null)
                    {
                        token.PlayAnimation("stargate", normalized_size: 2f);
                        token.Swap(above);
                    }
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}