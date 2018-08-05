using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill NITRO = new GameSkill
        (
            name: "Nitro",
            sprite: "icons/bomb_1",
            tooltip: "Select a token. Swap to the top and apply Brimstone.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                BoardState board = encounter.boardState; 

                token.Swap(board.GetToken(token.x, board.sizeY-1));
                token.ApplyBuff(TargetPassive.BRIMSTONE);
            }
        );
    }
}