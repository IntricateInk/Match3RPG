using Match3.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Overworld
{
    public class SkillItemController : MonoBehaviour
    {
        [SerializeField]
        private SkillTreeController skillTree;

        [SerializeField]
        private string itemName;

        [SerializeField]
        private Text titleLabel;

        [SerializeField]
        private Image icon;

        [SerializeField]
        private Text descLabel;

        public TrophySheet trophy { get; private set; }

        // Use this for initialization
        void Awake()
        {
            this.trophy = TrophySheet.GetTrophy(itemName);

            titleLabel.text = trophy.name;
            icon.sprite = trophy.GetSprite();
            descLabel.text = trophy.tooltip;

            this.skillTree.RegisterNode(this);
        }
    }
}