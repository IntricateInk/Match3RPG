using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill LUCKY_FIND = new GameSkill
        (
            name: "Lucky Find",
            sprite: "skills/sleight",
            tooltip: "Gain a random Resource.",

            energyCost: 1,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainRandomResource(encounter, targets, 1);
            }
        );
    }
}