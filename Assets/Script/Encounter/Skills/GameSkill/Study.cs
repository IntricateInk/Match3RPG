using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill STUDY = new GameSkill
        (
            name: "Study",
            sprite: "icons/book_1",
            tooltip: "Gain resources of all tokens in a row.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in encounter.boardState.GetTokenRow(targets[0].y))
                {
                    token.ShowResourceGain(1);
                    encounter.playerState.GainResource(token.type, 1);
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}