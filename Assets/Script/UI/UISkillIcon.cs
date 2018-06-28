using Match3.Encounter;
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

        public string skillName
        {
            get { return this.label.text; }
            set { this.label.text = value; }
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
        
        [NonSerialized]
        public int index;

        public void OnButtonDown()
        {
            EncounterState.Current.SelectSkill(this.index);
        }
    }
}
