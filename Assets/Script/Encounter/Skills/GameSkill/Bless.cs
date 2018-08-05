using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill Bless = new GameSkill
        (
            name: "Bless",
            sprite: "icons/fairy",
            tooltip: "Spawn 1 Fairy.",

            energyCost: 3,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.FAIRY, 1);
            }
        );
    }
}