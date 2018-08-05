using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive LETHARGIC = new CharacterPassive
        (
            name: "Lethargic",
            sprite: "icons/sad",
            tooltip: "At the start of turn, lose 1 Energy if AGI is less than 25.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                if (encounter.playerState.GetResource(TokenType.AGILITY) <= 25)
                    encounter.playerState.Energy -= 1;
            }
        );

    }
}