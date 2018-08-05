using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive CURSED = new CharacterPassive
        (
            name: "Cursed",
            sprite: "icons/shade",
            tooltip: "At the start of every turn, spawn 3 Zombies.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.ZOMBIE, 3);
            }
        );
    }
}