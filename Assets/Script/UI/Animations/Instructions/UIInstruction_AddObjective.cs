using System;
using System.Collections;
using System.Collections.Generic;
using Match3.Encounter.Encounter;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_AddObjective : UIInstruction
    {

        public UIInstruction_AddObjective(EncounterObjective objective)
        {
            this.objective = objective;
        }
        
        private readonly EncounterObjective objective;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.objectives.AddObjective(objective);
        }
    }
}