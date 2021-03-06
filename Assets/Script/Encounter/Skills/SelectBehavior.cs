﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    internal abstract class SelectBehavior
    {
        public static SelectBehavior Single = new SelectBehavior_Single();
        public static SelectBehavior TwoAdjacent = new SelectBehavior_TwoAdjacent();
        public static SelectBehavior Two = new SelectBehavior_AnyN(2);
        public static SelectBehavior None = new SelectBehavior_None();

        internal abstract void Select(InputState input, TokenState token);
        internal abstract bool ShouldRun(List<TokenState> selectedToken);

        private class SelectBehavior_Single : SelectBehavior
        {
            internal override void Select(InputState input, TokenState token)
            {
                input.SelectToken(token, true);
            }

            internal override bool ShouldRun(List<TokenState> selectedToken)
            {
                return selectedToken.Count == 1;
            }
        }

        private class SelectBehavior_AnyN : SelectBehavior
        {
            public SelectBehavior_AnyN(int n)
            {
                this.n = n;
            }

            private readonly int n;

            internal override void Select(InputState input, TokenState token)
            {
                input.SelectToken(token, true);
            }

            internal override bool ShouldRun(List<TokenState> selectedToken)
            {
                return selectedToken.Count == this.n;
            }
        }

        private class SelectBehavior_TwoAdjacent : SelectBehavior
        {
            internal override void Select(InputState input, TokenState token)
            {
                if (input.selectedTokens.Count == 1)
                {
                    TokenState token2 = input.selectedTokens[0];

                    bool isAdjX = token.x == token2.x && Mathf.Abs(token.y - token2.y) == 1;
                    bool isAdjY = token.y == token2.y && Mathf.Abs(token.x - token2.x) == 1;

                    if (!isAdjX && !isAdjY)
                        input.SelectToken(token2, false);
                }

                input.SelectToken(token, true);
            }

            internal override bool ShouldRun(List<TokenState> selectedToken)
            {
                return selectedToken.Count == 2;
            }
        }

        private class SelectBehavior_None : SelectBehavior
        {
            internal override void Select(InputState input, TokenState token)
            {
            }

            internal override bool ShouldRun(List<TokenState> selectedToken)
            {
                return true;
            }
        }
    }
}