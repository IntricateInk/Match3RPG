using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill GESTURE = new GameSkill
        (
            name: "Gesture",
            sprite: "skills/bash",
            tooltip: "Transform a 3x1 block of cells to CHA.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in targets[0].GetSurrounding(-1, 0, 1, 0))
                {
                    token.PlayAnimation("spark1");
                    token.type = TokenType.CHARISMA;
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}