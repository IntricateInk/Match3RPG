using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive COMMANDER_OF_DARKNESS = new CharacterPassive
        (
            name: "Commander of Darkness",
            sprite: "icons/undead_army",
            tooltip: "At the start of turn, gain 1 Energy if there are 5 or more Zombies.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                int count =
                    encounter.boardState.GetTokens().Count((token) => { return token.Passives.Contains(TargetPassive.ZOMBIE); });
                if (count >= 5)
                    encounter.playerState.Energy += 1;
            }
        );
    }
}