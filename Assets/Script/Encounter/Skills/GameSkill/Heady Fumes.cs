using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill HEADY_FUMES = new GameSkill
        (
            name: "Heady Fumes",
            sprite: "icons/dust_1",
            tooltip: "Rotate other tokens in a 3x3 area around this token clockwise.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                TokenState t00 = token.GetAdjacent(-1, -1);
                TokenState t10 = token.GetAdjacent(-1, 0);
                TokenState t20 = token.GetAdjacent(-1, 1);
                TokenState t21 = token.GetAdjacent(0, 1);

                TokenState t22 = token.GetAdjacent(1, 1);
                TokenState t12 = token.GetAdjacent(1, 0);
                TokenState t02 = token.GetAdjacent(1, -1);
                TokenState t01 = token.GetAdjacent(0, -1);

                GameEffect.BeginAnimationBatch();
                if (t00 != null) t00.SetPositionRelative(0, 1);
                if (t10 != null) t10.SetPositionRelative(0, 1);
                if (t20 != null) t20.SetPositionRelative(1, 0);
                if (t21 != null) t21.SetPositionRelative(1, 0);

                if (t22 != null) t22.SetPositionRelative(0, -1);
                if (t12 != null) t12.SetPositionRelative(0, -1);
                if (t02 != null) t02.SetPositionRelative(-1, 0);
                if (t01 != null) t01.SetPositionRelative(-1, 0);
                GameEffect.EndAnimationBatch();
            }
        );
    }
}