using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive BLOODLUST = new TargetPassive
        (
            name: "Bloodlust",
            sprite: "skills/bash",
            tooltip: "When destroyed, transform all adjacent tokens into STR.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].AttachAnimation("explosion4");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("explosion4");
            },

            OnDestroy: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                GameEffect.BeginAnimationBatch();
                foreach (TokenState adj in token.GetAllAdjacent())
                {
                    adj.PlayAnimation("wave1", 0.1f);
                    adj.type = TokenType.STRENGTH;
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}
