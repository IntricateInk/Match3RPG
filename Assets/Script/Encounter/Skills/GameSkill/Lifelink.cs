﻿using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill LIFELINK = new GameSkill
        (
            name: "Lifelink",
            sprite: "icons/unholy_grip",
            tooltip: "Destroy a token. Chain to Zombies and destroy them. Gain 1 Energy for every two tokens destroyed.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                List<TokenState> tokens = GameEffect.Chain(token, TargetPassive.ZOMBIE);

                encounter.playerState.Energy += tokens.Count / 2;
                
                foreach (TokenState other in tokens)
                {
                    other.PlayAnimation("heartbeat", 0.1f);
                    other.Destroy();
                }
            }
        );
    }
}