using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive ENEMY_OF_THE_MOLES = new CharacterPassive
        (
            name: "Enemy of the Moles",
            sprite: "tokens/int",
            tooltip: "At the start of every turn, spawn 3 Moles.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.MOLE, 3);
            }
        );
    }
}