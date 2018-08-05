using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive SWEATY = new CharacterPassive
        (
            name: "Sweaty",
            sprite: "icons/water",
            tooltip: "At the start of every turn, spawn 3 Water.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.WATER, 3);
            }
        );
    }
}