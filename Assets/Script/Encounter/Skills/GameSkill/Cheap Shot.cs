using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill CHEAP_SHOT = new GameSkill
        (
            name: "Cheap Shot",
            sprite: "skills/bash",
            tooltip: "Lose all STR. For each STR lost, destroy a random token.",

            energyCost: 1,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                int amt = encounter.playerState.GetResource(TokenType.STRENGTH);

                encounter.playerState.GainResource(TokenType.STRENGTH, -amt);

                List<TokenState> tokens = encounter.boardState.GetTokens();
                tokens.Shuffle();

                GameEffect.BeginAnimationBatch();
                foreach (TokenState rand_token in tokens.Take(amt))
                {
                    rand_token.PlayAnimation("flux1");
                    rand_token.ShowResourceGain(TokenType.STRENGTH, -1);
                    rand_token.Destroy();
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}