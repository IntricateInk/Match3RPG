using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI { 

    internal abstract class UITooltip : MonoBehaviour {

        internal abstract ITooltip tooltip { get; set; }

        public void OnPointerEnter()
        {
            if (this.tooltip != null) this.tooltip.Show();
        }

        public void OnPointerExit()
        {
            if (this.tooltip != null) this.tooltip.Show(false);
        }
    }
}