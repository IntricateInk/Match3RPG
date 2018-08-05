using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill UPPERCUT = new GameSkill
        (
            name: "Uppercut",
            sprite: "icons/fist_2",
            tooltip: "Select a token. Swap it 3 rowws up. If it was already at the top, destroy it instead.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                GameEffect.BeginAnimationBatch();
                if (token.y == encounter.boardState.sizeY - 1)
                {
                    token.PlayAnimation("blast1");
                    token.Destroy();
                }
                else
                {
                    TokenState above = token.GetAdjacent(0, 3);

                    if (above == null)
                        above = encounter.boardState.GetToken(token.x, encounter.boardState.sizeY - 1);

                    token.PlayAnimation("stargate", normalized_size: 2f);
                    token.Swap(above);
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}