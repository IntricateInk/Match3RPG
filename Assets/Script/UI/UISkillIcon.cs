using Match3.Encounter;
using Match3.Encounter.Effect.Skill;
using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    internal class UISkillIcon : UITooltip
    {
        [SerializeField]
        private Image image;

        [SerializeField]
        private Text label;

        [SerializeField]
        private Text energyLabel;
        
        [SerializeField]
        private Text descLabel;

        [SerializeField]
        private Animator animator;

        public string skillName
        {
            get { return this.label.text; }
            set { this.label.text = value; }
        }
        
        public string energyCost
        {
            get { return this.energyLabel.text; }
            set { this.energyLabel.text = value; }
        }

        private GameSkill _skill;
        internal GameSkill skill
        {
            get { return this._skill; }
            set
            {
                this._skill = value;

                this.skillName = skill.name;
                this.image.sprite = Resources.Load<Sprite>(this.tooltip.sprite);
                this.descLabel.text = this.skill.tooltip;
            }
        }

        internal override ITooltip tooltip { get { return this.skill; } }

        private void Start()
        {
            UIAnimationManager.OnSelectedSkill += this.OnSelectSkill;
            UIAnimationManager.OnEnergyChange += this.OnEnergyChange;
        }

        private void OnDestroy()
        {
            UIAnimationManager.OnSelectedSkill -= this.OnSelectSkill;
            UIAnimationManager.OnEnergyChange -= this.OnEnergyChange;
        }
        
        [NonSerialized]
        public int index;

        public void OnButtonDown()
        {
            EncounterState.Current.SelectSkill(this.index);
        }

        public new void OnPointerEnter()
        {
            base.OnPointerEnter();
            this.animator.SetBool("Pointer", true);
        }

        public new void OnPointerExit()
        {
            base.OnPointerExit();
            this.animator.SetBool("Pointer", false);
        }

        private void OnEnergyChange(int energy)
        {
            this.animator.SetBool("CanUse", this.skill.CanPayCost(energy));
        }

        private void OnSelectSkill(int index)
        {
            if (index == this.index)
                this.animator.SetBool("Selected", true);
            else
                this.animator.SetBool("Selected", false);
        }
        
    }
}
