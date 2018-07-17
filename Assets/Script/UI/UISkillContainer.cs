using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.UI
{
    public class UISkillContainer : MonoBehaviour
    {
        internal void AddSkill(ITooltip tooltip, string resource_cost, int index)
        {
            UIFactory.CreateSkillIcon(tooltip, resource_cost, index, this);
        }
    }
}