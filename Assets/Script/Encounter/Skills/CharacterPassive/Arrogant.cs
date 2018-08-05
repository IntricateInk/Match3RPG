using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive ARROGANT = new CharacterPassive
        (
            name: "Arrogant",
            sprite: "icons/focus_3",
            tooltip: "At the start of turn, lose 1 Energy if INT is greater than STR.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                if (encounter.playerState.GetResource(TokenType.INTELLIGENCE) >
                    encounter.playerState.GetResource(TokenType.STRENGTH))
                    encounter.playerState.Energy -= 1;
            }
        );
    }
}