using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        public static CharacterPassive AWAKENING = new CharacterPassive
        (
            name: "Awakening",
            sprite: "icons/open_arm",
            tooltip: "At the start of the encounter, spawn 1 Spirit Catcher.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                List<TokenState> tokens = encounter.boardState.GetTokens();
                tokens.Shuffle();
                
                tokens[0].tile.ApplyBuff(TargetPassive.SPIRIT_CATCHER);
            }
        );
    }
}