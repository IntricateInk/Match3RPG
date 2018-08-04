using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive AMNESIA = new TargetPassive
        (
            name: "Amnesia",
            sprite: "skills/bash",
            tooltip: "At the end of the turn, remove this buff and lose 4 Resource of this token's type.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].AttachAnimation("sewer_splash");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("sewer_splash");
            },

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                GameEffect.BeginAnimationBatch();
                token.PlayAnimation("wave1", 0.1f);
                token.ShowResourceGain(-4);
                encounter.playerState.GainResource(token.type, -4);
                GameEffect.EndAnimationBatch();

                token.RemoveBuff(TargetPassive.AMNESIA);
            }
        );
    }
}
