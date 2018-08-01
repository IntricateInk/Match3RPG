using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill BASH = new GameSkill
        (
            name: "Bash",
            sprite: "skills/bash",
            tooltip: "Destroy a 3x3 block of cells.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                GameEffect.SelectSurrounding(encounter, targets);
                foreach (TokenState token in targets)
                {
                    token.PlayAnimation("spark1");
                    token.Destroy();
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}