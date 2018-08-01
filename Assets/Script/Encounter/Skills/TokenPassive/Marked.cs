using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive MARKED = new TargetPassive
        (
            name: "Marked",
            sprite: "skills/bash",
            tooltip: "At the end of the turn, removes itself and transform all adjacent (but not itself) tokens into AGI.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].AttachAnimation("mark");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("mark");
            },

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                GameEffect.BeginAnimationBatch();
                foreach (TokenState adj in token.GetAllAdjacent())
                {
                    adj.PlayAnimation("wave1", 0.1f);
                    adj.type = TokenType.AGILITY;
                }
                GameEffect.EndAnimationBatch();

                token.RemoveBuff(TargetPassive.MARKED);
            }
        );
    }
}
