using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.UI
{
    public class UITileController : MonoBehaviour
    {
        internal UITokenController token;
        internal UIBoardController board;

        internal void Highlight(bool is_highlight)
        {
            if (is_highlight)
                board.SetLayer(this.transform, 1);
            else
                board.SetLayer(this.transform, 0);
        }
    }
}