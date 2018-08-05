using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill LIFT = new GameSkill
        (
            name: "Lift",
            sprite: "icons/fist_5",
            tooltip: "Select a token. Swap it and the tokens on its left and right 3 rows above. If they are already at the top row, destroy them instead.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                List<TokenState> tokens = new List<TokenState>();

                int y = targets[0].y;

                tokens.Add(targets[0]);
                if (targets[0].GetAdjacent(-1, 0) != null) tokens.Add(targets[0].GetAdjacent(-1, 0));
                if (targets[0].GetAdjacent(1, 0) != null) tokens.Add(targets[0].GetAdjacent(1, 0));

                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in tokens)
                {
                    if (y == encounter.boardState.sizeY - 1)
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
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}