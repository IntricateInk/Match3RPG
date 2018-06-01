using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Match3.Encounter;
using System;

namespace Match3.UI
{
    [RequireComponent(typeof(Image))]
    public class UITokenController : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        internal int x;
        internal int y;

        internal UIBoardController board;
        
        internal void SetType(TokenType type) { this.image.sprite = type.GetSprite(); }
        internal void SetColor(Color color) { this.image.color = color; }

        public void OnButtonDown()
        {
            EncounterState.Current.SelectToken(this.x, this.y);
        }
    }
}