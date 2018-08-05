using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive WEAK = new CharacterPassive
        (
            name: "Weak",
            sprite: "icons/weak",
            tooltip: "At the start of turn, lose 1 Energy if STR is less than 25.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                if (encounter.playerState.GetResource(TokenType.STRENGTH) <= 25)
                    encounter.playerState.Energy -= 1;
            }
        );

    }
}