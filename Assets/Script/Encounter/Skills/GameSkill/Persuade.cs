using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill PERSUADE = new GameSkill
        (
            name: "Persuade",
            sprite: "icons/convince",
            tooltip: "Transform all tokens of the target token's type to CHA tokens.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenType type = targets[0].type;

                foreach (TokenState other in encounter.boardState.GetTokens())
                {
                    if (other.type == type)
                        other.type = TokenType.CHARISMA;
                }
            }
        );
    }
}