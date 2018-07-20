using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Encounter
{
    public sealed partial class EncounterSheet : ITooltip
    {
        public string name    { get; private set; }
        public string sprite  { get; private set; }
        public string tooltip { get;  private set; }

        public EncounterObjective mainObjectiveMet { get; private set; }

        public readonly EncounterObjective[] mainObjectives;
        public readonly EncounterObjective[] bonusObjectives;
        public readonly string[] passives;

        public EncounterSheet
            (
                string name,
                string icon,
                string tooltip,
                string[] mainObjectives,
                string[] bonusObjectives,
                string[] passives
            )
        {
            this.name    = name;
            this.sprite  = icon;
            this.tooltip = tooltip;

            this.mainObjectives  = EncounterObjective.GetObjective(mainObjectives);
            this.bonusObjectives = EncounterObjective.GetObjective(bonusObjectives);
            this.passives = passives;

            _AllEncounters.Add(name, this);
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
        
        // Factory

        private static Dictionary<string, EncounterSheet> _AllEncounters = new Dictionary<string, EncounterSheet>();
        public static List<EncounterSheet> AllEncounters { get { return new List<EncounterSheet>(_AllEncounters.Values); } }
    }
}
