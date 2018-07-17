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
        
        internal void Show(string text)
        {
            this.label.text = text;
            this.animator.Play("Popup");
        }
    }
}
