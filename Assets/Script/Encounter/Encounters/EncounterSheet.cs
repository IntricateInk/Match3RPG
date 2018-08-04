using Match3.Overworld;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3.Encounter.Encounter
{
    public sealed partial class EncounterSheet : ITooltip
    {
        public string name    { get; private set; }
        public string sprite  { get; private set; }
        public string tooltip { get;  private set; }

        public readonly int min_depth;
        public readonly int max_depth;

        public EncounterObjective mainObjectiveMet { get; private set; }

        public readonly EncounterObjective[] objectives;
        public readonly string[] passives;
        private readonly int[] weights;

        public EncounterSheet
            (
                string name,
                string icon,
                string tooltip,

                int min_depth,
                int max_depth,

                string[] objectives,
                string[] passives,
                int[] weights
            )
        {
            this.name    = name;
            this.sprite  = icon;
            this.tooltip = tooltip;

            this.min_depth = min_depth;
            this.max_depth = max_depth;

            this.objectives = EncounterObjective.GetObjective(objectives);
            this.passives = passives;
            this.weights = weights;

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

        internal int GetWeight(OverworldNodeType nodeType)
        {
            return this.weights[nodeType.AsInt()];
        }

        internal EncounterObjective GetMainObjective(PlayerState player)
        {
            foreach (EncounterObjective objective in this.objectives)
            {
                if (objective.type == EncounterObjective.Type.WIN && objective.isCompleted(player))
                    return objective;
            }

            foreach (EncounterObjective objective in this.objectives)
            {
                if (objective.type == EncounterObjective.Type.LOSE && objective.isCompleted(player))
                    return objective;
            }

            return null;
        }

        // Factory

        public static Dictionary<string, EncounterSheet> _AllEncounters = new Dictionary<string, EncounterSheet>();
        public static List<EncounterSheet> AllEncounters { get { return new List<EncounterSheet>(_AllEncounters.Values); } }
        
        public static IEnumerable<EncounterSheet> GetEncounters(int depth)
        {
            return AllEncounters.Where((e) => { return depth >= e.min_depth && depth <= e.max_depth; });
        }
    }
}
