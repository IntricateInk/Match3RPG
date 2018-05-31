using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Game.Skill
{
    public class GameSkill_Bash : GameSkill
    {
        public GameSkill_Bash() : 
            base(
                name: "Bash", 
                sprite: "skills/bash", 
                tooltip: "Cost: 1STR. Destroy a 3x3 block of cells."
                )
        {
        }

        internal override void Run(EncounterState encounter)
        {
            TokenState token = encounter.inputState.selectedTokens[0];

            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    int x = token.x + i;
                    int y = token.y + j;

                    if (x < 0 || y < 0 || x >= encounter.boardState.sizeX || x >= encounter.boardState.sizeY)
                        continue;

                    encounter.boardState.Remove(x, y);
                }
        }

        internal override void Select(InputState input, TokenState token)
        {
            input.SelectToken(token, true);
        }

        internal override bool ShouldRun(List<TokenState> selectedToken)
        {
            return selectedToken.Count == 1;
        }
    }
}