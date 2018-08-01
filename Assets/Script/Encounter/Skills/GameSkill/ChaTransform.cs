using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        private static GameSkill ChaTransformPlus(string name, string sprite, TokenType type)
        {
            return new GameSkill
            (
                name: name,
                sprite: sprite,
                tooltip: string.Format("Transform a token and adjacent tokens to {0}.", type.AsStr()),

                energyCost: 4,

                selectBehavior: SelectBehavior.Single,

                runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
                {
                    List<TokenState> tokens = targets[0].GetAllAdjacent();
                    tokens.Add(targets[0]);

                    GameEffect.BeginAnimationBatch();
                    foreach (TokenState token in tokens)
                    {
                        token.type = type;
                        token.PlayAnimation("wave1");
                    }
                    GameEffect.EndAnimationBatch();
                }
            );

        }

        public static GameSkill THREATEN = ChaTransformPlus("Threaten", "tokens/cha", TokenType.STRENGTH);
        public static GameSkill GUILE = ChaTransformPlus("Guile", "tokens/cha", TokenType.AGILITY);
        public static GameSkill WIT = ChaTransformPlus("Wit", "tokens/cha", TokenType.INTELLIGENCE);
        public static GameSkill AFFLUENCE = ChaTransformPlus("Affluence", "tokens/cha", TokenType.LUCK);
    }
}