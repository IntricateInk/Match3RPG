using Match3.Encounter.Encounter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Character
{
    public class PlayerSheet : ITooltip
    {

        public int Gold;
        public int Experience;

        public readonly List<TokenType> tokenDrawList;
        public readonly List<TrophySheet> trophies;

        public string name    { get; private set; }
        public string sprite  { get; private set; }
        public string tooltip { get; private set; }

        public PlayerSheet(string name, string sprite, string tooltip, params string[] trophies)
        {
            this.name = name;
            this.sprite = sprite;
            this.tooltip = tooltip;

            this.Gold = 0;
            this.Experience = 0;

            this.tokenDrawList = new List<TokenType>()
            {
                TokenType.STRENGTH,
                TokenType.AGILITY,
                TokenType.CHARISMA,
                TokenType.INTELLIGENCE,
                TokenType.LUCK,
            };

            this.trophies = new List<TrophySheet>(TrophySheet.GetTrophy(trophies));
        }

        public void GainReward(EncounterObjective objective)
        {
            this.Gold       += objective.GoldReward;
            this.Experience += objective.ExpReward;

            foreach (string trophyName in objective.TrophyReward)
            {
                this.trophies.Add(TrophySheet.GetTrophy(trophyName));
            }
        }
    }
}
