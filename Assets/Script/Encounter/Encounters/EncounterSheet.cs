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

        public readonly EncounterObjective[] objectives;
        public readonly string[] passives;

        public EncounterSheet
            (
                string name,
                string icon,
                string tooltip,
                string[] objectives,
                string[] passives
            )
        {
            this.name    = name;
            this.sprite  = icon;
            this.tooltip = tooltip;

            this.objectives = EncounterObjective.GetObjective(objectives);
            this.passives = passives;

            _AllEncounters.Add(name, this);
        }

        internal bool MainObjectiveMet(EncounterState encounter)
        {
            foreach (EncounterObjective objective in this.objectives)
            {
                if (objective.type != EncounterObjective.Type.BONUS && objective.isCompleted(encounter.playerState))
                {
                    this.mainObjectiveMet = objective;
                    return true;
                }
            }

            return false;
        }
        
        // Factory

        public static Dictionary<string, EncounterSheet> _AllEncounters = new Dictionary<string, EncounterSheet>();
        public static List<EncounterSheet> AllEncounters { get { return new List<EncounterSheet>(_AllEncounters.Values); } }
    }
}
