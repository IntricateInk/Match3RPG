using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public abstract class BasePassive : ITooltip
    {
        public string name { get; private set; }
        public string sprite { get; private set; }
        public string tooltip { get; private set; }

        internal BasePassive
        (
            string name,
            string sprite,
            string tooltip,

            GameEffect.Action[] OnTurnStart = null,
            GameEffect.Action[] OnApplyPassive = null,
            GameEffect.Action[] OnRemovePassive = null

        )
        {
            this.name = name;
            this.sprite = sprite;
            this.tooltip = tooltip;

            this.actionsOnTurnStart     = OnTurnStart;
            this.actionsOnApplyPassive  = OnApplyPassive;
            this.actionsOnRemovePassive = OnRemovePassive;
        }
        
        private readonly GameEffect.Action[] actionsOnTurnStart;
        internal void OnTurnStart(EncounterState encounter, List<TokenState> targets)
        {
            GameEffect.Invoke(actionsOnTurnStart, encounter, targets);
        }

        private readonly GameEffect.Action[] actionsOnApplyPassive;
        internal void OnApplyPassive(EncounterState encounter, List<TokenState> targets)
        {
            GameEffect.Invoke(actionsOnApplyPassive, encounter, targets);
        }

        private readonly GameEffect.Action[] actionsOnRemovePassive;
        internal void OnRemovePassive(EncounterState encounter, List<TokenState> targets)
        {
            GameEffect.Invoke(actionsOnRemovePassive, encounter, targets);
        }
    }
}