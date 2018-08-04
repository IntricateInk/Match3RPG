using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill CROAK = new GameSkill
        (
            name: "Croak",
            sprite: "skills/sleight",
            tooltip: "Select a token. Apply Frog buff. At the end of each turn, swaps the above token to the top of the column.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].ApplyBuff(TargetPassive.FROG);
            }
        );
    }
}