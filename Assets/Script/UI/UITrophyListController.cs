using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.UI
{
    public class UITrophyListController : MonoBehaviour
    {
        public void AddTrophy(ITooltip tooltip)
        {
            UIFactory.Create(tooltip, this);
        }
    }
}