using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_ShowEncounterSummary : UIInstruction
    {
        public UIInstruction_ShowEncounterSummary(float gold, float exp, string[] trophies)
        {
            this.gold = gold;
            this.exp = exp;
            this.trophies = trophies;
        }

        private readonly float gold;
        private readonly float exp;
        private readonly string[] trophies;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.victoryOverlay.Show(gold, exp, trophies);
        }
    }
}