using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Character;

namespace Match3.Encounter.Encounter
{
    public sealed partial class EncounterObjective : ITooltip
    {
        public EncounterObjective
            (
            string uid,
            string name,
            string sprite,
            string tooltip,
            
            int GoldReward = 0,
            int ExpReward  = 0,
            string[] TrophyReward = null,

            int MinStrength = -1,
            int MaxStrength = 100,

            int MinAgility = -1,
            int MaxAgility = 100,

            int MinIntelligence = -1,
            int MaxIntelligence = 100,

            int MinCharisma = -1,
            int MaxCharisma = 100,

            int MinLuck = -1,
            int MaxLuck = 100,

            int MinTurn = -1,
            int MaxTurn = 100
            )
        {
            if (TrophyReward == null) TrophyReward = new string[0];

            this.name = name;
            this.sprite = sprite;
            this.tooltip = tooltip;

            this.GoldReward   = GoldReward;
            this.ExpReward    = ExpReward;
            this.TrophyReward = TrophyReward;

            this.MinStrength = MinStrength;
            this.MaxStrength = MaxStrength;

            this.MinAgility = MinAgility;
            this.MaxAgility = MaxAgility;

            this.MinIntelligence = MinIntelligence;
            this.MaxIntelligence = MaxIntelligence;

            this.MinCharisma = MinCharisma;
            this.MaxCharisma = MaxCharisma;

            this.MinLuck = MinLuck;
            this.MaxLuck = MaxLuck;
            
            this.MinTurn = MinTurn;
            this.MaxTurn = MaxTurn;

            _AllObjectives.Add(uid, this);
        }

        public string name { get; private set; }
        public string sprite { get; private set; }
        public string tooltip { get; private set; }
        
        public int MinStrength;
        public int MaxStrength;

        public int MinAgility;
        public int MaxAgility;

        public int MinIntelligence;
        public int MaxIntelligence;

        public int MinCharisma;
        public int MaxCharisma;

        public int MinLuck;
        public int MaxLuck;
        
        public int MinTurn;
        public int MaxTurn;

        public readonly int GoldReward;
        public readonly int ExpReward;
        public readonly string[] TrophyReward;

        internal bool isCompleted(PlayerState player)
        {
            // str
            int str = player.GetResource(TokenType.STRENGTH);

            if (str > this.MaxStrength) return false;
            if (str < this.MinStrength) return false;

            // agi
            int agi = player.GetResource(TokenType.AGILITY);

            if (agi > this.MaxAgility) return false;
            if (agi < this.MinAgility) return false;

            // int
            int intl = player.GetResource(TokenType.INTELLIGENCE);

            if (intl > this.MaxIntelligence) return false;
            if (intl < this.MinIntelligence) return false;

            // cha
            int cha = player.GetResource(TokenType.CHARISMA);

            if (cha > this.MaxCharisma) return false;
            if (cha < this.MinCharisma) return false;

            // luk
            int luck = player.GetResource(TokenType.LUCK);

            if (luck > this.MaxLuck) return false;
            if (luck < this.MinLuck) return false;

            // turn
            int turn = player.Turn;

            if (turn > this.MaxTurn) return false;
            if (turn < this.MinTurn) return false;
            
            return true;
        }

        // Factory Method
        
        private static Dictionary<string, EncounterObjective> _AllObjectives = new Dictionary<string, EncounterObjective>();

        internal static EncounterObjective[] GetObjective(string[] uids)
        {
            return Array.ConvertAll<string, EncounterObjective>(uids, GetObjective);
        }
        
        internal static EncounterObjective GetObjective(string uid)
        {
            return _AllObjectives[uid];
        }
    }
}