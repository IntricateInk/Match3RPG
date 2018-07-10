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

            GameEffect.Action[] OnTurnStart = null
        ) : base(name, sprite, tooltip, OnTurnStart)
        {
            _AllPassives.Add(name, this);
        }
        
        // Factory Methods

        private static Dictionary<string, TargetPassive> _AllPassives = new Dictionary<string, TargetPassive>();

        public static TargetPassive GetPassive(string name)
        {
            return _AllPassives[name];
        }
    }
}