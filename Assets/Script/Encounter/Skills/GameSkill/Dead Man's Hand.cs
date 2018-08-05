using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill DEAD_MANS_HAND = new GameSkill
        (
            name: "Dead Man's Hand",
            sprite: "icons/undead_hand",
            tooltip: "Swap all tokens above Zombie tokens upwards.",

            energyCost: 2,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                foreach (TokenState other in encounter.boardState.GetTokens())
                {
                    if (other.Passives.Contains(TargetPassive.ZOMBIE))
                    {
                        TokenState above = other.GetAdjacent(0, 1);
                        if (above != null && above.GetAdjacent(0, 1) != null)
                        {
                            above.Swap(0, 1);
                        }
                    }
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}