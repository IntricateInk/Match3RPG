using System;
using System.Collections;
using System.Collections.Generic;
using Match3.Encounter.Encounter;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_AddObjective : UIInstruction
    {

        public UIInstruction_AddObjective(EncounterObjective objective, bool isMain)
        {
            this.objective = objective;
            this.isMain = isMain;
        }
        
        private readonly bool isMain;
        private readonly EncounterObjective objective;

        public void Run(UIAnimationManager manager, float dt)
        {
            if (isMain)
                manager.mainObjectives.AddObjective(objective);
            else
                manager.bonusObjectives.AddObjective(objective);
        }
    }
}