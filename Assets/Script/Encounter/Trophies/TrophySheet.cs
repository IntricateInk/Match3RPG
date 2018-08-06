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

        private string _tooltip;
        public string tooltip {
            get
            {
                string skill_desc = "<size=16><b>Skills</b></size>\n";
                foreach (string skill in this.skills)
                {
                    skill_desc += skill;
                    skill_desc += "\n";
                }

                string passive_desc = "<size=16><b>Passives</b></size>\n";
                foreach (string passive in this.passives)
                {
                    passive_desc += passive;
                    passive_desc += "\n"; 
                }

                return string.Format("{0}{1}\n<i><size=10>{2}</size></i>", skill_desc, passive_desc, this._tooltip);
            }
            private set { this._tooltip = value; }
        }

        public readonly int expCost;

        public readonly string[] skills;
        public readonly string[] passives;
        public readonly string[] upgrades;
        
        private TrophySheet
        (
            string name, 
            string sprite, 
            string tooltip, 

            int expCost,
            
            string[] skills = null,
            string[] passives = null,
            string[] upgrades = null
        )
        {
            if (skills == null) skills = new string[0];
            if (passives == null) passives = new string[0];
            if (upgrades == null) upgrades = new string[0];

            this.name = name;
            this.sprite = sprite;
            this.tooltip = tooltip;

            this.expCost = expCost;
            
            this.skills = skills;
            this.passives = passives;
            this.upgrades = upgrades;

            _AllTrophies.Add(name, this);
        }
        
        private static Dictionary<string, TrophySheet> _AllTrophies = new Dictionary<string, TrophySheet>();
        public static List<TrophySheet> AllTrophies { get { return new List<TrophySheet>(_AllTrophies.Values); } }

        public static TrophySheet[] GetTrophy(string[] ids)
        {
            return Array.ConvertAll<string, TrophySheet>(ids, GetTrophy);
        }

        public static TrophySheet GetTrophy(string id)
        {
            return _AllTrophies[id];
        }


        public static List<KeyValuePair<string, TrophySheet>> getAllClasses()
        {
            return new List<KeyValuePair<string, TrophySheet>> {
                new KeyValuePair<string, TrophySheet> ("Warrior", TrophySheet.CLASS_WARRIOR),
                new KeyValuePair<string, TrophySheet> ("Thief", TrophySheet.CLASS_THIEF),
                new KeyValuePair<string, TrophySheet> ("Tamer", TrophySheet.CLASS_TAMER),
                new KeyValuePair<string, TrophySheet> ("Swindler", TrophySheet.CLASS_SWINDLER),
                new KeyValuePair<string, TrophySheet> ("Strategist", TrophySheet.CLASS_STRATEGIST),
                new KeyValuePair<string, TrophySheet> ("Shaman", TrophySheet.CLASS_SHAMAN),
                new KeyValuePair<string, TrophySheet> ("Scholar", TrophySheet.CLASS_SCHOLAR),
                new KeyValuePair<string, TrophySheet> ("Pyromaniac", TrophySheet.CLASS_PYROMANIC),
                new KeyValuePair<string, TrophySheet> ("Noble", TrophySheet.CLASS_NOBLE),
                new KeyValuePair<string, TrophySheet> ("Necromancer", TrophySheet.CLASS_NECROMANCER),
                new KeyValuePair<string, TrophySheet> ("Monk", TrophySheet.CLASS_MONK),
                new KeyValuePair<string, TrophySheet> ("Jester", TrophySheet.CLASS_JESTER),
                new KeyValuePair<string, TrophySheet> ("Captain", TrophySheet.CLASS_CAPTAIN),
                new KeyValuePair<string, TrophySheet> ("Berseker", TrophySheet.CLASS_BERSERKER),


            };
        }

        // warrior thief
        // Monk Scholar
        public static TrophySheet[] getSimpleClass(string className)
        {
            if (className == "Brigand")
            {
                TrophySheet[] t = new TrophySheet[2]
                {
                    TrophySheet.CLASS_WARRIOR,
                    TrophySheet.CLASS_THIEF
                };

                return t;
            } else if (className == "Vagabond")
            {
                TrophySheet[] t = new TrophySheet[2]
                {
                    TrophySheet.CLASS_MONK,
                    TrophySheet.CLASS_SCHOLAR,
                };
                return t;
            } else
            {
                throw new System.Exception("Class not supported in simple mode");
            }
        }
    }
}