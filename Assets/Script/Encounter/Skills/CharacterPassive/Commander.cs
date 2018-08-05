using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        public static CharacterPassive COMMANDER = new CharacterPassive
        (
            name: "Commander",
            sprite: "icons/command",
            tooltip: "At the start of the encounter, gain 15 STR and AGI, then spawn 1 Crew.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.STRENGTH, 15);
                GameEffect.GainResource(encounter, targets, TokenType.AGILITY, 15);

                encounter.boardState.GetTokens().RandomChoice().ApplyBuff(TargetPassive.CREW);
            }
        );
    }
}
