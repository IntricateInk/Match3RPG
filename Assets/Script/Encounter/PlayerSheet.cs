using Match3.Encounter.Encounter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Match3.Character
{
    public class PlayerSheet : ITooltip
    {

        public int Gold;
        public int Experience;
        
        public readonly List<TrophySheet> trophies;

        public string name    { get; private set; }
        public string sprite  { get; private set; }
        public string tooltip { get; private set; }

        public event Action<TrophySheet> OnNewTrophy;

        public PlayerSheet(string name, string sprite, string tooltip, params string[] trophies)
        {
            this.name = name;
            this.sprite = sprite;
            this.tooltip = tooltip;

            this.Gold       = 100;
            this.Experience = 100;
            
            this.trophies = new List<TrophySheet>(TrophySheet.GetTrophy(trophies));
        }

        public void GainReward(EncounterObjective objective)
        {
            //this.Gold       += objective.GoldReward;
            //this.Experience += objective.ExpReward;

            //foreach (string trophyName in objective.TrophyReward)
            //{
            //    this.trophies.Add(TrophySheet.GetTrophy(trophyName));
            //}

            this.GainReward(objective.GoldReward, objective.ExpReward, objective.TrophyReward);
        }

        public void GainReward(int goldReward, int expReward, string[] trophyReward)
        {
            this.Gold += goldReward;
            this.Experience += expReward;

            foreach (string trophyName in trophyReward)
            {
                this.trophies.Add(TrophySheet.GetTrophy(trophyName));
                
            }
        }

        public void GainReward(int goldReward, int expReward, TrophySheet trophyReward)
        {
            this.Gold += goldReward;
            this.Experience += expReward;
            this.trophies.Add(trophyReward);

        }

        public List<TrophySheet> getTrophyNotOwned()
        {
            List<TrophySheet> alltrophies = TrophySheet.AllTrophies;

            // reverse intersect list, thanks stack overflow
            var difference = new HashSet<TrophySheet>(trophies);
            difference.SymmetricExceptWith(alltrophies);

            List<TrophySheet> trophyNotOwded = difference.ToList<TrophySheet>();

            return trophyNotOwded;
		}

        internal bool LearnTrophy(TrophySheet trophy)
        {
            if (this.trophies.Contains(trophy) || this.Experience < trophy.expCost) return false;

            this.Experience -= trophy.expCost;
            this.AddTrophy(trophy);

            return true;
        }

        public List<TrophySheet> GetUpgrades()
        {
            List<TrophySheet> upgrades = new List<TrophySheet>();

            foreach (TrophySheet trophy in this.trophies)
            {
                foreach (TrophySheet upgrade in TrophySheet.GetTrophy(trophy.upgrades))
                {
                    if (!this.trophies.Contains(upgrade) && !upgrades.Contains(upgrade))
                        upgrades.Add(upgrade);
                }
            }

            return upgrades;
        }
        

        public void AddTrophy(TrophySheet trophy)
        {
            this.trophies.Add(trophy);

            if (this.OnNewTrophy != null) this.OnNewTrophy(trophy);
        }
    }
}
