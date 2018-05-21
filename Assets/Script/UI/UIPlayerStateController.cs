using Match3.Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Match3.UI
{
    public class UIPlayerStateController : MonoBehaviour
    {
        [SerializeField]
        private Text turnLabel;

        [SerializeField]
        private Text strLabel;

        [SerializeField]
        private Text agiLabel;

        [SerializeField]
        private Text intLabel;

        [SerializeField]
        private Text chaLabel;

        [SerializeField]
        private Text lukLabel;
        
        internal void TurnLabelChange(int turn)
        {
            this.turnLabel.text = "Turns: " + turn.ToString();
        }

        internal void ResourceLabelChange(TokenType token, int amount)
        {
            switch (token)
            {
                case TokenType.STRENGTH:
                    this.strLabel.text = amount.ToString();
                    break;

                case TokenType.AGILITY:
                    this.agiLabel.text = amount.ToString();
                    break;

                case TokenType.INTELLIGENCE:
                    this.intLabel.text = amount.ToString();
                    break;

                case TokenType.CHARISMA:
                    this.chaLabel.text = amount.ToString();
                    break;

                case TokenType.LUCK:
                    this.lukLabel.text = amount.ToString();
                    break;
            }
        }
    }
}