using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.UI
{
    public class UISkillBar : MonoBehaviour
    {

        internal void AddSkill(ITooltip tooltip, int index)
        {
            UIFactory.Create(tooltip, index, this);
        }
    }
}