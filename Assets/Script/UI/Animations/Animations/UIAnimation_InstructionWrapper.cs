using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIAnimation_InstructionWrapper : UIAnimation
    {
        internal UIAnimation_InstructionWrapper(UIInstruction instruction)
        {
            this.instruction = instruction;
            this.isDone = true;
        }

        private readonly UIInstruction instruction;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            this.instruction.Run(manager, dt);
        }
    }
}
