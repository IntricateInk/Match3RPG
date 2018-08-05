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
                tooltip: string.Format("FIRE! Gain 30 STR and AGI at the start of the encounter, and apply {0} Crew buffs. At the start of every turn, spawn {1} Wildfire tokens.", lives, wildfire),

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
                },

                OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    List<TokenState> tokens = encounter.boardState.GetTokens();
                    tokens.Shuffle();

                    int n = wildfire;

                    foreach (TokenState token in tokens.Take(wildfire))
                    {
                        if (token.Passives.Contains(TargetPassive.WILDFIRE) ||
                            token.Passives.Contains(TargetPassive.CREW)) continue;

                        token.ApplyBuff(TargetPassive.WILDFIRE);
                        n--;
                        if (n < 0) break;
                    }

                    GameEffect.EndAnimationBatch();
                }
            );
        }

        public static CharacterPassive WILDFIRE_1 = Wildfire("Small Forest Fire!", "icons/fire_2", 2, 4);
        public static CharacterPassive WILDFIRE_2 = Wildfire("Forest Fire!", "icons/fire_2", 3, 5);
        public static CharacterPassive WILDFIRE_3 = Wildfire("Blazing Forest Fire!", "icons/fire_2", 3, 8);
    }
}
