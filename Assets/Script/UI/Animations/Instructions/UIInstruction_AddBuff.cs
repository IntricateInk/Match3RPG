using Match3.Encounter.Effect.Passive;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UI_InstructionDisplayBuff : UIInstruction
    {
        public UI_InstructionDisplayBuff(CharacterPassive tooltip, bool is_add) {
            this.tooltip = tooltip;
            this.is_add = is_add;
        }

        private readonly CharacterPassive tooltip;
        private readonly bool is_add;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            if (is_add)
                manager.buffContainer.AddBuff(this.tooltip);
            else
                manager.buffContainer.RemoveBuff(this.tooltip);
        }
    }
}