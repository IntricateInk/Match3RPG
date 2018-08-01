using Match3.Encounter.Effect.Skill;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        private static CharacterPassive SpikedHole(string name, string sprite, int crew, int spike1, int spike2)
        {
            return new CharacterPassive
            (
                name: name,
                sprite: sprite,
                tooltip: string.Format(
                    "A deep, dark, slippery hole. At the start of the encounter, gain 30 STR and spawn {0} Crew. At the end of each turn, destroy the bottom tile of {1} rows randomly, then destroy the bottom 2 tiles of {2} rows randomly.",
                    crew, spike1, spike2
                ),

                OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    encounter.playerState.GainResource(TokenType.STRENGTH, 30);

                    List<TokenState> top_3_rows = encounter.boardState.GetTokenRow(-1, -2, -3);

                    GameEffect.BeginAnimationBatch();
                    foreach (TokenState token in top_3_rows.RandomChoice(crew))
                    {
                        token.ApplyBuff(TargetPassive.CREW);
                    }
                    GameEffect.EndAnimationBatch();
                },

                OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    List<int> col_idx = new List<int>();
                    col_idx.AddRange(Enumerable.Range(0, encounter.boardState.sizeX));
                    col_idx.Shuffle();

                    GameEffect.BeginAnimationBatch();

                    foreach (int y in col_idx.Take(spike1))
                    {
                        TokenState token = encounter.boardState.tiles[y, 0].token;
                        token.PlayAnimation("dust1");
                        token.Destroy();
                    }

                    col_idx.RemoveRange(0, spike1);

                    foreach (int y in col_idx.Take(spike2))
                    {
                        TokenState token = encounter.boardState.tiles[y, 0].token;
                        token.PlayAnimation("dust1");
                        token.Destroy();

                        token = encounter.boardState.tiles[y, 1].token;
                        token.PlayAnimation("dust1");
                        token.Destroy();
                    }

                    GameEffect.EndAnimationBatch();
                }
            );
        }

        public static CharacterPassive SPIKED_HOLE_1 = SpikedHole("Hidden Trap", "skills/sleight", 1, 2, 2);
        public static CharacterPassive SPIKED_HOLE_2 = SpikedHole("Covered Pit", "skills/sleight", 3, 4, 2);
        public static CharacterPassive SPIKED_HOLE_3 = SpikedHole("Death Trap", "skills/sleight", 5, 2, 6);
    }
    
}