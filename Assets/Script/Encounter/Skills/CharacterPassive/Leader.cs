using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive LEADER = new CharacterPassive
        (
            name: "Leader",
            sprite: "icons/recruit",
            tooltip: "At the start of each turn, +1 Energy if there are 3 or more Crew.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                int count = encounter.boardState.GetTokens().Count(
                    (t) => { return t.Passives.Contains(TargetPassive.CREW); });

                if (count >= 3) encounter.playerState.Energy += 1;
            }
        );
    }
}