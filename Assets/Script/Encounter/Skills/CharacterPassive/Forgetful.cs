using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive FORGETFUL = new CharacterPassive
        (
            name: "Forgetful",
            sprite: "icons/sad",
            tooltip: "At the start of every turn, spawn 3 Amnesia.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.AMNESIA, 3);
            }
        );
    }
}