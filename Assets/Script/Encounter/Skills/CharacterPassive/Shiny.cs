using Match3.UI.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        private static CharacterPassive ExchangeResource(string name, string sprite, TokenType from_type, TokenType to_type, int amount)
        {
            return new CharacterPassive
            (
                name: name,
                sprite: sprite,
                tooltip: string.Format("At start of each turn, lose {0}{1} and gain {0}{2}.", 
                amount, from_type, to_type),

                OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    encounter.playerState.GainResource(from_type, -amount);
                    GameEffect.LerpAnimation(from_type.GetSpritePath(), 800f, from_type.AsIPosition(), self.AsIPosition());
                    GameEffect.LerpAnimation(to_type.GetSpritePath(), 800f, self.AsIPosition(), to_type.AsIPosition());
                    encounter.playerState.GainResource(to_type, amount);
                }
            );
        }

        public static CharacterPassive SHINY_ARMOR = ExchangeResource
        (
            name: "Shiny Armor",
            sprite: "icons/armor",

            from_type: TokenType.STRENGTH,
            to_type: TokenType.CHARISMA,
            amount: 2
        );

        public static CharacterPassive SHINY_SHOES = ExchangeResource
        (
            name: "Shiny Shoes",
            sprite: "icons/kick",

            from_type: TokenType.AGILITY,
            to_type: TokenType.CHARISMA,
            amount: 2
        );

        public static CharacterPassive SHINY_CAP = ExchangeResource
        (
            name: "Shiny Cap",
            sprite: "icons/shiny_cap",

            from_type: TokenType.INTELLIGENCE,
            to_type: TokenType.CHARISMA,
            amount: 2
        );
    }
}