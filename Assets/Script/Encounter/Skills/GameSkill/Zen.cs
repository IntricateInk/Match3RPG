using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill ZEN = new GameSkill
        (
            name: "Zen",
            sprite: "skills/sleight",
            tooltip: "Destroy all Blanks and gain them as random resouces.",

            energyCost: 2,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                GameEffect.BeginAnimationBatch();
                foreach (TokenState other in encounter.boardState.GetTokens())
                {
                    if (other.type == TokenType.BLANK)
                    {
                        TokenType resource = TokenTypeHelper.RandomResource();
                        other.ShowResourceGain(resource, 1);
                        encounter.playerState.GainResource(resource, 1);
                        other.Destroy();
                    }
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}