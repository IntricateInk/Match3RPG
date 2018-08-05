using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill SOCIALIZE = new GameSkill
        (
            name: "Socialize",
            sprite: "icons/smile",
            tooltip: "Select a tile. Gain a Resource of that type.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                encounter.playerState.GainResource(targets[0].type, 1);
                targets[0].ShowResourceGain(1);
            }
        );
    }
}