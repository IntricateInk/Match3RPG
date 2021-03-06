﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI.Animation
{
    public class UIInstruction_SetTokenSprite : UIInstruction
    {
        public UIInstruction_SetTokenSprite(int uid, TokenType type)
        {
            this.uid = uid;
            this.type = type;
        }

        private readonly int uid;
        private readonly TokenType type;

        internal override void Run(UIAnimationManager manager, float dt)
        {
            manager.board.GetToken(uid).SetType(type);
        }
    }
}