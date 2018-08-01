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

            GameEffect.PassiveAction OnTurnStart     = null,
            GameEffect.PassiveAction OnTurnEnd       = null,
            GameEffect.PassiveAction OnApplyPassive  = null,
            GameEffect.PassiveAction OnRemovePassive = null,
            GameEffect.PassiveAction OnDestroy       = null
        ) : base(name, sprite, tooltip, OnTurnStart, OnTurnEnd, OnApplyPassive, OnRemovePassive, OnDestroy)
        {
            _AllPassives.Add(name, this);
        }

        // Factory Methods

        private static Dictionary<string, CharacterPassive> _AllPassives = new Dictionary<string, CharacterPassive>();

        public static CharacterPassive GetPassive(string name)
        {
            try
            {
                return _AllPassives[name];
            } catch (KeyNotFoundException e)
            {
                Debug.Log(name);
                throw e;
            }
        }
    }
}