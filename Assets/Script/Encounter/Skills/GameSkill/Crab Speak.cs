using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill CRAB_SPEAK = new GameSkill
        (
            name: "Crab Speak",
            sprite: "skills/sleight",
            tooltip: "Select a token. Apply Crab buff. At the end of each turn, Crab swaps to the left. If already at the left end, swap to the right end.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].ApplyBuff(TargetPassive.CRAB);
            }
        );
    }
}