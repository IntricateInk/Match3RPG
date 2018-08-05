using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill PRAY = new GameSkill
        (
            name: "Pray",
            sprite: "icons/bless_1",
            tooltip: "Transform all blanks to CHA.",

            energyCost: 2,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                foreach (TokenState other in encounter.boardState.GetTokens())
                {
                    if (other.type == TokenType.BLANK)
                    {
                        other.type = TokenType.CHARISMA;
                        other.PlayAnimation("wave1");
                    }
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}