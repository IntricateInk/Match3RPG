using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Match3.UI.Animation;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        private static CharacterPassive Wildfire(string name, string sprite, int lives, int wildfire)
        {
            return new CharacterPassive
            (
                name: name, sprite: sprite,
                tooltip: string.Format("FIRE! Gain 30 STR and AGI at the start of the encounter, and apply {0} Crew buffs and {1} Wildfire buffs to the board at random.", lives, wildfire),

                OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    encounter.playerState.GainResource(TokenType.STRENGTH, 30);
                    encounter.playerState.GainResource(TokenType.AGILITY, 30);

                    List<TokenState> tokens = encounter.boardState.GetTokens();
                    tokens.Shuffle();

                    GameEffect.BeginAnimationBatch();

                    foreach (TokenState token in tokens.Take(lives))
                    {
                        token.ApplyBuff(TargetPassive.CREW);
                    }

                    tokens.RemoveRange(0, lives);

                    foreach (TokenState token in tokens.Take(wildfire))
                    {
                        token.ApplyBuff(TargetPassive.WILDFIRE);
                    }

                    GameEffect.EndAnimationBatch();
                }
            );
        }

        public static CharacterPassive WILDFIRE_1 = Wildfire("Small Forest Fire!", "tokens/agi", 2, 4);
        public static CharacterPassive WILDFIRE_2 = Wildfire("Forest Fire!", "tokens/agi", 3, 5);
        public static CharacterPassive WILDFIRE_3 = Wildfire("Blazing Forest Fire!", "tokens/agi", 3, 8);
    }
}
