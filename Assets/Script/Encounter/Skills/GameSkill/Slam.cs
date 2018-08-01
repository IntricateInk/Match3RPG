using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill SLAM = new GameSkill
        (
            name: "Slam",
            sprite: "skills/sleight",
            tooltip: "Select a token. Destroy all tokens below it.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                
                GameEffect.BeginAnimationBatch();
                for (int y = token.y - 1; y >= 0; y--)
                {
                    TokenState below = encounter.boardState.GetToken(token.x, y);

                    below.PlayAnimation("blast1");
                    below.Destroy();
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}