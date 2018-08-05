using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill SMASH = new GameSkill
        (
            name: "Smash",
            sprite: "icons/rush_1",
            tooltip: "Destroy target token. If target token is STR, destroy a 3x3 area around it instead.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                if (token.type == TokenType.STRENGTH)
                {
                    foreach (TokenState other in token.GetSurrounding(-1, -1, 1, 1))
                        other.Destroy();
                } else
                {
                    token.Destroy();
                }
            }
        );
    }
}