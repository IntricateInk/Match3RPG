using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive DISTRACTED = new CharacterPassive
        (
            name: "Distracted",
            sprite: "tokens/int",
            tooltip: "At the start of every turn, Blank 3 tokens.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                foreach (TokenState token in encounter.boardState.GetTokens().RandomChoice(3))
                {
                    token.type = TokenType.BLANK;
                }
            }
        );
    }
}