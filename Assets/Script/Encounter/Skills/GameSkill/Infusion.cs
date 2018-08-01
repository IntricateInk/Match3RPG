using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill INFUSION = new GameSkill
        (
            name: "Infusion",
            sprite: "skills/sleight",
            tooltip: "Transform all Blank tokens to a random non-Blank token.",

            energyCost: 2,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in encounter.boardState.GetTokens())
                {
                    if (token.type == TokenType.BLANK)
                    {
                        token.PlayAnimation("wave2");
                        token.type = TokenTypeHelper.RandomResource();
                    }
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}