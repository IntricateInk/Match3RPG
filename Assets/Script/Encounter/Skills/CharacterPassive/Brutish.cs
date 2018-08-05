using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive BRUTISH = new CharacterPassive
        (
            name: "Brutish",
            sprite: "icons/angry_2",
            tooltip: "At the start of turn, lose 1 Energy if STR is greater than CHA.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                if (encounter.playerState.GetResource(TokenType.STRENGTH) > 
                    encounter.playerState.GetResource(TokenType.CHARISMA))
                    encounter.playerState.Energy -= 1;
            }
        );

    }
}