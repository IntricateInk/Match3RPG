using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITooltip {
    string name { get; }
    string sprite { get; }
    string tooltip { get; }
}
