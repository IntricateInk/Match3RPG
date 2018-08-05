using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill RIG = new GameSkill
        (
            name: "Rig",
            sprite: "icons/bomb_2",
            tooltip: "Select a token. Apply Reagent.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].ApplyBuff(TargetPassive.REAGENT);
            }
        );
    }
}