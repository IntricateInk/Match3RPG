using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive
    {
        public static TargetPassive PLAGUE = new TargetPassive
        (
            name: "Plague",
            sprite: "sprites/mole",
            tooltip: "When destroyed, spawn Zombies on all tokens in a 3x3 area around it.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].AttachAnimation("sewer_splash");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("sewer_splash");
            },

            OnDestroy: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        TokenState adj = token.GetAdjacent(dx, dy);

                        if (adj != null)
                            adj.ApplyBuff(TargetPassive.ZOMBIE);
                    }
                }
            }
        );
    }
}