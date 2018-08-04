using Match3.UI.Animation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive COMPULSIVE = new CharacterPassive
        (
            name: "Compulsive",
            sprite: "tokens/luk",
            tooltip: "At start of each turn, lose 3 non-LUK tokens and gain 3 LUK.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                List<TokenType> types = new List<TokenType>(TokenTypeHelper.AllResource());
                types.Remove(TokenType.LUCK);

                TokenType type = types.RandomChoice();

                encounter.playerState.GainResource(type, -3);
                GameEffect.LerpAnimation(type.GetSpritePath(), 800f, type.AsIPosition(), self.AsIPosition());
                GameEffect.LerpAnimation(TokenType.LUCK.GetSpritePath(), 800f, self.AsIPosition(), TokenType.LUCK.AsIPosition());
                encounter.playerState.GainResource(TokenType.LUCK, 3);
            }
        );
    }
}