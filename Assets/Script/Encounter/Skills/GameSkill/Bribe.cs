using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill BRIBE = new GameSkill
        (
            name: "Bribe",
            sprite: "tokens/cha",
            tooltip: "Select a token. Pay a resource of that type to destroy it.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                if (encounter.playerState.GetResource(token.type) >= 1)
                {
                    encounter.playerState.GainResource(token.type, -1);
                    GameEffect.BeginAnimationBatch();
                    token.PlayAnimation("flux1");
                    token.ShowResourceGain(-1);
                    token.Destroy();
                    GameEffect.EndAnimationBatch();
                }
            }
        );
    }
}