using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill PACT = new GameSkill
        (
            name: "Pact",
            sprite: "icons/chakra_red",
            tooltip: "Spawn 1 Demon Soul.",

            energyCost: 3,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.DEMON_SOUL, 1);
            }
        );
    }
}