using Match3.Encounter.Encounter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI
{
    public class UIObjectiveListController : MonoBehaviour
    {
        internal void AddObjective(EncounterObjective objective)
        {
            UIFactory.CreateObjective(this, objective);
        }
    }
}