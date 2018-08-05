using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive PLANNED = new CharacterPassive
        (
            name: "Planned",
            sprite: "icons/plan",
            tooltip: "At the start of turn, gain 1 Energy if you have 45 or more INT.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                if (encounter.playerState.GetResource(TokenType.INTELLIGENCE) >= 45)
                    encounter.playerState.Energy += 1;
            }
        );
    }
}