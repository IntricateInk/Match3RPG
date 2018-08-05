using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public string name    { get; private set; }
        public string sprite  { get; private set; }

        private string _tooltip;
        public string tooltip
        {
            get { return _tooltip; }
            private set
            {
                this._tooltip = value;
            }
        }
        
        internal GameSkill(
                string name, 
                string sprite, 
                string tooltip,
                SelectBehavior selectBehavior,
                GameEffect.SkillAction runEffects,

                int energyCost
            )
        {
            this.name = name;
            this.sprite = sprite;
            this.tooltip = tooltip;

            this.energyCost = energyCost;
            
            this.selectBehavior = selectBehavior;
            this.runEffects = runEffects;

            _AllSkills.Add(name, this);
        }

        public readonly int energyCost;
        private readonly GameEffect.SkillAction runEffects;

        // Cost

        internal bool CanPayCost(EncounterState encounter)
        {
            return CanPayCost(encounter.playerState.Energy);
        }
        public bool CanPayCost(int energy)
        {
            return energy >= this.energyCost;
        }

        private void PayCost(EncounterState encounter)
        {
            PlayerState player = encounter.playerState;

            player.UseEnergy(energyCost);
        }

        // Select Behavior

        private readonly SelectBehavior selectBehavior;

        internal void Select(InputState input, TokenState token)
            { this.selectBehavior.Select(input, token); }

        internal bool ShouldRun(List<TokenState> selectedToken)
            { return this.selectBehavior.ShouldRun(selectedToken); }

        // Run Behavior

        internal void Run(EncounterState encounter)
        {
            this.PayCost(encounter);

            List<TokenState> tokens = new List<TokenState>(encounter.inputState.selectedTokens);
            this.runEffects(this, encounter, tokens);
        }
        
        // Factory Pattern

        private static Dictionary<string, GameSkill> _AllSkills = new Dictionary<string, GameSkill>();

        public static GameSkill GetSkill(string name)
        {
            try
            {
                return _AllSkills[name];
            } catch (Exception e)
            {
                Debug.Log(name);
                throw e;
            }
        }
    }
}
