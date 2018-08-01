using Match3.Encounter.Effect.Skill;
using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        // cycle1: destroy 3x3 around all AGI tokens at the end of each turn
        // cycle2: transform X tokens to AGI at the end of each turn
        
        private static CharacterPassive RANGER_DASH_1 = new CharacterPassive
        (
            name: "Ranger - Dash",
            sprite: "skills/sleight",
            tooltip: "Move! At the start of the turn, spawn 6 Marked and spawn 1 Crew. At the end of the turn, switch to Arrow mode.",
            
            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                List<TokenState> tokens = encounter.boardState.GetTokensExcluding(TokenType.AGILITY);
                tokens.Shuffle();
                int transformed = 6;
                TokenState prev = null;

                foreach (TokenState token in tokens)
                {
                    GameEffect.BeginSequence();
                    if (prev == null)
                    {
                        GameEffect.LerpAnimation("tokens/agi", 1500f, RANGER_DASH_1.AsIPosition(), token.AsIPosition());
                    }
                    else
                    {
                        GameEffect.LerpAnimation("tokens/agi", 1500f, prev.AsIPosition(), token.AsIPosition());
                    }
                    prev = token;
                    token.PlayAnimation("wave1", 0f);
                    GameEffect.EndSequence();
                    token.ApplyBuff(TargetPassive.MARKED);

                    transformed -= 1;
                    if (transformed == 0) break;
                }
                GameEffect.LerpAnimation("tokens/agi", 1500f, prev.AsIPosition(), RANGER_DASH_1.AsIPosition());

                TokenState crew = encounter.boardState.GetTokensExcluding(TokenType.AGILITY).RandomChoice();
                crew.ApplyBuff(TargetPassive.CREW);
            },
            
            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                encounter.playerState.ApplyBuff(CharacterPassive.RANGER_ARROW_1);
                encounter.playerState.RemoveBuff(CharacterPassive.RANGER_DASH_1);
            }
        );

        private static CharacterPassive RANGER_ARROW_1 = new CharacterPassive
        (
            name: "Ranger - Arrow",
            sprite: "skills/sleight",
            tooltip: "Shoot! At the end of the turn, destroy all AGI and their adjacent tokens, then switch to Dash mode.",

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in encounter.boardState.GetTokens(TokenType.AGILITY))
                {
                    List<TokenState> adjs = token.GetAllAdjacent();
                    adjs.Add(token);
                    
                    foreach (TokenState adj in adjs)
                    {
                        GameEffect.BeginSequence();
                        GameEffect.LerpAnimation("sprites/arrow", 1200f, RANGER_ARROW_1.AsIPosition(), adj.AsIPosition());
                        adj.PlayAnimation("blood_spray3");
                        adj.Destroy();
                        GameEffect.EndSequence();
                    }
                }
                GameEffect.EndAnimationBatch();

                encounter.playerState.ApplyBuff (CharacterPassive.RANGER_DASH_1);
                encounter.playerState.RemoveBuff(CharacterPassive.RANGER_ARROW_1);
            }
        );
    }
}