using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill SLEIGHT = new GameSkill
        (
            name: "Sleight",
            sprite: "icons/afterimage",
            tooltip: "Select two adjacent tiles and swap their positions.",

            energyCost: 2,

            selectBehavior: SelectBehavior.TwoAdjacent,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                targets[0].Swap(targets[1]);
                targets[0].PlayAnimation("stargate", normalized_size: 3f);
                targets[1].PlayAnimation("stargate", normalized_size: 3f);
                GameEffect.EndAnimationBatch();
            }
        );
    }
}