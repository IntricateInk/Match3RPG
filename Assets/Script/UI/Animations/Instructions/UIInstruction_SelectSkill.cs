using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_SelectSkill : UIInstruction
    {
        public UIInstruction_SelectSkill(int index)
        {
            this.index = index;
        }

        private readonly int index;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.RaiseSelectedSkill(index);
        }
    }
}
