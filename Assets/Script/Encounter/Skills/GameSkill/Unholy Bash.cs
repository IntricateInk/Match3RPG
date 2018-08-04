using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill UNHOLY_BASH = new GameSkill
        (
            name: "Unholy Bash",
            sprite: "skills/bash",
            tooltip: "Destroy a token. If it was a Zombie, destroy a 3x3 block around it instead.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                if (token.Passives.Contains(TargetPassive.ZOMBIE))
                {
                    token.Destroy();
                }
                else
                {
                    foreach (TokenState other in token.GetSurrounding(-1, -1, 1, 1))
                        other.Destroy();
                }
            }
        );
    }
}