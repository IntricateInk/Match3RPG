using Match3.Character;
using Match3.Encounter.Encounter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    public class UIObjectiveController : MonoBehaviour
    {
        [SerializeField]
        private Text label;

        [SerializeField]
        private Image image;

        [SerializeField]
        private Transform moneyGroup;

        [SerializeField]
        private Text moneyLabel;

        [SerializeField]
        private Transform expGroup;

        [SerializeField]
        private Text expLabel;

        [SerializeField]
        private Transform rewardsContainer;

        private EncounterObjective _objective;
        internal EncounterObjective objective
        {
            get { return this._objective; }
            set
            {
                this._objective = value;

                if (this._objective != null)
                {
                    this.label.text = this.objective.name;
                    this.image.sprite = this.objective.GetSprite();

                    if (this.objective.GoldReward != 0)
                    {
                        this.moneyGroup.gameObject.SetActive(true);
                        this.moneyLabel.text = this.objective.GoldReward.ToString();
                    }

                    if (this.objective.ExpReward != 0)
                    {
                        this.expGroup.gameObject.SetActive(true);
                        this.expLabel.text = this.objective.ExpReward.ToString();
                    }

                    foreach (string trophy_name in this.objective.TrophyReward)
                    {
                        TrophySheet trophy = TrophySheet.GetTrophy(trophy_name);
                        UIFactory.CreateTrophy(trophy, this.rewardsContainer);
                    }

                    this.TryCreate(TokenType.STRENGTH, this.objective.MinStrength, this.objective.MaxStrength);
                    this.TryCreate(TokenType.AGILITY, this.objective.MinAgility, this.objective.MaxAgility);
                    this.TryCreate(TokenType.INTELLIGENCE, this.objective.MinIntelligence, this.objective.MaxIntelligence);
                    this.TryCreate(TokenType.CHARISMA, this.objective.MinCharisma, this.objective.MaxCharisma);
                    this.TryCreate(TokenType.LUCK, this.objective.MinLuck, this.objective.MaxLuck);
                    this.TryCreate(TokenType.TURN, this.objective.MinTurn, this.objective.MaxTurn);
                }
            }
        }

        private void TryCreate(TokenType field, int min, int max)
        {
            if (min >= field.MinValue() && max <= field.MaxValue())
                UIFactory.CreateResourceBar(this, field, min, max);
        }
        
        // Unity API hooks

        public void OnPointerEnter()
        {
            if (this.objective != null) this.objective.Show();
        }

        public void OnPointerExit()
        {
            if (this.objective != null) this.objective.Show(false);
        }
    }
}