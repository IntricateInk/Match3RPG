using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_RemoveToken : UIInstruction
    {
        public UIInstruction_RemoveToken(int uid)
        {
            this.uid = uid;
        }

        private readonly int uid;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.board.GetToken(uid).RemoveToken();
        }
    }
}