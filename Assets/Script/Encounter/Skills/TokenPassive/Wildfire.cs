using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive WILDFIRE = new TargetPassive
        (
            name: "Wildfire",
            sprite: "icons/fire_2",
            tooltip: "At the end of each turn, destroy this token and spread to adjacent tokens. Dispels Water.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                token.AttachAnimation("explosion1");

                if (token.Passives.Contains(TargetPassive.WATER))
                {
                    token.RemoveBuff(TargetPassive.WATER);
                    token.RemoveBuff(TargetPassive.WILDFIRE);
                }
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("explosion1");
            },

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                foreach (TokenState adj in token.GetAllAdjacent())
                {
                    adj.ApplyBuff(TargetPassive.WILDFIRE);
                }

                token.Destroy();
            }
        );
    }
}
