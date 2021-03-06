﻿using Match3.Encounter.Effect.Skill;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        private static CharacterPassive DarkRoom(string name, string sprite, int crew, int trap3x3, int trap_plus, int reagent)
        {
            return new CharacterPassive
            (
                name: name, sprite: sprite,
                tooltip: string.Format(
                    "A really dark room. Watch your step! At the start of the round, gain 30 AGI and spawn {0} Crew, {1} Flamethrower Trap and {2} Explosive Trap. At the start of each turn, spawn {3} Reagent.",
                    crew, trap3x3, trap_plus, reagent
                    ),

                OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    encounter.playerState.GainResource(TokenType.AGILITY, 30);

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
                },
                
                OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    List<TokenState> tokens = encounter.boardState.GetTokens();
                    tokens.Shuffle();

                    GameEffect.BeginAnimationBatch();

                    foreach (TokenState token in tokens.Take(reagent))
                    {
                        token.ApplyBuff(TargetPassive.REAGENT);
                    }
                    
                    GameEffect.EndAnimationBatch();
                }
            );


        }

        public static CharacterPassive DARK_ROOM_1 = DarkRoom("Dark Room", "icons/ambush", 2, 3, 3, 3);
        public static CharacterPassive DARK_ROOM_2 = DarkRoom("Bloodstained Dark Room", "icons/ambush", 2, 5, 5, 3);
        public static CharacterPassive DARK_ROOM_3 = DarkRoom("Torture Chamber", "icons/ambush", 2, 7, 7, 3);
    }
}