
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive UNLUCKY = new CharacterPassive
        (
            name: "Unlucky",
            sprite: "icons/unholy_wind",
            tooltip: "At the start of turn, lose 1 Energy if LUK is less than 25.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                if (encounter.playerState.GetResource(TokenType.LUCK) <= 25)
                    encounter.playerState.Energy -= 1;
            }
        );

    }
}