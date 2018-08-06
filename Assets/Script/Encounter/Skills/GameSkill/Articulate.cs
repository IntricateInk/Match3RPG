using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill ARTICULATE = new GameSkill
        (
            name: "Articulate",
            sprite: "icons/whisper",
            tooltip: "Transform a 1x3 block of cells to CHA.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in targets[0].GetSurrounding(0, -1, 0, 1))
                {
                    token.PlayAnimation("spark1");
                    token.type = TokenType.CHARISMA;
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}