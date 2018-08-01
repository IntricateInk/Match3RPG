using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    // blank to ranodm non blank
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill CHAIN_REACTION = new GameSkill
        (
            name: "Chain Reaction",
            sprite: "skills/sleight",
            tooltip: "Select a token and destroy it. Then, try to match all tokens.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].PlayAnimation("dust1");
                targets[0].Destroy();
                encounter.boardState.DoTokenFall();
                encounter.boardState.DoMatch();
            }
        );
    }
}