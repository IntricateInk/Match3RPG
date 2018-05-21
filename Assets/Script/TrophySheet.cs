using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Character
{
    public abstract class TrophySheet : ITooltip
    {
        public string name    { get; private set; }
        public string sprite  { get; private set; }
        public string tooltip { get; private set; }

        public abstract void OverworldUse();
        public abstract void EncounterUse();
    }
}