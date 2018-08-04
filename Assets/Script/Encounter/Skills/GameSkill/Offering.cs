using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill OFFERING = new GameSkill
        (
            name: "Offering",
            sprite: "skills/sleight",
            tooltip: "Spawn a Spirit Catcher.",

            energyCost: 4,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTileBuff(encounter.boardState.tiles.Flatten(), 
                    TargetPassive.SPIRIT_CATCHER, 1);
            }
        );
    }
}