using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill DEAD_MANS_KNEE = new GameSkill
        (
            name: "Dead Man's Knee",
            sprite: "icons/undead_army",
            tooltip: "Destroy all tokens below Zombie tokens.",

            energyCost: 2,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                foreach (TokenState other in encounter.boardState.GetTokens())
                {
                    if (other.Passives.Contains(TargetPassive.ZOMBIE))
                    {
                        TokenState below = other.GetAdjacent(0, -1);
                        if (below != null) below.Destroy();
                    }
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}