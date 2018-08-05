using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill TUMBLE = new GameSkill
        (
            name: "Tumble",
            sprite: "icons/kick",
            tooltip: "Select a tile. Chain. Transform into a random type. Cascade",

            energyCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                targets =  GameEffect.ChainFromFirst(targets[0], encounter);
                foreach (TokenState token in targets)
                {
                    token.PlayAnimation("glow_bubble", normalized_size: 3f);
                    token.type = TokenTypeHelper.RandomResource();
                }
                GameEffect.EndAnimationBatch();

                encounter.boardState.DoMatch();
            }
        );
    }
}