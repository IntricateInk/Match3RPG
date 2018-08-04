using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill SWING = new GameSkill
        (
            name: "Swing",
            sprite: "skills/bash",
            tooltip: "Swap 3 spaces to the left.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                int x = Mathf.Max(token.x - 3, 0);

                token.Swap(encounter.boardState.GetToken(x, token.y));
            }
        );
    }
}