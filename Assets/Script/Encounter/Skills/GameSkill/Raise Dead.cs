using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill RAISE_DEAD = new GameSkill
        (
            name: "Raise Dead",
            sprite: "icons/undead_2",
            tooltip: "Select a token. Apply Zombie.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].ApplyBuff(TargetPassive.ZOMBIE);
            }
        );
    }
}