using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive LACKEY = new CharacterPassive
        (
            name: "Lackey",
            sprite: "icons/rally",
            tooltip: "At the the encounter, spawn 1 Crew.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.CREW, 1);
            }
        );
    }
}