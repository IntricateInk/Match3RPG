using Match3.UI.Animation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        private static CharacterPassive Phantom(string name, TokenType type1, TokenType type2)
        {
            return new CharacterPassive
            (
                name: name,
                sprite: "icons/phantom",
                tooltip: string.Format
                ("A ghostly warrior battles. At the start of your turn, lose all {0} and {1} Resources. For each resource lost, transform a random token to that type.",
                type1.AsStr(), type2.AsStr()),

                OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    int amt1 = encounter.playerState.GetResource(type1);
                    int amt2 = encounter.playerState.GetResource(type2);

                    encounter.playerState.GainResource(type1, -amt1);
                    encounter.playerState.GainResource(type2, -amt2);

                    List<TokenState> tokens = encounter.boardState.GetTokensExcluding(type1, type2);
                    tokens.Shuffle();

                    GameEffect.BeginAnimationBatch();
                    foreach (TokenState token in tokens.Take(amt1))
                    {
                        GameEffect.BeginSequence();
                        GameEffect.LerpAnimation(type1.GetSpritePath(), 800f, type1.AsIPosition(), self.AsIPosition());
                        GameEffect.LerpAnimation(type1.GetSpritePath(), 800f, self.AsIPosition(), token.AsIPosition());
                        token.PlayAnimation("wave1", 0f);
                        token.type = type1;
                        GameEffect.EndSequence();
                    }
                    GameEffect.EndAnimationBatch();

                    tokens.RemoveRange(0, amt1);

                    GameEffect.BeginAnimationBatch();
                    foreach (TokenState token in tokens.Take(amt2))
                    {
                        GameEffect.BeginSequence();
                        GameEffect.LerpAnimation(type2.GetSpritePath(), 800f, type2.AsIPosition(), self.AsIPosition());
                        GameEffect.LerpAnimation(type2.GetSpritePath(), 800f, self.AsIPosition(), token.AsIPosition());
                        token.PlayAnimation("wave1", 0f);
                        token.type = type2;
                        GameEffect.EndSequence();
                    }
                    GameEffect.EndAnimationBatch();
                }
            );
        }

        public static CharacterPassive PHANTOM_BERSERKER = Phantom("Phantom Berserker", TokenType.STRENGTH, TokenType.AGILITY);
        public static CharacterPassive PHANTOM_SWINDLER = Phantom("Phantom Swindler", TokenType.AGILITY, TokenType.INTELLIGENCE);
        public static CharacterPassive PHANTOM_NAVIGATOR = Phantom("Phantom Navigator", TokenType.INTELLIGENCE, TokenType.CHARISMA);
        public static CharacterPassive PHANTOM_NOBLE = Phantom("Phantom Noble", TokenType.CHARISMA, TokenType.LUCK);
        public static CharacterPassive PHANTOM_JESTER = Phantom("Phantom Jester", TokenType.AGILITY, TokenType.LUCK);
    }
}
