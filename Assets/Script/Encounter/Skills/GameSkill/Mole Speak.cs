using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill MOLE_SPEAK = new GameSkill
        (
            name: "Mole Speak",
            sprite: "icons/speak",
            tooltip: "Select a token. Apply Mole buff. At the end of each turn, Mole destroys the bottom 3 tokens. If already at the bottom, you lose 5 STR instead.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].ApplyBuff(TargetPassive.MOLE);
            }
        );
    }
}