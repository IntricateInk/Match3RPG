using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive WOUND = new CharacterPassive
        (
            name: "Wound",
            sprite: "tokens/int",
            tooltip: "At the start of turn, lose 1 Energy.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                encounter.playerState.Energy -= 1;
            }
        );

    }
}