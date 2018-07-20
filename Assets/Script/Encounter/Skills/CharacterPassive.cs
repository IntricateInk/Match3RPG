using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : BasePassive
    {
        internal CharacterPassive
        (
            string name, 
            string sprite, 
            string tooltip,

            GameEffect.Action OnTurnStart     = null,
            GameEffect.Action OnTurnEnd       = null,
            GameEffect.Action OnApplyPassive  = null,
            GameEffect.Action OnRemovePassive = null,
            GameEffect.Action OnDestroy       = null
        ) : base(name, sprite, tooltip, OnTurnStart, OnTurnEnd, OnApplyPassive, OnRemovePassive, OnDestroy)
        {
            _AllPassives.Add(name, this);
        }

        // Factory Methods

        private static Dictionary<string, CharacterPassive> _AllPassives = new Dictionary<string, CharacterPassive>();

        public static CharacterPassive GetPassive(string name)
        {
            return _AllPassives[name];
        }
    }
}