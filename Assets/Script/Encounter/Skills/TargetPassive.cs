using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        internal TargetPassive
        (
            string name,
            string sprite,
            string tooltip,

            GameEffect.PassiveAction OnTurnStart = null,
            GameEffect.PassiveAction OnTurnEnd = null,
            GameEffect.PassiveAction OnApplyPassive = null,
            GameEffect.PassiveAction OnRemovePassive = null,
            GameEffect.PassiveAction OnDestroy = null
        ) : base(name, sprite, tooltip, OnTurnStart, OnTurnEnd, OnApplyPassive, OnRemovePassive, OnDestroy)
        {
            if (_AllPassives == null) _AllPassives = new Dictionary<string, TargetPassive>();
            _AllPassives.Add(name, this);
        }

        // Factory Methods

        private static Dictionary<string, TargetPassive> _AllPassives;

        public static TargetPassive GetPassive(string name)
        {
            return _AllPassives[name];
        }
    }
}