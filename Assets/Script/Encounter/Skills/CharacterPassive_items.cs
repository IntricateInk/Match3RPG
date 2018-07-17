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

        // level

        public static CharacterPassive MOLE_INFESTATION_2 = new CharacterPassive
        (
            name: "Mole Infestation! (2)",
            sprite: "tokens/luk",
            tooltip: "Hole-y Mole-y! That is a lot of moles! You start with 15 Agility. At the start of each turn, two tokens become moles.",

            OnApplyPassive: new GameEffect.Action[]
            {
                GameEffect.GainResource(TokenType.AGILITY, 15)
            },

            OnTurnStart: new GameEffect.Action[] {
                GameEffect.SelectRandom(2),
                GameEffect.BeginAnimationBatch,
                GameEffect.PlayAnimation("dust1"),
                GameEffect.EndAnimationBatch,
                GameEffect.ApplyTokenBuff(TargetPassive.MOLE)
            }
        );

        public static CharacterPassive MOLE_INFESTATION_4 = new CharacterPassive
        (
            name: "Mole Infestation! (4)",
            sprite: "tokens/luk",
            tooltip: "Hole-y Mole-y! That is a lot of moles! You start with 15 Agility. At the start of each turn, four tokens become moles.",

            OnApplyPassive: new GameEffect.Action[]
            {
                GameEffect.GainResource(TokenType.AGILITY, 15)
            },

            OnTurnStart: new GameEffect.Action[] {
                GameEffect.SelectRandom(4),
                GameEffect.BeginAnimationBatch,
                GameEffect.PlayAnimation("dust1"),
                GameEffect.EndAnimationBatch,
                GameEffect.ApplyTokenBuff(TargetPassive.MOLE)
            }
        );

        public static CharacterPassive MOLE_INFESTATION_6 = new CharacterPassive
        (
            name: "Mole Infestation! (6)",
            sprite: "tokens/luk",
            tooltip: "Hole-y Mole-y! That is a lot of moles! You start with 15 Agility. At the start of each turn, SIX tokens become moles.",

            OnApplyPassive: new GameEffect.Action[]
            {
                GameEffect.GainResource(TokenType.AGILITY, 15)
            },

            OnTurnStart: new GameEffect.Action[] {
                GameEffect.SelectRandom(6),
                GameEffect.BeginAnimationBatch,
                GameEffect.PlayAnimation("dust1"),
                GameEffect.EndAnimationBatch,
                GameEffect.ApplyTokenBuff(TargetPassive.MOLE),
            }
        );

        // spikes that destroy tiles at the bottom randomly at the end of the turn

        // convert your most abundant resource to the last abundant resource

        // gain X resource at the start of the game
    }
}
