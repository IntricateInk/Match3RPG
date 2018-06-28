using Match3.Encounter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Match3.UI.Animation;

namespace Match3.UI
{
    public class UIPlayerStateController : MonoBehaviour
    {
        [SerializeField]
        private Text nameLabel;

        [SerializeField]
        private Image icon;

        [SerializeField]
        private Text timeLabel;

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

        private void Awake()
        {
            UIAnimationManager.OnResourceChange += this.OnResourceChange;
        }
        
        internal void SetTooltip(ITooltip tooltip)
        {
            this.nameLabel.text = tooltip.name;
            this.icon.sprite = tooltip.GetSprite();
        }

        internal void SetTimeLabel(float time)
        {
            this.timeLabel.text = time.ToString("00:00");
        }

        internal void TurnLabelChange(int turn)
        {
            this.turnLabel.text = "Turns: " + turn.ToString();
        }

        internal void OnResourceChange(TokenType token, int amount)
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