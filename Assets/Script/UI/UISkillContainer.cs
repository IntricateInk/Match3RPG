using Match3.Encounter.Effect.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.UI
{
    public class UISkillContainer : MonoBehaviour
    {
        internal void AddSkill(GameSkill skill, int index)
        {
            UIFactory.CreateSkillIcon(skill, index, this);
        }
    }
}