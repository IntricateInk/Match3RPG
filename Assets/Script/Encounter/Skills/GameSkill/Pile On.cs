using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill PILE_ON = new GameSkill
        (
            name: "Pile On",
            sprite: "icons/recruit",
            tooltip: "Spawn Crew.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].ApplyBuff(TargetPassive.CREW);
            }
        );
    }
}