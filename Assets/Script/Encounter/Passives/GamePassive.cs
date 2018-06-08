using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Passive
{

    public abstract class GamePassive : ITooltip
    {
        public string name { get; private set; }
        public string sprite { get; private set; }
        public string tooltip { get; private set; }

        internal int level = 0;

        protected GamePassive(string name, string sprite, string tooltip)
        {
            this.name = name;
            this.sprite = sprite;
            this.tooltip = tooltip;

            _AllPassives.Add(name, this);
        }

        private static Dictionary<string, GamePassive> _AllPassives = new Dictionary<string, GamePassive>();
        
        public static void Init()
        {
            new GamePassive_GainTokenOnTurnState(
                name:   "Strong",
                sprite: "tokens/str",
                tooltip: "Gain 1 Strength at the start of each turn.",
                token: TokenType.STRENGTH,
                amount: 1
            );

            new GamePassive_GainTokenOnTurnState(
                name:   "Agile",
                sprite: "tokens/agi",
                tooltip: "Gain 1 Agility at the start of each turn.",
                token: TokenType.AGILITY,
                amount: 1
            );

            new GamePassive_GainTokenOnTurnState(
                name:    "Intelligent",
                sprite:  "tokens/int",
                tooltip: "Gain 1 Intelligence at the start of each turn.",
                token: TokenType.INTELLIGENCE,
                amount: 1
            );

            new GamePassive_GainTokenOnTurnState(
                name: "Charismatic",
                sprite: "tokens/cha",
                tooltip: "Gain 1 Charisma at the start of each turn.",
                token: TokenType.CHARISMA,
                amount: 1
            );

            new GamePassive_GainTokenOnTurnState(
                name: "Lucky",
                sprite: "tokens/luk",
                tooltip: "Gain 1 Luck at the start of each turn.",
                token: TokenType.LUCK,
                amount: 1
            );
        }

        public static GamePassive GetPassive(string name)
        {
            return _AllPassives[name];
        }
    }
}