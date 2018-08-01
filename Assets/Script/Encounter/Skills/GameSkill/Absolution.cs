using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill ABSOLUTION = new GameSkill
        (
            name: "Absolution",
            sprite: "skills/sleight",
            tooltip: "Select a token. Transform to Blank.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].PlayAnimation("wave1");
                targets[0].type = TokenType.BLANK;
            }
        );
    }
}