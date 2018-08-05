using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive GAMBLERS_GAIT = new CharacterPassive
        (
            name: "Gambler's Gait",
            sprite: "icons/focus",
            tooltip: "At the start of turn, gain 1 Energy if you have 30 or more CHA and LUK.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                if (encounter.playerState.GetResource(TokenType.CHARISMA) >= 30 &&
                    encounter.playerState.GetResource(TokenType.LUCK) >= 30)
                    encounter.playerState.Energy += 1;
            }
        );
    }
}