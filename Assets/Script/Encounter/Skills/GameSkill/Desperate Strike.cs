using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill DESPERATE_STRIKE = new GameSkill
        (
            name: "Desperate Strike",
            sprite: "icons/kill",
            tooltip: "Select a token. Lose all resources of that type to destroy a random token of that type.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                int amt = encounter.playerState.GetResource(token.type);

                encounter.playerState.GainResource(token.type, -amt);

                List<TokenState> tokens = encounter.boardState.GetTokens(token.type);
                tokens.Shuffle();

                GameEffect.BeginAnimationBatch();
                foreach (TokenState rand_token in tokens.Take(amt))
                {
                    rand_token.PlayAnimation("flux1");
                    rand_token.ShowResourceGain(token.type, -1);
                    rand_token.Destroy();
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}