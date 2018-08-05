using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill MOTH_SPEAK = new GameSkill
        (
            name: "Moth Speak",
            sprite: "icons/glare",
            tooltip: "Select a token. Apply Moth buff. At the end of each turn, Moth repels all adjacent tokens.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].ApplyBuff(TargetPassive.MOTH);
            }
        );
    }
}