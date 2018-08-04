using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill COMMAND_MONKEYS = new GameSkill
        (
            name: "Command Monkeys",
            sprite: "skills/sleight",
            tooltip: "Select a 3x3 area and spawn 3 Monkeys.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(targets[0].GetSurrounding(-1, -1, 1, 1), TargetPassive.MONKEY, 3);
            }
        );
    }
}