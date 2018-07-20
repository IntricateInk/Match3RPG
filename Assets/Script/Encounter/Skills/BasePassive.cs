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

            GameEffect.Action OnTurnStart,
            GameEffect.Action OnTurnEnd,
            GameEffect.Action OnApplyPassive,
            GameEffect.Action OnRemovePassive,
            GameEffect.Action OnDestroy
        )
        {
            this.name = name;
            this.sprite = sprite;
            this.tooltip = tooltip;

            this.actionsOnTurnStart     = OnTurnStart;
            this.actionsOnTurnEnd       = OnTurnEnd;
            this.actionsOnApplyPassive  = OnApplyPassive;
            this.actionsOnRemovePassive = OnRemovePassive;
            this.actionsOnDestroy       = OnDestroy;
        }
        
        private readonly GameEffect.Action actionsOnTurnStart;
        internal void OnTurnStart(EncounterState encounter, List<TokenState> targets)
        {
            if (actionsOnTurnStart != null) actionsOnTurnStart(encounter, targets);
        }

        private readonly GameEffect.Action actionsOnTurnEnd;
        internal void OnTurnEnd(EncounterState encounter, List<TokenState> targets)
        {
            if (actionsOnTurnEnd != null) actionsOnTurnEnd(encounter, targets);
        }

        private readonly GameEffect.Action actionsOnApplyPassive;
        internal void OnApplyPassive(EncounterState encounter, List<TokenState> targets)
        {
            if (actionsOnApplyPassive != null) actionsOnApplyPassive(encounter, targets);
        }

        private readonly GameEffect.Action actionsOnRemovePassive;
        internal void OnRemovePassive(EncounterState encounter, List<TokenState> targets)
        {
            if (actionsOnRemovePassive != null) actionsOnRemovePassive(encounter, targets);
        }

        private readonly GameEffect.Action actionsOnDestroy;
        internal void OnDestroy(EncounterState encounter, List<TokenState> targets)
        {
            if (actionsOnDestroy != null) actionsOnDestroy(encounter, targets);
        }
    }
}