using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive
    {
        public static TargetPassive REAGENT = new TargetPassive
        (
            name: "Reagent",
            sprite: "sprites/mole",
            tooltip: "When destroyed, swap all adjacent tokens 3 spaces away.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].AttachAnimation("plasma");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("plasma");
            },

            OnDestroy: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                GameEffect.BeginAnimationBatch();
                foreach (TokenState adj in token.GetAllAdjacent())
                {
                    int dx = 3 * (adj.x - token.x);
                    int dy = 3 * (adj.y - token.y);

                    int other_x = Mathf.Clamp(adj.x + dx, 0, encounter.boardState.sizeX - 1);
                    int other_y = Mathf.Clamp(adj.y + dy, 0, encounter.boardState.sizeY - 1);

                    TokenState other = encounter.boardState.GetToken(other_x, other_y);

                    if (other != adj && other != null) adj.Swap(other);
                    adj.PlayAnimation("blast2");
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}