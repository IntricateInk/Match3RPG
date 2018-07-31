using Match3.Encounter;
using Match3.Encounter.Encounter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    public class UIVictoryOverlayController : MonoBehaviour
    {
        [SerializeField]
        private Transform objectiveContainer;

        [SerializeField]
        private Animator animator;
        
        internal void Show(List<UIObjectiveController> objectives)
        {
            foreach (UIObjectiveController objective in objectives)
            {
                objective.transform.SetParent(this.objectiveContainer);
            }

            this.animator.SetBool("Popup", true);
        }

        public void OnOverworldButtonClick()
        {
            EncounterState.Current.ReturnToOverworld();
        }
    }
}