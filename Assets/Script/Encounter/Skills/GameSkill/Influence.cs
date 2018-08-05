using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill INFLUENCE = new GameSkill
        (
            name: "Influence",
            sprite: "icons/convince",
            tooltip: "Select a tile. Transform it into a Charisma Tile.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].PlayAnimation("glow_bubble", normalized_size: 3f);
                targets[0].type = TokenType.CHARISMA;
            }
        );
    }
}