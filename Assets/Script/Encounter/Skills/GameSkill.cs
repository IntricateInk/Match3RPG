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
            get { return string.Format("Cost: {0}\n{1}", costString, _tooltip); }
            private set
            {
                this._tooltip = value;
            }
        }

        public string costString
        {
            get
            {
                return new string('S', strCost) + new string('A', agiCost) + 
                    new string('I', intCost) + new string('C', chaCost) + 
                    new string('L', lukCost);
            }
        }

        internal GameSkill(
                string name, 
                string sprite, 
                string tooltip,
                SelectBehavior selectBehavior,
                Effect.GameEffect.Action[] runEffects,

                int strCost = 0,
                int agiCost = 0,
                int intCost = 0,
                int chaCost = 0,
                int lukCost = 0
            )
        {
            this.name = name;
            this.sprite = sprite;
            this.tooltip = tooltip;

            this.strCost = strCost;
            this.agiCost = agiCost;
            this.intCost = intCost;
            this.chaCost = chaCost;
            this.lukCost = lukCost;

            this.selectBehavior = selectBehavior;
            this.runEffects = runEffects;

            _AllSkills.Add(name, this);
        }

        private readonly int strCost;
        private readonly int agiCost;
        private readonly int intCost;
        private readonly int chaCost;
        private readonly int lukCost;
        private readonly GameEffect.Action[] runEffects;

        // Cost

        internal bool CanPayCost(EncounterState encounter)
        {
            PlayerState player = encounter.playerState;

            if (player.GetResource(TokenType.STRENGTH)     < strCost) return false;
            if (player.GetResource(TokenType.AGILITY)      < agiCost) return false;
            if (player.GetResource(TokenType.INTELLIGENCE) < intCost) return false;
            if (player.GetResource(TokenType.CHARISMA)     < chaCost) return false;
            if (player.GetResource(TokenType.LUCK)         < lukCost) return false;

            return true;
        }

        private void PayCost(EncounterState encounter)
        {
            PlayerState player = encounter.playerState;

            player.GainResource(TokenType.STRENGTH    , -strCost);
            player.GainResource(TokenType.AGILITY     , -agiCost);
            player.GainResource(TokenType.INTELLIGENCE, -intCost);
            player.GainResource(TokenType.CHARISMA    , -chaCost);
            player.GainResource(TokenType.LUCK        , -lukCost);
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
            GameEffect.Invoke(this.runEffects, encounter, tokens);
        }

        // Factory Pattern

        private static Dictionary<string, GameSkill> _AllSkills = new Dictionary<string, GameSkill>();
        
        public static GameSkill GetSkill(string name)
        {
            return _AllSkills[name];
        }
    }
}
