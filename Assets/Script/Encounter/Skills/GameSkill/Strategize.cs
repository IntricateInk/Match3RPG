using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill STRATEGIZE = new GameSkill
        (
            name: "Strategize",
            sprite: "skills/sleight",
            tooltip: "Select a tile. Destroy it and gain a Resource of that type.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainSelectedAsResource(encounter, targets);
                GameEffect.DestroySelected(encounter, targets);
            }
        );
    }
}