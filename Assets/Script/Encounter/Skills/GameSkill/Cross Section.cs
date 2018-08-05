using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill CROSS_SECTION = new GameSkill
        (
            name: "Cross Section",
            sprite: "icons/fist_3",
            tooltip: "Select a tile. Destroy it and all adjacent tokens.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                GameEffect.BeginAnimationBatch();
                foreach (TokenState adj in token.GetAllAdjacent())
                {
                    adj.Destroy();
                    adj.PlayAnimation("blast2");
                }
                token.Destroy();
                token.PlayAnimation("blast2");
                GameEffect.EndAnimationBatch();
            }
        );
    }
}