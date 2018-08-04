using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive QUICK_WITTED = new CharacterPassive
        (
            name: "Quick Witted",
            sprite: "tokens/int",
            tooltip: string.Format("Gain 10 {0} at the start of the encounter. Lose 1 {0} at the start of each turn.", TokenType.INTELLIGENCE.AsStr()),

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.INTELLIGENCE, 10);
            },

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.INTELLIGENCE, -1);
            }
        );
    }
}