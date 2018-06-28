using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Character
{
    public sealed partial class TrophySheet : ITooltip
    {
        public string name    { get; private set; }
        public string sprite  { get; private set; }
        public string tooltip { get; private set; }

        public readonly string[] skills;
        public readonly string[] passives;

        public void OverworldUse() { }

        private TrophySheet
        (
            string name, 
            string sprite, 
            string tooltip, 
            string[] skills = null,
            string[] passives = null
        )
        {
            if (skills == null) skills = new string[0];
            if (passives == null) passives = new string[0];

            this.name = name;
            this.sprite = sprite;
            this.tooltip = tooltip;
            this.skills = skills;
            this.passives = passives;

            _AllTrophies.Add(name, this);
        }
        
        private static Dictionary<string, TrophySheet> _AllTrophies = new Dictionary<string, TrophySheet>();

        public static TrophySheet[] GetTrophy(string[] ids)
        {
            return Array.ConvertAll<string, TrophySheet>(ids, GetTrophy);
        }

        public static TrophySheet GetTrophy(string id)
        {
            return _AllTrophies[id];
        }
    }
}