using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI
{
    public class UICanvasScaler : MonoBehaviour
    {
        [SerializeField]
        private Camera cam;

        [SerializeField]
        private Canvas canvas;

        // Use this for initialization
        void Start()
        {
            this.cam.orthographicSize = Screen.height / 2;
            this.canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        }
    }
}