using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Game.Encounter
{
    public sealed class EncounterSheet
    {
        public string name { get; private set; }
        public string icon { get; private set; }

        public EncounterObjective mainObjectiveMet { get; private set; }

        public readonly List<EncounterObjective> mainObjectives;
        public readonly List<EncounterObjective> bonusObjectives;

        public EncounterSheet
            (
                string name,
                string icon,
                List<EncounterObjective> mainObjectives,
                List<EncounterObjective> bonusObjectives
            )
        {
            this.name = name;
            this.icon = icon;

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

        internal void CheckBonusObjectives()
        {
            foreach (EncounterObjective objective in this.bonusObjectives)
            {
            }
        }
    }
}
