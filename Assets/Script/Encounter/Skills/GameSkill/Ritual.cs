using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill RITUAL = new GameSkill
        (
            name: "Ritual",
            sprite: "icons/spirit",
            tooltip: "Spawn 1 Spirit.",

            energyCost: 3,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                List<TokenState> tokens = encounter.boardState.GetTokens();
                tokens.Shuffle();

                tokens[0].ApplyBuff(TargetPassive.SPIRIT);
            }
        );
    }
}