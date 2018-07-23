using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
            
            OnTurnStart: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.STRENGTH, 1);
            }
        );

        public static CharacterPassive AGILE = new CharacterPassive
        (
            name: "Agile",
            sprite: "tokens/agi",
            tooltip: "Gain 1 Agility at the start of each turn.",

            OnTurnStart: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.AGILITY, 1);
            }
        );

        public static CharacterPassive INTELLIGENT = new CharacterPassive
        (
            name: "Intelligent",
            sprite: "tokens/int",
            tooltip: "Gain 1 Intelligence at the start of each turn.",

            OnTurnStart: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.INTELLIGENCE, 1);
            }
        );

        public static CharacterPassive CHARISMATIC = new CharacterPassive
        (
            name: "Charismatic",
            sprite: "tokens/cha",
            tooltip: "Gain 1 Charisma at the start of each turn.",

            OnTurnStart: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.CHARISMA, 1);
            }
        );

        public static CharacterPassive LUCKY = new CharacterPassive
        (
            name: "Lucky",
            sprite: "tokens/luk",
            tooltip: "Gain 1 Luck at the start of each turn.",

            OnTurnStart: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.LUCK, 1);
            }
        );

        #endregion CHARACTER

        // +1 energy at start of turn
        // -1 energy at start of turn
        // lose X resource every X turns
        // timer based effect?
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

                OnTurnStart: (EncounterState encounter, List<TokenState> targets) =>
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
        public static CharacterPassive PHANTOM_SWINDLER  = Phantom("Phantom Swindler", TokenType.AGILITY, TokenType.INTELLIGENCE);
        public static CharacterPassive PHANTOM_NAVIGATOR = Phantom("Phantom Navigator", TokenType.INTELLIGENCE, TokenType.CHARISMA);
        public static CharacterPassive PHANTOM_NOBLE     = Phantom("Phantom Noble", TokenType.CHARISMA, TokenType.LUCK);
        public static CharacterPassive PHANTOM_JESTER    = Phantom("Phantom Jester", TokenType.AGILITY, TokenType.LUCK);

        #endregion PHANTOM

        #region MONKEY

        public static CharacterPassive MONKEY_JUNGLE = new CharacterPassive
        (
            name: "Monkey Jungle",
            sprite: "tokens/agi",
            tooltip: "Many, many monkeys. At the start of your turn, apply the Monkey buff to five random tokens.",

            OnTurnStart: (EncounterState encounter, List<TokenState> targets) =>
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

                OnApplyPassive: (EncounterState encounter, List<TokenState> targets) =>
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

        public static CharacterPassive WILDFIRE_1 = Wildfire("Small Forest Fire!"  , "tokens/agi", 2, 4);
        public static CharacterPassive WILDFIRE_2 = Wildfire("Forest Fire!"        , "tokens/agi", 3, 5);
        public static CharacterPassive WILDFIRE_3 = Wildfire("Blazing Forest Fire!", "tokens/agi", 3, 8);

        #endregion WILDFIRE

        #region SPIKED_HOLE
        // spawns crew
        // random tiles at the bottom are destroyed
        // survive X turns
        // lose if run out of AGI or STR
        #endregion SPIKED_HOLE

        #region TRAP_ROOM
        // spawns crew
        // random rows and cols are destroyed by trap token buffs
        // spawn trap token buffs every turn on the edges randomly
        #endregion TRAP_ROOM

        #region DARK_ROOM

        private static CharacterPassive DarkRoom(string name, string sprite, int crew, int trap3x3, int trap_plus)
        {
            return new CharacterPassive
            (
                name: name, sprite: sprite,
                tooltip: string.Format(
                    "A really dark room. Watch your step! At the start of the round, gain 5 AGI and spawn {0} Crew, {1} Flamethrower Trap and {2} Explosive Trap", 
                    crew, trap3x3, trap_plus
                    ),

                OnApplyPassive: (EncounterState encounter, List<TokenState> targets) =>
                {
                    encounter.playerState.GainResource(TokenType.AGILITY, 5);

                    List<TokenState> tokens = encounter.boardState.GetTokens();
                    tokens.Shuffle();

                    GameEffect.BeginAnimationBatch();

                    foreach (TokenState token in tokens.Take(crew))
                    {
                        token.ApplyBuff(TargetPassive.CREW);
                    }

                    tokens.RemoveRange(0, crew);

                    foreach (TokenState token in tokens.Take(trap3x3))
                    {
                        token.tile.ApplyBuff(TargetPassive.EXPLOSIVE_TRAP);
                    }

                    tokens.RemoveRange(0, trap3x3);

                    foreach (TokenState token in tokens.Take(trap_plus))
                    {
                        token.tile.ApplyBuff(TargetPassive.FLAMETHROWER_TRAP);
                    }

                    GameEffect.EndAnimationBatch();
                }
            );
        }

        public static CharacterPassive DARK_ROOM_1 = DarkRoom("Dark Room"             , "tokens/agi", 2, 3, 3);
        public static CharacterPassive DARK_ROOM_2 = DarkRoom("Bloodstained Dark Room", "tokens/agi", 2, 5, 5);
        public static CharacterPassive DARK_ROOM_3 = DarkRoom("Torture Chamber"       , "tokens/agi", 2, 7, 7);

        #endregion DARK_ROOM
        
        #region DROWNING
        // objective: survive X turns? Or gain X resource
        // Crew with Drowning debuff
        // Drowning destroys token if below X row at the end of turn. Drop 1 row every turn at the start of turn
        // at the start of each turn, random non-Crew tiles get swapped upwards
        #endregion DROWNING

        #region SCAMMER
        //- Scammer Encounter(randomly transform non-INT non-LUK tiles to LUK, loss by turn, win by HIGH luk or moderate INT)
        #endregion SCAMMER

        #region RAVEN
        //- Raven encounter(raven buffs, jumps to top when destroyed, swaps with a nearby tile of same type below?)
        #endregion RAVEN
        
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

        // spikes that destroy tiles at the bottom randomly at the end of the turn
        // convert your most abundant resource to the last abundant resource
        // gain X resource at the start of the game
    }
}
