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

            GameEffect.PassiveAction OnTurnStart,
            GameEffect.PassiveAction OnTurnEnd,
            GameEffect.PassiveAction OnApplyPassive,
            GameEffect.PassiveAction OnRemovePassive,
            GameEffect.PassiveAction OnDestroy
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
        
        private readonly GameEffect.PassiveAction actionsOnTurnStart;
        internal void OnTurnStart(EncounterState encounter, List<TokenState> targets)
        {
            if (actionsOnTurnStart != null) actionsOnTurnStart(this, encounter, targets);
        }

        private readonly GameEffect.PassiveAction actionsOnTurnEnd;
        internal void OnTurnEnd(EncounterState encounter, List<TokenState> targets)
        {
            if (actionsOnTurnEnd != null) actionsOnTurnEnd(this, encounter, targets);
        }

        private readonly GameEffect.PassiveAction actionsOnApplyPassive;
        internal void OnApplyPassive(EncounterState encounter, List<TokenState> targets)
        {
            if (actionsOnApplyPassive != null) actionsOnApplyPassive(this, encounter, targets);
        }

        private readonly GameEffect.PassiveAction actionsOnRemovePassive;
        internal void OnRemovePassive(EncounterState encounter, List<TokenState> targets)
        {
            if (actionsOnRemovePassive != null) actionsOnRemovePassive(this, encounter, targets);
        }

        private readonly GameEffect.PassiveAction actionsOnDestroy;
        internal void OnDestroy(EncounterState encounter, List<TokenState> targets)
        {
            if (actionsOnDestroy != null) actionsOnDestroy(this, encounter, targets);
        }
    }
}