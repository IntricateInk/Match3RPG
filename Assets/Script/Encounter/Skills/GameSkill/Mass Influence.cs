using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill MASS_INFLUENCE = new GameSkill
        (
            name: "Mass Influence",
            sprite: "icons/convince",
            tooltip: "Select a tile. Chain. Transform all Selected Tiles into Charisma Tiles.",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets = GameEffect.ChainFromFirst(targets[0], encounter);
                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in targets)
                {
                    token.PlayAnimation("glow_bubble", normalized_size: 3f);
                    token.type = TokenType.CHARISMA;
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}