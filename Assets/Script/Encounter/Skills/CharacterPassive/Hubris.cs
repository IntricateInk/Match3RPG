using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive HUBRIS = new CharacterPassive
        (
            name: "Hubris",
            sprite: "icons/pain",
            tooltip: "At the start of turn, lose 1 Energy if INT is greater than CHA.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                if (encounter.playerState.GetResource(TokenType.INTELLIGENCE) >
                    encounter.playerState.GetResource(TokenType.CHARISMA))
                    encounter.playerState.Energy -= 1;
            }
        );
    }
}