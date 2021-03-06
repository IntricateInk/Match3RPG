﻿using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill TO_ARMS = new GameSkill
        (
            name: "To Arms",
            sprite: "icons/rally",
            tooltip: "Gain (but not destroy) all STR and AGI tokens adjacent to Crew tokens.",

            energyCost: 2,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                foreach (TokenState other in encounter.boardState.GetTokens())
                {
                    if (other.Passives.Contains(TargetPassive.CREW))
                    {
                        foreach (TokenState adj in other.GetAllAdjacent())
                        {
                            if (adj.type == TokenType.STRENGTH || adj.type == TokenType.AGILITY)
                            {
                                adj.ShowResourceGain(1);
                                encounter.playerState.GainResource(adj.type, 1);
                            }
                        }
                    }
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}