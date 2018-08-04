using Match3.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.Overworld
{
    public class TrophyController : MonoBehaviour
    {
        [SerializeField]
        private Text nameLabel;

        [SerializeField]
        private Image icon;

        [SerializeField]
        private Text expLabel;

        [SerializeField]
        private Text descLabel;

        [SerializeField]
        private Button learnButton;

        [SerializeField]
        private Animator animator;

        private TrophySheet _trophy;
        internal TrophySheet trophy
        {
            get { return _trophy; }
            set
            {
                _trophy = value;

                if (trophy != null)
                {
                    this.nameLabel.text = this.trophy.name;
                    this.icon.sprite = this.trophy.GetSprite();
                    this.expLabel.text = this.trophy.expCost.ToString();
                    this.descLabel.text = this.trophy.tooltip;

                    this.Recolor();
                }
            }
        }

        internal void ShowLearnButton(bool is_show)
        {
            this.learnButton.gameObject.SetActive(is_show);
        }

        public void Recolor()
        {
            Color color = Color.black;

            if (!OverworldState.Current.player.trophies.Contains(this.trophy))
                color = Color.grey;

            this.nameLabel.color = color;
            this.expLabel.color = color;
        }

        public void OnLearnClick()
        {
            OverworldState.Current.player.LearnTrophy(this.trophy);
        }

        public void OnExpandClick()
        {
            this.animator.SetBool("Expand", !this.animator.GetBool("Expand"));
        }
    }
}