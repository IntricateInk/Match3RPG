using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill PROFILE = new GameSkill
        (
            name: "Profile",
            sprite: "tokens/int",
            tooltip: "Gain resources of all tokens in a column.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in encounter.boardState.GetTokenCol(targets[0].x))
                {
                    token.ShowResourceGain(1);
                    encounter.playerState.GainResource(token.type, 1);
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}