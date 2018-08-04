using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill ALTERNATIVE_PERSPECTIVE = new GameSkill
        (
            name: "Alternative Perspective",
            sprite: "skills/sleight",
            tooltip: "Select a token. Try to match it diagonally.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                List<TokenState> diag_left_up_to_right_down = new List<TokenState>();
                List<TokenState> diag_left_down_to_right_up = new List<TokenState>();

                TokenState next = token.GetAdjacent(-1, -1);
                while (next != null && next.type == token.type)
                {
                    diag_left_up_to_right_down.Add(next);
                    next = next.GetAdjacent(-1, -1);
                }

                next = token.GetAdjacent(1, 1);
                while (next != null && next.type == token.type)
                {
                    diag_left_up_to_right_down.Add(next);
                    next = next.GetAdjacent(1, 1);
                }

                next = token.GetAdjacent(-1, 1);
                while (next != null && next.type == token.type)
                {
                    diag_left_down_to_right_up.Add(next);
                    next = next.GetAdjacent(-1, 1);
                }

                next = token.GetAdjacent(1, -1);
                while (next != null && next.type == token.type)
                {
                    diag_left_down_to_right_up.Add(next);
                    next = next.GetAdjacent(1, -1);
                }

                GameEffect.BeginAnimationBatch();
                if (diag_left_up_to_right_down.Count >= 2)
                {
                    foreach (TokenState matched in diag_left_up_to_right_down)
                    {
                        matched.Match();
                    }
                }

                if (diag_left_down_to_right_up.Count >= 2)
                {
                    foreach (TokenState matched in diag_left_down_to_right_up)
                    {
                        matched.Match();
                    }
                }

                if (diag_left_up_to_right_down.Count >= 2 ||
                    diag_left_down_to_right_up.Count >= 2)
                {
                    token.Match();
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}