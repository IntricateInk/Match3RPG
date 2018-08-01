﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill INSPECT = new GameSkill
        (
            name: "Inspect",
            sprite: "tokens/int",
            tooltip: "Gain resources of all tokens in a 3x3 area.",

            energyCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SelectSurrounding(encounter, targets);

                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in targets)
                {
                    token.ShowResourceGain(1);
                    encounter.playerState.GainResource(token.type, 1);
                }

                GameEffect.EndAnimationBatch();
            }
        );
    }
}