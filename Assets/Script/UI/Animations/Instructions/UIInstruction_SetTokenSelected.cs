using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_SetTokenSelected : UIInstruction
    {
        public UIInstruction_SetTokenSelected(int uid, bool is_selected)
        {
            this.uid = uid;
            this.is_selected = is_selected;
        }

        private readonly int uid;
        private readonly bool is_selected;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.board.GetToken(uid).is_selected = is_selected;
        }
    }
}