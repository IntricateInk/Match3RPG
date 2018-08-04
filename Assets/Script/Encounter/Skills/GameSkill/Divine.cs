using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill DIVINE = new GameSkill
        (
            name: "Divine",
            sprite: "skills/sleight",
            tooltip: "Spawn one of the following: Spirit, Heroic Spirit, Flame Spirit, Fairy or Demon Soul.",

            energyCost: 1,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TargetPassive passive =
                    new List<TargetPassive>()
                    {
                        TargetPassive.SPIRIT,
                        TargetPassive.HEROIC_SPIRIT,
                        TargetPassive.FLAME_SPIRIT,
                        TargetPassive.FAIRY,
                        TargetPassive.DEMON_SOUL,
                    }.RandomChoice();

                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), passive, 1);
            }
        );
    }
}