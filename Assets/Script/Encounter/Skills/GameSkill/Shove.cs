using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill SHOVE = new GameSkill
        (
            name: "Shove",
            sprite: "skills/bash",
            tooltip: "Select two adjacent tokens. Swap them, then destroy the second.",

            energyCost: 1,

            selectBehavior: SelectBehavior.TwoAdjacent,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState first = targets[0];
                TokenState second = targets[1];

                GameEffect.BeginAnimationBatch();
                first.PlayAnimation("stargate", 3f);
                first.Swap(second);
                GameEffect.EndAnimationBatch();
                second.PlayAnimation("explosion1", 0f);
                second.Destroy();
            }
        );
    }
}