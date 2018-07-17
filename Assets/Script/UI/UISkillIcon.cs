using Match3.Encounter;
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
        private Text resourceLabel;

        [SerializeField]
        private Animator animator;

        public string skillName
        {
            get { return this.label.text; }
            set { this.label.text = value; }
        }

        public string resourceCost
        {
            get { return this.resourceLabel.text; }
            set { this.resourceLabel.text = value; }
        }
        
        private ITooltip _tooltip;
        internal override ITooltip tooltip
        {
            get { return this._tooltip; }
            set
            {
                this._tooltip = value;

                this.skillName = tooltip.name;
                this.image.sprite = Resources.Load<Sprite>(this.tooltip.sprite);
            }
        }

        private void Start()
        {
            UIAnimationManager.OnSelectedSkill += this.OnSelectSkill;
        }

        private void OnDestroy()
        {
            UIAnimationManager.OnSelectedSkill -= this.OnSelectSkill;
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
            this.animator.Play("Highlighted");
        }

        public new void OnPointerExit()
        {
            base.OnPointerExit();
            this.UpdateAnimator();
        }

        private void OnSelectSkill(int index)
        {
            this.UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            if (UIAnimationManager.SelectedSkill == index)
            {
                this.animator.Play("Pressed");
            }
            else
            {
                this.animator.Play("Normal");
            }
        }
    }
}
