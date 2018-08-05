using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill DEATH_PULSE = new GameSkill
        (
            name: "Death Pulse",
            sprite: "icons/poison_1",
            tooltip: "Spawn 2 Plague.",

            energyCost: 2,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(),
                    TargetPassive.PLAGUE, 2);
            }
        );
    }
}