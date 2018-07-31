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
        private Text energyLabel;

        [SerializeField]
        private Text turnLabel;

        [SerializeField]
        private UIResourceBarController strBar;

        [SerializeField]
        private UIResourceBarController agiBar;

        [SerializeField]
        private UIResourceBarController intBar;

        [SerializeField]
        private UIResourceBarController chaBar;

        [SerializeField]
        private UIResourceBarController lukBar;

        [SerializeField]
        private Transform strIcon;
        [SerializeField]
        private Transform agiIcon;
        [SerializeField]
        private Transform intIcon;
        [SerializeField]
        private Transform chaIcon;
        [SerializeField]
        private Transform lukIcon;

        private void Awake()
        {
            UIAnimationManager.OnTimeChange += this.OnTimeChange;
            UIAnimationManager.OnTurnChange += this.OnTurnChange;
            UIAnimationManager.OnEnergyChange += this.OnEnergyChange;

            strBar.field = TokenType.STRENGTH;
            agiBar.field = TokenType.AGILITY;
            intBar.field = TokenType.INTELLIGENCE;
            chaBar.field = TokenType.CHARISMA;
            lukBar.field = TokenType.LUCK;

            strBar.OnResourceChange(TokenType.STRENGTH, 0);
            agiBar.OnResourceChange(TokenType.AGILITY, 0);
            intBar.OnResourceChange(TokenType.INTELLIGENCE, 0);
            chaBar.OnResourceChange(TokenType.CHARISMA, 0);
            lukBar.OnResourceChange(TokenType.LUCK, 0);
        }

        private void OnDestroy()
        {
            UIAnimationManager.OnTimeChange -= this.OnTimeChange;
            UIAnimationManager.OnTurnChange -= this.OnTurnChange;
            UIAnimationManager.OnEnergyChange -= this.OnEnergyChange;
        }
        
        public void OnTurnEndButtonClick()
        {
            EncounterState.Current.EndTurn();
        }

        internal void SetTooltip(ITooltip tooltip)
        {
            this.nameLabel.text = tooltip.name;
            this.icon.sprite = tooltip.GetSprite();
        }

        private void OnEnergyChange(int energy)
        {
            this.energyLabel.text = energy.ToString();
        }

        internal void OnTimeChange(float time)
        {
            TimeSpan t = TimeSpan.FromSeconds(time);
            this.timeLabel.text = String.Format("Time {0:D2}:{1:D2}", t.Minutes, t.Seconds);
        }

        internal void OnTurnChange(int turn)
        {
            this.turnLabel.text = "Turns: " + turn.ToString();
        }
        
        internal Vector3 GetResourcePosition(TokenType token)
        {
            switch (token)
            {
                case TokenType.STRENGTH:
                    return this.strIcon.position;

                case TokenType.AGILITY:
                    return this.agiIcon.position;

                case TokenType.INTELLIGENCE:
                    return this.intIcon.position;

                case TokenType.CHARISMA:
                    return this.chaIcon.position;

                case TokenType.LUCK:
                    return this.lukIcon.position;
            }

            throw new ArgumentException(string.Format("No such token: {0}", token));
        }
    }
}