using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill ENGINEER_EXPLOSIVE_TRAP = new GameSkill
        (
            name: "Set Explosive Trap",
            sprite: "tokens/int",
            tooltip: "Place a Explosive Trap on the target tile.",

            energyCost: 4,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].ApplyBuff(TargetPassive.EXPLOSIVE_TRAP);
            }
        );
    }
}