using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public sealed partial class GamePassive : ITooltip
    {
        public string name { get; private set; }
        public string sprite { get; private set; }
        public string tooltip { get; private set; }

        internal int level = 0;

        internal GamePassive
        (
            string name, 
            string sprite, 
            string tooltip,

            GameEffect.Action[] OnTurnStart = null
        )
        {
            this.name = name;
            this.sprite = sprite;
            this.tooltip = tooltip;

            this.actionsOnTurnStart = OnTurnStart;

            _AllPassives.Add(name, this);
        }

        // Factory Methods

        private static Dictionary<string, GamePassive> _AllPassives = new Dictionary<string, GamePassive>();

        private readonly GameEffect.Action[] actionsOnTurnStart;
        internal void OnTurnStart(EncounterState encounter) { GameEffect.Invoke(actionsOnTurnStart, encounter); }

        public static GamePassive GetPassive(string name)
        {
            return _AllPassives[name];
        }
    }
}