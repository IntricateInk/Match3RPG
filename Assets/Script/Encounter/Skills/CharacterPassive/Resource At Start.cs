using Match3.UI.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        private static CharacterPassive ResourceAtStart(
            string name, string sprite, TokenType type, int amount)
        {
            return new CharacterPassive
            (
                name: name,
                sprite: sprite,
                tooltip: string.Format("At the start of the turn, gain {0}{1}{2}.",
                Mathf.Sign(amount), Mathf.Abs(amount), type),

                OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    encounter.playerState.GainResource(type, amount);
                    if (amount > 0)
                        GameEffect.LerpAnimation(type.GetSpritePath(), 800f, self.AsIPosition(), type.AsIPosition(), 0f);
                    else
                        GameEffect.LerpAnimation(type.GetSpritePath(), 800f, type.AsIPosition(), self.AsIPosition(), 0f);
                }
            );
        }

        public static CharacterPassive STRONG = ResourceAtStart
        (
            name: "Strong",
            sprite: "icons/flex",
            type: TokenType.STRENGTH,
            amount: 1
        );

        public static CharacterPassive AGILE = ResourceAtStart
        (
            name: "Agile",
            sprite: "icons/afterimage_2",
            type: TokenType.AGILITY,
            amount: 1
        );

        public static CharacterPassive INTELLIGENT = ResourceAtStart
        (
            name: "Intelligent",
            sprite: "icons/book_2",
            type: TokenType.STRENGTH,
            amount: 1
        );

        public static CharacterPassive CHARISMATIC = ResourceAtStart
        (
            name: "Charismatic",
            sprite: "icons/smile",
            type: TokenType.CHARISMA,
            amount: 1
        );

        public static CharacterPassive LUCKY = ResourceAtStart
        (
            name: "Lucky",
            sprite: "icons/fairy",
            type: TokenType.LUCK,
            amount: 1
        );

        public static CharacterPassive SHARP_WEAPON = ResourceAtStart
        (
            name: "Sharp Weapon",
            sprite: "icons/slice_1",
            type: TokenType.STRENGTH,
            amount: 2
        );

        public static CharacterPassive FLEXIBLE = ResourceAtStart
        (
            name: "Flexible",
            sprite: "icons/flexible",
            type: TokenType.AGILITY,
            amount: 2
        );

        public static CharacterPassive FEEBLE = ResourceAtStart
        (
            name: "Feeble",
            sprite: "icons/weaken",
            type: TokenType.STRENGTH,
            amount: -1
        );

        public static CharacterPassive SLOW = ResourceAtStart
        (
            name: "Slow",
            sprite: "icons/slow",
            type: TokenType.AGILITY,
            amount: -1
        );

        public static CharacterPassive WEAK_WILLED = ResourceAtStart
        (
            name: "Weak Willed",
            sprite: "icons/weak_willed",
            type: TokenType.INTELLIGENCE,
            amount: -1
        );

        public static CharacterPassive REPULSIVE = ResourceAtStart
        (
            name: "Repulsive",
            sprite: "icons/shadow",
            type: TokenType.CHARISMA,
            amount: -1
        );

        public static CharacterPassive UNFORTUNATE = ResourceAtStart
        (
            name: "Unfortunate",
            sprite: "icons/focus_5",
            type: TokenType.LUCK,
            amount: -1
        );
    }
}