using Match3.Character;
using Match3.Encounter.Effect.Passive;
using Match3.Encounter.Effect.Skill;
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
        private SkillController[] tooltipControllers;

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

                    int i = 0;

                    foreach (string skill_name in this.trophy.skills)
                    {
                        GameSkill skill = GameSkill.GetSkill(skill_name);
                        this.tooltipControllers[i].tooltip = skill;
                        this.tooltipControllers[i].gameObject.SetActive(true);
                        i++;
                    }

                    foreach (string passive_name in this.trophy.passives)
                    {
                        CharacterPassive passive = CharacterPassive.GetPassive(passive_name);
                        this.tooltipControllers[i].tooltip = passive;
                        this.tooltipControllers[i].gameObject.SetActive(true);
                        i++;
                    }

                    while (i < this.tooltipControllers.Length)
                    {
                        this.tooltipControllers[i].gameObject.SetActive(false);
                        i++;
                    }

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