using Match3.Encounter.Encounter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3.UI
{
    public class UIObjectiveListController : MonoBehaviour
    {
        private List<UIObjectiveController> objectives = new List<UIObjectiveController>();

        internal void AddObjective(EncounterObjective objective)
        {
            this.objectives.Add(UIFactory.CreateObjective(this, objective));
        }

        internal List<UIObjectiveController> GetUIObject(List<EncounterObjective> objectives)
        {
            List<UIObjectiveController> objs = new List<UIObjectiveController>();

            objs.AddRange(this.objectives.Where((obj) => { return objectives.Contains(obj.objective); }));

            return objs;
        }
    }
}