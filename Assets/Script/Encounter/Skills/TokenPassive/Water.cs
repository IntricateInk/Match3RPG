using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive WATER = new TargetPassive
        (
            name: "Water",
            sprite: "skills/bash",
            tooltip: "At the end of each turn, remove from this token and blank it, then transfer to 3 tokens below it. Dispels Wildfire",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                token.AttachAnimation("water");

                if (token.Passives.Contains(TargetPassive.WILDFIRE))
                {
                    token.RemoveBuff(TargetPassive.WATER);
                    token.RemoveBuff(TargetPassive.WILDFIRE);
                }
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("water");
            },

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                token.type = TokenType.BLANK;

                for (int dx = -1; dx <= 1; dx++)
                {
                    TokenState adj = token.GetAdjacent(dx, -1);
                    if (adj != null)
                    {
                        adj.ApplyBuff(TargetPassive.WATER);
                    }
                }

                token.RemoveBuff(TargetPassive.WATER);
            }
        );
    }
}
