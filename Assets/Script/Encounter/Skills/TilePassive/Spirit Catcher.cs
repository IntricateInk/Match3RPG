using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive SPIRIT_CATCHER = new TargetPassive
        (
            name: "Spirit Catcher",
            sprite: "skills/sleight",
            tooltip: "At the end of the turn, captures tokens with the Spirit buff, gaining 20 INT and CHA.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.AttachAnimation("beam1");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.DettachAnimation("beam1");
            }
        );

    }
}
