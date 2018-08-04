using Match3.UI.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive HOT_TEMPERMENT = new CharacterPassive
        (
            name: "Hot Temperment",
            sprite: "tokens/agi",
            tooltip: "At the start of each turn, gain 1 Agility for each Wildfire.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                int fire_count = 0;
                foreach (TokenState token in encounter.boardState.GetTokens())
                {
                    if (token.Passives.Contains(TargetPassive.WILDFIRE))
                    {
                        fire_count++;
                        GameEffect.BeginSequence();
                        GameEffect.LerpAnimation(TokenType.AGILITY.GetSpritePath(), 800f, token.AsIPosition(), CharacterPassive.HOT_TEMPERMENT.AsIPosition());
                        GameEffect.LerpAnimation(TokenType.AGILITY.GetSpritePath(), 800f, CharacterPassive.HOT_TEMPERMENT.AsIPosition(), TokenType.AGILITY.AsIPosition());
                        GameEffect.EndSequence();
                    }
                }
                GameEffect.EndAnimationBatch();

                encounter.playerState.GainResource(TokenType.AGILITY, fire_count);
            }
        );
    }
}