using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        public static CharacterPassive STRONG = new CharacterPassive
        (
            name: "Strong",
            sprite: "tokens/str",
            tooltip: "Gain 1 Strength at the start of each turn.",
            
            OnTurnStart: new GameEffect.Action[] {
                GameEffect.GainResource(TokenType.STRENGTH, 1)
            }
        );

        public static CharacterPassive AGILE = new CharacterPassive
        (
            name: "Agile",
            sprite: "tokens/agi",
            tooltip: "Gain 1 Agility at the start of each turn.",

            OnTurnStart: new GameEffect.Action[] {
                GameEffect.GainResource(TokenType.AGILITY, 1)
            }
        );

        public static CharacterPassive INTELLIGENT = new CharacterPassive
        (
            name: "Intelligent",
            sprite: "tokens/int",
            tooltip: "Gain 1 Intelligence at the start of each turn.",

            OnTurnStart: new GameEffect.Action[] {
                GameEffect.GainResource(TokenType.INTELLIGENCE, 1)
            }
        );

        public static CharacterPassive CHARISMATIC = new CharacterPassive
        (
            name: "Charismatic",
            sprite: "tokens/cha",
            tooltip: "Gain 1 Charisma at the start of each turn.",

            OnTurnStart: new GameEffect.Action[] {
                GameEffect.GainResource(TokenType.CHARISMA, 1)
            }
        );

        public static CharacterPassive LUCKY = new CharacterPassive
        (
            name: "Lucky",
            sprite: "tokens/luk",
            tooltip: "Gain 1 Luck at the start of each turn.",

            OnTurnStart: new GameEffect.Action[] {
                GameEffect.GainResource(TokenType.LUCK, 1)
            }
        );

    }
}
