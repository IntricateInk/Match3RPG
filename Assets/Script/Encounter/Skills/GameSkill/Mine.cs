using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill MINE = new GameSkill
        (
            name: "Mine",
            sprite: "icons/burrow",
            tooltip: "Select a tile. Apply a buff that gains 1 Resource of that tile type at the start of each turn.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.ApplyTileBuff(encounter, targets, TargetPassive.MINER_DRONE);
            }
        );
    }
}