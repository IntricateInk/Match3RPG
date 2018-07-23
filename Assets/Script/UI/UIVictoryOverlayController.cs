using Match3.Encounter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    public class UIVictoryOverlayController : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private Text goldLabel;

        [SerializeField]
        private Text expLabel;

        [SerializeField]
        private Text trophyLabel;

        internal void Show(float gold, float exp, string[] trophies)
        {
            this.goldLabel.text = gold.ToString();
            this.expLabel.text = exp.ToString();
            this.trophyLabel.text = string.Join("\n", trophies);
            this.animator.SetBool("Popup", true);
        }

        public void OnOverworldButtonClick()
        {
            EncounterState.Current.ReturnToOverworld();
        }
    }
}