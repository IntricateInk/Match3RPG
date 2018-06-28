using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI
{
    public class UIBuffContainer : MonoBehaviour
    {
        internal void AddBuff(ITooltip buff)
        {
            UIFactory.Create(buff, this);
        }
    }
}
