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

            GameEffect.Action OnTurnStart = null,
            GameEffect.Action OnTurnEnd = null,
            GameEffect.Action OnApplyPassive = null,
            GameEffect.Action OnRemovePassive = null,
            GameEffect.Action OnDestroy = null
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