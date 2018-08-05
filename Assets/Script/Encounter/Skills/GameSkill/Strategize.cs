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
            sprite: "icons/focus",
            tooltip: "Select a tile. Destroy it and gain a Resource of that type.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                encounter.playerState.GainResource(token.type, 1);
                token.ShowResourceGain(1);
                token.Destroy();
            }
        );
    }
}