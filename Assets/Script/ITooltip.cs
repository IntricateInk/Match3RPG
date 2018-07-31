using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.UI;

public interface ITooltip {
    string name { get; }
    string sprite { get; }
    string tooltip { get; }
}

public static class ITooltipExtensions
{
    public static Sprite GetSprite(this ITooltip tooltip)
    {
        return Resources.Load<Sprite>(tooltip.sprite);
    }
}
