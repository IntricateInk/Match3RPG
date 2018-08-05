using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill WAR_CHANT = new GameSkill
        (
            name: "War Chant",
            sprite: "icons/spirit_strong",
            tooltip: "Spawn 1 Heroic Spirit.",

            energyCost: 3,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.HEROIC_SPIRIT, 1);
            }
        );
    }
}