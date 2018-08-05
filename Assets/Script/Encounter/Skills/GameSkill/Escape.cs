using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill ESCAPE = new GameSkill
        (
            name: "Escape",
            sprite: "icons/boot_2",
            tooltip: "Swap any two tokens.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Two,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].Swap(targets[1]);
            }
        );
    }
}