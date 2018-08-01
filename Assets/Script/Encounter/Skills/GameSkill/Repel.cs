using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill REPEL = new GameSkill
        (
            name: "Repel",
            sprite: "skills/sleight",
            tooltip: "Select a tile. Swap all adjacent tiles away from it.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                GameEffect.BeginAnimationBatch();
                foreach (TokenState adj in token.GetAllAdjacent())
                {
                    int dx = adj.x - token.x;
                    int dy = adj.y - token.y;

                    if (adj.GetAdjacent(dx, dy) != null) adj.Swap(dx, dy);
                    adj.PlayAnimation("blast2");
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}