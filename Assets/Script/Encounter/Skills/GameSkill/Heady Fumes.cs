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

                GameEffect.LoopSwap(
                    encounter.boardState.GetTileBox(token.x - 1, token.y - 1, token.x + 1, token.y + 1));
            }
        );
    }
}