using Match3.Encounter.Effect.Skill;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_AddSkill : UIInstruction
    {

        public UIInstruction_AddSkill(GameSkill skill, int index)
        {
            this.skill = skill;
            this.index = index;
        }

        private readonly GameSkill skill;
        private readonly int index;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.skillContainer.AddSkill(skill, index);
        }
    }
}