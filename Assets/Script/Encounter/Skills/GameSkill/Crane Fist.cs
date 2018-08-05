using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill CRANE_FIST = new GameSkill
        (
            name: "Crane Fist",
            sprite: "icons/holy_hand",
            tooltip: "Select a token. Swap upwards 3 spaces and blank it.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                BoardState board = encounter.boardState;

                if (token.y == board.sizeY - 1) return;

                token.Swap(board.GetToken(token.x, Mathf.Max(token.y + 3, board.sizeY - 1)));
                token.type = TokenType.BLANK;
            }
        );
    }
}