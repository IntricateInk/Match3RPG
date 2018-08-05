using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill PART_OF_THE_PLAN = new GameSkill
        (
            name: "Part of the Plan",
            sprite: "icons/plan",
            tooltip: "Try to match all tokens.",

            energyCost: 1,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                encounter.boardState.DoMatch();
            }
        );
    }
}