using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill CHOP = new GameSkill
        (
            name: "Chop!",
            sprite: "icons/slice_2",
            tooltip: "Destroy a column of tokens.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                int x = targets[0].x;
                for (int y = 0; y < encounter.boardState.sizeY; y++)
                {
                    TokenState token = encounter.boardState.GetToken(x, y);
                    token.PlayAnimation("spark1");
                    token.Destroy();
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}