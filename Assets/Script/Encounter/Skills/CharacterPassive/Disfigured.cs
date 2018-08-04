using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive DISFIGURED = new CharacterPassive
        (
            name: "Disfirgued",
            sprite: "tokens/int",
            tooltip: "At the start of turn, lose 1 Energy if CHA is less than 25.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                if (encounter.playerState.GetResource(TokenType.CHARISMA) <= 25)
                    encounter.playerState.Energy -= 1;
            }
        );

    }
}