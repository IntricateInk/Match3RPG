using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill PILLAR_OF_FIRE = new GameSkill
        (
            name: "Pillar of Fire",
            sprite: "icons/fire_pillar",
            tooltip: "Destroy a token. If it has Wildfire, destroy the entire column instead.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                if (token.Passives.Contains(TargetPassive.WILDFIRE))
                {
                    token.Destroy();
                } else
                {
                    foreach (TokenState col in encounter.boardState.GetTokenCol(token.x))
                        col.Destroy();
                }
            }
        );
    }
}