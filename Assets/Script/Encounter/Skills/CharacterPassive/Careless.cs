using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive CARELESS = new CharacterPassive
        (
            name: "Careless",
            sprite: "tokens/int",
            tooltip: "At the the encounter, spawn 3 Wildfire.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.WILDFIRE, 3);
            }
        );
    }
}