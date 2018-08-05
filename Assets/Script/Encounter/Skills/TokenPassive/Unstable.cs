using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive UNSTABLE = new TargetPassive
        (
            name: "Unstable",
            sprite: "skills/bash",
            tooltip: "When destroyed, Cascade.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].AttachAnimation("flux2");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("flux2");
            },

            OnDestroy: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.Cascade(encounter);
            }
        );
    }
}
