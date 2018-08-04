using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill MARK = new GameSkill
        (
            name: "Mark",
            sprite: "skills/bash",
            tooltip: "Apply Marked.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                token.ApplyBuff(TargetPassive.MARKED);
            }
        );
    }
}