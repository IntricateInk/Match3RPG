using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        private static CharacterPassive PUCK = new CharacterPassive
        (
            name: "Puck", 
            sprite: "icons/arcane_blast",
            tooltip:
                "Puck is the master of mischief! At the start of the encounter, spawn 1 Spirit Catcher and 5 Fairy. At the start of each turn, spawn 2 Unstable, 2 Brimstone, and 2 Reagent. At the end of the turn, destroy a random Brimstone.",
            
            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTileBuff(encounter.boardState.tiles.Flatten(), TargetPassive.SPIRIT_CATCHER, 1);
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.FAIRY, 5);
            },

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.BRIMSTONE, 2);
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.UNSTABLE, 2);
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.REAGENT, 2);
            },

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                List<TokenState> tokens = 
                    new List<TokenState>(encounter.boardState.GetTokens().
                    Where((t) => { return t.Passives.Contains(TargetPassive.BRIMSTONE); }));

                if (tokens.Count != 0)
                    tokens.RandomChoice().Destroy();
            }
        );
    }
}