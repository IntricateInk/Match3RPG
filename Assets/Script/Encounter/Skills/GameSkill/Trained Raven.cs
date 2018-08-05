using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill TRAINED_RAVEN = new GameSkill
        (
            name: "Trained Raven",
            sprite: "icons/raven",
            tooltip: "Select a token. Apply Raven. At the end of the turn, Raven swaps to the top, then moves to another token.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].ApplyBuff(TargetPassive.RAVEN);
            }
        );
    }
}