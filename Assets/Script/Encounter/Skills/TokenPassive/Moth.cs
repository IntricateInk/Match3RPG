using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive
    {
        public static TargetPassive MOTH = new TargetPassive
        (
            name: "MOTH",
            sprite: "sprites/mole",
            tooltip: "At the end of the turn, swap all adjacent tokens away.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].AttachAnimation("glare");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("glare");
            },

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                GameEffect.BeginAnimationBatch();
                foreach (TokenState adj in token.GetAllAdjacent())
                {
                    int dx = adj.x - token.x;
                    int dy = adj.y - token.y;

                    if (adj.GetAdjacent(dx, dy) != null) adj.Swap(dx, dy);
                    adj.PlayAnimation("blast2");
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}