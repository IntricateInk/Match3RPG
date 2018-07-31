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
    internal class UISkillIcon : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        [SerializeField]
        private Text label;

        [SerializeField]
        private Text energyLabel;
        
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
                this.image.sprite = Resources.Load<Sprite>(this.skill.sprite);
            }
        }
        
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

        public void OnPointerEnter()
        {
            if (this.skill != null)
            {
                RectTransform rt = this.transform.GetComponent<RectTransform>();
                Vector3 position = transform.position + (Vector3)rt.rect.max + new Vector3(5, 0);

                UITooltipController.Show(this.skill, position, new Vector2(0, 1));
            }
            this.animator.SetBool("Pointer", true);
        }

        public void OnPointerExit()
        {
            if (this.skill != null) UITooltipController.Hide();
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
