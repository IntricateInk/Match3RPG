using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive UNSTABLE = new CharacterPassive
        (
            name: "Unstable",
            sprite: "tokens/int",
            tooltip: "At the start of every turn, spawn 3 Wildfire.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.WILDFIRE, 3);
            }
        );
    }
}