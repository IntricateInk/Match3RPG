using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill KILL_COMMAND = new GameSkill
        (
            name: "Kill Command",
            sprite: "skills/sleight",
            tooltip: "Destroy all tokens adjacent to Crew tokens.",

            energyCost: 2,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                GameEffect.BeginAnimationBatch();
                foreach (TokenState other in encounter.boardState.GetTokens())
                {
                    if (other.Passives.Contains(TargetPassive.CREW))
                    {
                        foreach (TokenState adj in other.GetAllAdjacent())
                        {
                            if (adj.type == TokenType.STRENGTH || adj.type == TokenType.AGILITY)
                            {
                                adj.Destroy();
                            }
                        }
                    }
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}