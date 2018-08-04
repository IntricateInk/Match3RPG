using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive EMPTY_MIND = new CharacterPassive
        (
            name: "Empty Mind",
            sprite: "tokens/int",
            tooltip: "At the start of turn, gain 1 Energy if there are 5 or more Blank tokens.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                int count =
                    encounter.boardState.GetTokens(TokenType.BLANK).Count;
                if (count >= 5)
                    encounter.playerState.Energy += 1;
            }
        );
    }
}