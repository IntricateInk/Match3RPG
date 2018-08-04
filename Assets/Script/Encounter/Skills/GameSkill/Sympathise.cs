using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill SYMPATHISE = new GameSkill
        (
            name: "Sympathise",
            sprite: "skills/sleight",
            tooltip: "Transform all CHA tokens to the target token's type.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                foreach (TokenState other in encounter.boardState.GetTokens())
                {
                    if (other.type == TokenType.CHARISMA)
                        other.type = token.type;
                }
            }
        );
    }
}