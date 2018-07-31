using Match3.Encounter.Encounter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_ShowEncounterSummary : UIInstruction
    {
        public UIInstruction_ShowEncounterSummary(List<EncounterObjective> objectives)
        {
            this.objectives = objectives;
        }

        private readonly List<EncounterObjective> objectives;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.victoryOverlay.Show(manager.objectives.GetUIObject(objectives));
        }
    }
}