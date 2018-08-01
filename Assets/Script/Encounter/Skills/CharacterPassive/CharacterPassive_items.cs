using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Match3.UI.Animation;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        #region CHARACTER

        public static CharacterPassive STRONG = new CharacterPassive
        (
            name: "Strong",
            sprite: "tokens/str",
            tooltip: "Gain 1 Strength at the start of each turn.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.STRENGTH, 1);
                GameEffect.LerpAnimation(TokenType.STRENGTH.GetSpritePath(), 800f, CharacterPassive.STRONG.AsIPosition(), TokenType.STRENGTH.AsIPosition(), 0f);
            }
        );

        public static CharacterPassive AGILE = new CharacterPassive
        (
            name: "Agile",
            sprite: "tokens/agi",
            tooltip: "Gain 1 Agility at the start of each turn.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.AGILITY, 1);
                GameEffect.LerpAnimation(TokenType.AGILITY.GetSpritePath(), 800f, CharacterPassive.AGILE.AsIPosition(), TokenType.AGILITY.AsIPosition(), 0f);
            }
        );

        public static CharacterPassive INTELLIGENT = new CharacterPassive
        (
            name: "Intelligent",
            sprite: "tokens/int",
            tooltip: "Gain 1 Intelligence at the start of each turn.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.INTELLIGENCE, 1);
                GameEffect.LerpAnimation(TokenType.INTELLIGENCE.GetSpritePath(), 800f, CharacterPassive.INTELLIGENT.AsIPosition(), TokenType.INTELLIGENCE.AsIPosition(), 0f);
            }
        );

        public static CharacterPassive CHARISMATIC = new CharacterPassive
        (
            name: "Charismatic",
            sprite: "tokens/cha",
            tooltip: "Gain 1 Charisma at the start of each turn.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.CHARISMA, 1);
                GameEffect.LerpAnimation(TokenType.CHARISMA.GetSpritePath(), 800f, CharacterPassive.CHARISMATIC.AsIPosition(), TokenType.CHARISMA.AsIPosition(), 0f);
            }
        );

        public static CharacterPassive LUCKY = new CharacterPassive
        (
            name: "Lucky",
            sprite: "tokens/luk",
            tooltip: "Gain 1 Luck at the start of each turn.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.LUCK, 1);
                GameEffect.LerpAnimation(TokenType.LUCK.GetSpritePath(), 800f, CharacterPassive.LUCKY.AsIPosition(), TokenType.LUCK.AsIPosition(), 0f);
            }
        );

        public static CharacterPassive SPRINTER = new CharacterPassive
        (
            name: "Sprinter",
            sprite: "tokens/agi",
            tooltip: string.Format("Gain 10 {0} at the start of the encounter. Lose 1 {0} at the start of each turn.", TokenType.AGILITY.AsStr()),

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.AGILITY, 10);
            },

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.AGILITY, -1);
            }
        );

        public static CharacterPassive QUICK_WITTED = new CharacterPassive
        (
            name: "Quick Witted",
            sprite: "tokens/int",
            tooltip: string.Format("Gain 10 {0} at the start of the encounter. Lose 1 {0} at the start of each turn.", TokenType.INTELLIGENCE.AsStr()),

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.INTELLIGENCE, 10);
            },

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.INTELLIGENCE, -1);
            }
        );

        public static CharacterPassive CURSED = new CharacterPassive
        (
            name: "Cursed",
            sprite: "tokens/int",
            tooltip: "Spawn 3 Zombies at the start of each encounter",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                List<TokenState> tokens = encounter.boardState.GetTokens();
                tokens.Shuffle();

                foreach (TokenState token in tokens.Take(3))
                {
                    token.ApplyBuff(TargetPassive.ZOMBIE);
                }
            }
        );

        #endregion CHARACTER
        
        #region WILDFIRE

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

        #endregion WILDFIRE
        
    }
}
