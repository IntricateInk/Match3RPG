using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Skill
{
    public class GameSkill_Sleight : GameSkill
    {
        public GameSkill_Sleight() : 
            base(
                name: "Sleight", 
                sprite: "skills/sleight", 
                tooltip: "Cost: 1AGI. Select two adjacent tiles and swap their positions."
                )
        { }

        internal override void Select(InputState input, TokenState token)
        {
            if (input.selectedTokens.Count == 1)
            {
                TokenState token2 = input.selectedTokens[0];

                bool isAdjX = token.x == token2.x && Mathf.Abs(token.y - token2.y) == 1;
                bool isAdjY = token.y == token2.y && Mathf.Abs(token.x - token2.x) == 1;

                if (!isAdjX && !isAdjY)
                    input.SelectToken(token2, false);
            }

            input.SelectToken(token, true);
        }

        internal override bool ShouldRun(List<TokenState> selectedToken)
        {
            return selectedToken.Count == 2;
        }

        internal override void Run(EncounterState encounter)
        {
            encounter.boardState.SwapToken(encounter.inputState.selectedTokens[0], encounter.inputState.selectedTokens[1]);
        }
    }
}
