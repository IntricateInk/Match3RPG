using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive LITHE = new CharacterPassive
        (
            name: "Lithe",
            sprite: "icons/boot_2",
            tooltip: "At end of the turn, Cascade.",

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                encounter.boardState.DoMatch();
            }
        );
    }
}