using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public sealed partial class GamePassive : ITooltip
    {
        public static GamePassive STRONG = new GamePassive
        (
            name: "Strong",
            sprite: "tokens/str",
            tooltip: "Gain 1 Strength at the start of each turn.",
            
            OnTurnStart: new GameEffect.Action[] {
                GameEffect.GainResource(TokenType.STRENGTH, 1)
            }
        );

        public static GamePassive AGILE = new GamePassive
        (
            name: "Agile",
            sprite: "tokens/agi",
            tooltip: "Gain 1 Agility at the start of each turn.",

            OnTurnStart: new GameEffect.Action[] {
                GameEffect.GainResource(TokenType.AGILITY, 1)
            }
        );

        public static GamePassive INTELLIGENT = new GamePassive
        (
            name: "Intelligent",
            sprite: "tokens/int",
            tooltip: "Gain 1 Intelligence at the start of each turn.",

            OnTurnStart: new GameEffect.Action[] {
                GameEffect.GainResource(TokenType.INTELLIGENCE, 1)
            }
        );

        public static GamePassive CHARISMATIC = new GamePassive
        (
            name: "Charismatic",
            sprite: "tokens/cha",
            tooltip: "Gain 1 Charisma at the start of each turn.",

            OnTurnStart: new GameEffect.Action[] {
                GameEffect.GainResource(TokenType.CHARISMA, 1)
            }
        );

        public static GamePassive LUCKY = new GamePassive
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
