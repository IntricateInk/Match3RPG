using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI
{
    public class UIObjectiveListController : MonoBehaviour
    {
        internal void AddObjective(ITooltip tooltip)
        {
            UIFactory.Create(tooltip, this);
        }
    }
}