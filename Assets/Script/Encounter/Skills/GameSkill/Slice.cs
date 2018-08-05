using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill SLICE = new GameSkill
        (
            name: "Slice!",
            sprite: "icons/slice_2",
            tooltip: "Destroy a row of tokens.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                int y = targets[0].y;
                for (int x = 0; x < encounter.boardState.sizeY; x++)
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