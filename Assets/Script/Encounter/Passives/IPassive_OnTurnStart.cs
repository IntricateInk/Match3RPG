using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Passive
{
    interface IPassive_OnTurnStart
    {
        void OnTurnStart(EncounterState encounter);
    }
}
