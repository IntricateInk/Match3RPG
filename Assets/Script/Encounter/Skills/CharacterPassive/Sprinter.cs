using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive SPRINTER = new CharacterPassive
        (
            name: "Sprinter",
            sprite: "tokens/agi",
            tooltip: string.Format("Gain 10 {0} at the start of the encounter. Lose 1 {0} at the start of each turn.", TokenType.AGILITY.AsStr()),

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.AGILITY, 10);
            },

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.AGILITY, -1);
            }
        );
    }
}