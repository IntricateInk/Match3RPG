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

        // -1 energy for first 3 turns
        // +1 wildfire each turn
        // +1 crew at start
        // -1 energy at start of turn
        // lose X resource every X turns

        // diagonal match at end of turn
        // +1 energy at start of turn
        //- +1 cascade at end of turn
        //- at start of turn, apply buff to random X tile
        //- if perform a 5 match, apply buff?
        //- if perform a + match, apply buff?
        //- if perform a T match, apply buff?

        #region ENCOUNTER

        #region PHANTOM

        private static CharacterPassive Phantom(string name, TokenType type1, TokenType type2)
        {
            return new CharacterPassive
            (
                name: name,
                sprite: "tokens/str",
                tooltip: string.Format
                ("A ghostly warrior battles. At the start of your turn, lose all {0} and {1} Resources. For each resource lost, transform a random token to that type.",
                type1.AsStr(), type2.AsStr()),

                OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    int amt1 = encounter.playerState.GetResource(type1);
                    int amt2 = encounter.playerState.GetResource(type2);

                    encounter.playerState.GainResource(type1, -amt1);
                    encounter.playerState.GainResource(type2, -amt2);

                    List<TokenState> tokens = encounter.boardState.GetTokensExcluding(type1, type2);
                    tokens.Shuffle();

                    GameEffect.BeginAnimationBatch();
                    foreach (TokenState token in tokens.Take(amt1))
                    {
                        token.PlayAnimation("wave1");
                        token.ShowResourceGain(type1, -1);
                        token.type = type1;
                    }

                    tokens.RemoveRange(0, amt1);

                    foreach (TokenState token in tokens.Take(amt2))
                    {
                        token.PlayAnimation("wave1");
                        token.ShowResourceGain(type2, -1);
                        token.type = type2;
                    }
                    GameEffect.EndAnimationBatch();
                }
            );
        }

        public static CharacterPassive PHANTOM_BERSERKER = Phantom("Phantom Berserker", TokenType.STRENGTH, TokenType.AGILITY);
        public static CharacterPassive PHANTOM_SWINDLER = Phantom("Phantom Swindler", TokenType.AGILITY, TokenType.INTELLIGENCE);
        public static CharacterPassive PHANTOM_NAVIGATOR = Phantom("Phantom Navigator", TokenType.INTELLIGENCE, TokenType.CHARISMA);
        public static CharacterPassive PHANTOM_NOBLE = Phantom("Phantom Noble", TokenType.CHARISMA, TokenType.LUCK);
        public static CharacterPassive PHANTOM_JESTER = Phantom("Phantom Jester", TokenType.AGILITY, TokenType.LUCK);

        #endregion PHANTOM

        #region MONKEY

        public static CharacterPassive MONKEY_JUNGLE = new CharacterPassive
        (
            name: "Monkey Jungle",
            sprite: "tokens/agi",
            tooltip: "Many, many monkeys. At the start of your turn, apply the Monkey buff to five random tokens.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                List<TokenState> tokens = encounter.boardState.GetTokens();
                tokens.Shuffle();

                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in tokens.Take(6))
                {
                    token.ApplyBuff(TargetPassive.MONKEY);
                }
                GameEffect.EndAnimationBatch();
            }
        );

        #endregion MONKEY

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

        #region TRAP_ROOM
        // spawns crew
        // random rows and cols are destroyed by trap token buffs
        // spawn trap token buffs every turn on the edges randomly
        #endregion TRAP_ROOM

        #region WARRIOR
        // cycle1: switch to cycle2 at end of turn. Destroy all cols with STR
        // cycle2: switch to cycle1 at end of turn. Destroy all rows with STR
        #endregion WARRIOR

        #region SCHOLAR
        // int
        #endregion SCHOLAR

        #region MERCHANT 
        #endregion MERCHANT

        #region FOOL
        // TILE: chain, transform all in chain to LUK. Move to the end of the chain.
        // win by high luck
        #endregion FOOL
        
        #region SCAMMER
        // apply debuff to random INT tokens
        // debuff expires at end of turn, reducing INT
        // lose by INT
        // win by AGI, LUK
        // partial win by STR
        // bonus INT
        #endregion SCAMMER

        #region MAGPIE
        // apply magpies to token, magpies swap upwards
        // steal resource if reach top, then spawn on random token
        #endregion MAGPIE

        #region REGRET
        // at the start of each turn, transform your most abundant token to another random type
        #endregion REGRET

        #region PROSTITUTE
        // -2 energy if CHA >= 70, -1 energy if CHA >= 45
        // transform STR to CHA tokens
        #endregion PROSTITUTE

        #region ANGER
        // apply enrage buff
        // destroying enrage buff transforms surrounding tokens to STR
        #endregion ANGER

        #region AMBUSH
        // spawns crew and enemy
        // enemies destroy adjacent tiles if they contain crew
        // destroying enemies gains STR
        // win by STR, lose by STR
        #endregion AMBUSH

        #region BLACK_CAT
        // if a black cat is destroyed, lose LUK and jump to another non-LUK token
        // black cat moves around, transforming adjacent LUK token into its type
        #endregion BLACK_CAT

        #endregion ENCOUNTER

        //- normie level, with "RNG movement"

        // phantom tile, steal resource nad transform adjaecnt every turn, then move

        // convert your most abundant resource to the last abundant resource
        // gain X resource at the start of the game
    }
}
