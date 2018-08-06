using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        private static GameSkill CrewMove(string name, string sprite, string tooltip, int dx, int dy)
        {
            return new GameSkill
            (
                name: name, 
                sprite: sprite,
                tooltip: tooltip,

                energyCost: 1,

                selectBehavior: SelectBehavior.None,

                runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
                {
                    GameEffect.BeginAnimationBatch();
                    foreach (TokenState other in encounter.boardState.GetTokens())
                    {
                        if (other.Passives.Contains(TargetPassive.CREW))
                        {
                            if (other.GetAdjacent(dx, dy) != null)
                                other.Swap(dx, dy);
                        }
                    }
                    GameEffect.EndAnimationBatch();
                }
            );
        }

        public static GameSkill ADVANCE = CrewMove
        (
            "Advance",
            "icons/command",
            "Swap all Crew tokens upwards.",

            dx: 0, 
            dy: 1
        );

        public static GameSkill RETREAT = CrewMove
        (
            "Retreat",
            "icons/command",
            "Swap all Crew tokens downwards.",

            dx: 0,
            dy: -1
        );

        public static GameSkill FLANK = CrewMove
        (
            "Flank",
            "icons/command",
            "Swap all Crew tokens left.",

            dx: -1,
            dy: 0
        );

        public static GameSkill MARCH = CrewMove
        (
            "March",
            "icons/command",
            "Swap all Crew tokens right.",

            dx: 1,
            dy: 0
        );
    }
}