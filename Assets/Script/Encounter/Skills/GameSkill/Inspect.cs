using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill INSPECT = new GameSkill
        (
            name: "Inspect",
            sprite: "icons/book_2",
            tooltip: "Gain resources of all tokens in a 3x3 area.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in targets[0].GetSurrounding(-1, -1, 1, 1))
                {
                    token.ShowResourceGain(1);
                    encounter.playerState.GainResource(token.type, 1);
                }

                GameEffect.EndAnimationBatch();
            }
        );
    }
}