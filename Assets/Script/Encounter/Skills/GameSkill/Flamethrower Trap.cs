using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill ENGINEER_FLAMETHROWER_TRAP = new GameSkill
        (
            name: "Set Flamethrower Trap",
            sprite: "icons/part_1",
            tooltip: "Place a Flamethrower Trap on the target tile.",

            energyCost: 4,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].ApplyBuff(TargetPassive.FLAMETHROWER_TRAP);
            }
        );
    }
}