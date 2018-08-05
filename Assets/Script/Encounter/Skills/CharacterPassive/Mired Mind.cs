using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive MIRED_MIND = new CharacterPassive
        (
            name: "Mired Mind",
            sprite: "icons/sad",
            tooltip: "At the the encounter, Blank 6 tokens.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                foreach (TokenState token in encounter.boardState.GetTokens().RandomChoice(6))
                    token.type = TokenType.BLANK;
            }
        );
    }
}