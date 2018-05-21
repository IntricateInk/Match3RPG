using Match3.Game.Skill;
using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Game
{
    internal class PlayerState : EncounterSubState
    {
        public readonly int[] Resources = new int[(int)TokenType.COUNT];

        public readonly List<TokenType> tokenList = new List<TokenType>();
        public readonly List<GameSkill> skillList = 
            new List<GameSkill>() {
                new GameSkill_Bash(),
                new GameSkill_Sleight()
            };

        private int _Turn;
        public int Turn
        {
            get { return this._Turn; }
            set
            {
                this._Turn = value;
                
                UIAnimationManager.AddAnimation(new UIInstruction_UpdateTurns(this.Turn), true);
            }
        }

        public int Time {
            get; internal set;
        }

        public PlayerState(EncounterState parent) : base(parent)
        {
        }

        public void ResetToken()
        {
            this.tokenList.AddRange(this.encounter.characterSheet.tokenDrawList);
            this.tokenList.Shuffle();
        }

        public TokenType DrawToken()
        {
            if (this.tokenList.Count == 0) this.ResetToken();

            TokenType token = this.tokenList[0];
            this.tokenList.RemoveAt(0);
            return token;
        }
        
        public void GainResource(TokenType type, int amount)
        {
            this.Resources[(int)type] += amount;

            UIAnimationManager.AddAnimation(new UIInstruction_UpdateResources(type, this.Resources[(int)type]), true);
        }
    }
}
