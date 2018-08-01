using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill RICOCHET = new GameSkill
        (
            name: "Ricochet",
            sprite: "skills/sleight",
            tooltip: "Select a token. Chain. Destroy all selected tokens.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.ChainFromFirst(encounter, targets);

                TokenState prev = null;

                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in targets)
                {
                    if (prev != null)
                        GameEffect.LineAnimation("line_grey", prev, token);
                    token.Destroy();

                    prev = token;
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}