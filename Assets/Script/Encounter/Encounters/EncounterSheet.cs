using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Encounter
{
    public sealed class EncounterSheet : ITooltip
    {
        public string name    { get; private set; }
        public string sprite  { get; private set; }
        public string tooltip { get;  private set; }

        public EncounterObjective mainObjectiveMet { get; private set; }

        public readonly List<EncounterObjective> mainObjectives;
        public readonly List<EncounterObjective> bonusObjectives;

        public EncounterSheet
            (
                string name,
                string icon,
                string tooltip,
                List<EncounterObjective> mainObjectives,
                List<EncounterObjective> bonusObjectives
            )
        {
            this.name    = name;
            this.sprite  = icon;
            this.tooltip = tooltip;

            this.mainObjectives = mainObjectives;
            this.bonusObjectives = bonusObjectives;
        }

        internal bool MainObjectiveMet(EncounterState encounter)
        {
            foreach (EncounterObjective objective in this.mainObjectives)
            {
                if (objective.isCompleted(encounter.playerState))
                {
                    this.mainObjectiveMet = objective;
                    return true;
                }
            }

            return false;
        }

        internal void CheckBonusObjectives(EncounterState encounter)
        {
            foreach (EncounterObjective objective in this.bonusObjectives)
            {
                if (objective.isCompleted(encounter.playerState))
                {
                }
            }
        }
    }
}
