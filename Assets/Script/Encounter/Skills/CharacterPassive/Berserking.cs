using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive BERSERKING = new CharacterPassive
        (
            name: "Berserking",
            sprite: "tokens/int",
            tooltip: "At the start of turn, gain 1 Energy if you have 30 or more STR and AGI",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                if (encounter.playerState.GetResource(TokenType.STRENGTH) >= 30 && 
                    encounter.playerState.GetResource(TokenType.AGILITY) >= 30)
                    encounter.playerState.Energy += 1;
            }
        );
    }
}