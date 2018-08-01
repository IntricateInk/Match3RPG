using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    public class UIObjectiveItemController : MonoBehaviour
    {
        [SerializeField]
        private Text amountLabel;

        [SerializeField]
        private Image icon;

        [SerializeField]
        private Text signLabel;

        [SerializeField]
        private Text goalLabel;

        private TokenType type;

        private void Awake()
        {
            UIAnimationManager.OnResourceChange += this.OnResourceChange;
            UIAnimationManager.OnTurnChange += this.OnTurnChange;
        }
        
        private void OnDestroy()
        {
            UIAnimationManager.OnResourceChange -= this.OnResourceChange;
            UIAnimationManager.OnTurnChange -= this.OnTurnChange;
        }

        private void OnTurnChange(int amount) { this.OnResourceChange(TokenType.TURN, amount); }
        private void OnResourceChange(TokenType type, int amount)
        {
            if (type == this.type)
            {
                this.amountLabel.text = amount.ToString();
            }
        }
        
        internal void SetGoal(TokenType type, int goal, bool is_min)
        {
            this.type = type;

            this.icon.sprite = type.GetSprite();
            this.goalLabel.text = goal.ToString();

            if (is_min)
            {
                this.signLabel.text = ">=";
            } else
            {
                this.signLabel.text = "<=";
            }
        }
    }
}