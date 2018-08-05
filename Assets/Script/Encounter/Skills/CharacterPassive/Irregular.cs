using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive IRREGULAR = new CharacterPassive
        (
            name: "Irregular",
            sprite: "icons/irregular",
            tooltip: "At the start of each turn, spawn 3 Unstable.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.UNSTABLE, 3);
            }
        );
    }
}