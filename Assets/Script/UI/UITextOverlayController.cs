using Match3.UI.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    public class UITextOverlayController : MonoBehaviour
    {
        [SerializeField]
        private Text label;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private Image image;

        [SerializeField]
        private UIAnimationManager manager;

        internal void Show(string text, bool pause_until_click)
        {
            if (pause_until_click)
            {
                manager.IsPaused = true;
                this.animator.SetBool("AutoDismiss", false);
                this.image.raycastTarget = true;
            }

            this.label.text = text;
            this.animator.Play("Popup");
        }

        public void OnClick()
        {
            manager.IsPaused = false;
            this.animator.SetBool("AutoDismiss", true);
            this.image.raycastTarget = false;
        }
    }
}
