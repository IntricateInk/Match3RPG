using Match3.Encounter.Effect.Skill;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        private static CharacterPassive DarkRoom(string name, string sprite, int crew, int trap3x3, int trap_plus)
        {
            return new CharacterPassive
            (
                name: name, sprite: sprite,
                tooltip: string.Format(
                    "A really dark room. Watch your step! At the start of the round, gain 5 AGI and spawn {0} Crew, {1} Flamethrower Trap and {2} Explosive Trap",
                    crew, trap3x3, trap_plus
                    ),

                OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
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

        public static CharacterPassive DARK_ROOM_1 = DarkRoom("Dark Room", "tokens/agi", 2, 3, 3);
        public static CharacterPassive DARK_ROOM_2 = DarkRoom("Bloodstained Dark Room", "tokens/agi", 2, 5, 5);
        public static CharacterPassive DARK_ROOM_3 = DarkRoom("Torture Chamber", "tokens/agi", 2, 7, 7);
    }

    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive FLAMETHROWER_TRAP = new TargetPassive
        (
            name: "Flamethrower Trap",
            sprite: "skills/bash",
            tooltip: "If the token is destroyed, destroy all other tokens in the row and column.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.AttachAnimation("dust3");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.DettachAnimation("dust3");
            },

            OnDestroy: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                List<TokenState> row = encounter.boardState.GetRow(token.x);
                List<TokenState> col = encounter.boardState.GetCol(token.y);

                row.AddRange(col);

                GameEffect.BeginAnimationBatch();

                foreach (TokenState other in row)
                {
                    if (other == token) continue;

                    other.PlayAnimation("fire2");
                    other.Destroy();
                }

                GameEffect.EndAnimationBatch();
            }
        );
        
        public static TargetPassive EXPLOSIVE_TRAP = new TargetPassive
        (
            name: "Explosive Trap",
            sprite: "skills/bash",
            tooltip: "If the token is destroyed, destroy all other tokens in a 3 by 3 grid around it.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.AttachAnimation("dust2");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.DettachAnimation("dust2");
            },

            OnDestroy: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                GameEffect.BeginAnimationBatch();
                for (int dx = -1; dx < 1; dx++)
                {
                    for (int dy = -1; dy < 1; dy++)
                    {
                        TokenState other = token.GetAdjacent(dx, dy);

                        if (other != null && other != token)
                        {
                            other.PlayAnimation("fire2");
                            other.Destroy();
                        }
                    }
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}