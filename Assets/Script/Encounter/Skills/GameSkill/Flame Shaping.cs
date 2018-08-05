using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill FLAME_SHAPING = new GameSkill
        (
            name: "Flame Shaping",
            sprite: "icons/fire_face",
            tooltip: "Transform all tokens with Wildfire to the type of the selected token.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                foreach (TokenState other in encounter.boardState.GetTokens())
                {
                    if (other.Passives.Contains(TargetPassive.WILDFIRE))
                        other.type = token.type;
                }
            }
        );
    }
}