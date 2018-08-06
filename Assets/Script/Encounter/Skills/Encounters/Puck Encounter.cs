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
                "Puck is the master of mischief! At the start of the encounter, spawn 1 Spirit Catcher and 5 Fairy. At the start of each turn, spawn 2 Unstable, 2 tokens with Wildfire and Reagent.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.SpawnTileBuff(encounter.boardState.tiles.Flatten(), TargetPassive.SPIRIT_CATCHER, 1);
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.FAIRY, 5);
            },

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                List<TokenState> tokens = encounter.boardState.GetTokens();
                tokens.Shuffle();

                int i = 0;
                foreach (TokenState token in tokens)
                {
                    if (token.Passives.Contains(TargetPassive.FAIRY)) continue;

                    token.ApplyBuff(TargetPassive.REAGENT);
                    token.ApplyBuff(TargetPassive.WILDFIRE);

                    i++;
                    if (i == 2) break;
                }
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.UNSTABLE, 2);
            }
        );
    }
}