using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Character
{
    public sealed class TrophySheet : ITooltip
    {
        public string name    { get; private set; }
        public string sprite  { get; private set; }
        public string tooltip { get; private set; }

        public void OverworldUse() { }
        public void EncounterUse() { }

        private TrophySheet(string name, string sprite, string tooltip)
        {
            this.name = name;
            this.sprite = sprite;
            this.tooltip = tooltip;
        }

        // Factory Method

        public static TrophySheet[] GetTrophy(string[] ids)
        {
            TrophySheet[] trophies = new TrophySheet[ids.Length];

            for (int i = 0; i < ids.Length; i++)
                trophies[i] = GetTrophy(ids[i]);

            return trophies;
        }

        public static TrophySheet GetTrophy(string id)
        {
            return new TrophySheet(id, "skills/influence", "Testing");
        }
    }
}