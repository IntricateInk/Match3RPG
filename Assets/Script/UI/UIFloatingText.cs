using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI
{
    public class UIFloatingText : MonoBehaviour
    {
        [SerializeField]
        private Text label;

        internal string text
        {
            get { return this.label.text; }
            set { this.label.text = value; }
        }

        private float alphaFadeSpeed = 255f;
        private float ySpeed = 10f;
        private float lifeTime = 1f;

        // Use this for initialization
        void Start()
        {
            Destroy(this.gameObject, lifeTime);
        }

        private void Update()
        {
            this.transform.position += new Vector3(0, ySpeed * Time.deltaTime);
            this.label.color += new Color(0, 0, 0, alphaFadeSpeed * Time.deltaTime);
        }
    }
}