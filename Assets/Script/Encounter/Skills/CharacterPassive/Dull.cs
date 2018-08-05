using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive DULL = new CharacterPassive
        (
            name: "Dull",
            sprite: "icons/charm",
            tooltip: "At the start of turn, lose 1 Energy if STR is greater than INT.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                if (encounter.playerState.GetResource(TokenType.STRENGTH) >
                    encounter.playerState.GetResource(TokenType.INTELLIGENCE))
                    encounter.playerState.Energy -= 1;
            }
        );
    }
}