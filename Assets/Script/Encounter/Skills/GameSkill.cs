using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Skill
{
    public abstract class GameSkill : ITooltip
    {
        public string name    { get; private set; }
        public string sprite  { get; private set; }
        public string tooltip { get; private set; }
        
        protected GameSkill(string name, string sprite, string tooltip)
        {
            this.name = name;
            this.sprite = sprite;
            this.tooltip = tooltip;

            _AllSkills.Add(name, this);
        }

        internal abstract void Select(InputState input, TokenState token);
        internal abstract bool ShouldRun(List<TokenState> selectedToken);
        internal abstract void Run(EncounterState encounter);


        private static Dictionary<string, GameSkill> _AllSkills = new Dictionary<string, GameSkill>();

        public static void Init()
        {
            new GameSkill_Bash();
            new GameSkill_Sleight();
        }

        public static GameSkill GetSkill(string name)
        {
            return _AllSkills[name];
        }
    }
}
