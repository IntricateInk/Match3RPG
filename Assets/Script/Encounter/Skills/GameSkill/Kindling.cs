using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill KINDLING = new GameSkill
        (
            name: "Kindling",
            sprite: "skills/sleight",
            tooltip: "Spawn 1 Flame Spirit.",

            energyCost: 3,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.FLAME_SPIRIT, 1);
            }
        );
    }
}