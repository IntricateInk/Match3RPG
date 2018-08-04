﻿using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill FIRE_WALL = new GameSkill
        (
            name: "Fire Wall",
            sprite: "skills/sleight",
            tooltip: "Destroy a token. If it has Wildfire, destroy the entire row instead.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                if (token.Passives.Contains(TargetPassive.WILDFIRE))
                {
                    token.Destroy();
                }
                else
                {
                    foreach (TokenState row in encounter.boardState.GetTokenRow(token.x))
                        row.Destroy();
                }
            }
        );
    }
}