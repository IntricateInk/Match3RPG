using Match3.Character;
using Match3.Encounter.Passive;
using Match3.Encounter.Skill;
using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter
{
    internal class PlayerState : EncounterSubState
    {
        public readonly int[] Resources = new int[(int)TokenType.COUNT];

        public readonly List<TokenType> tokenList = new List<TokenType>();
        public readonly List<GamePassive> Passives = new List<GamePassive>();
        public readonly List<GameSkill> Skills = new List<GameSkill>();

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

        private float _Time = 0f;
        public float Time {
            get { return this._Time; }
            internal set
            {
                this._Time = value;

                UIAnimationManager.AddAnimation(new UIInstruction_SetTime(this.Time));
            }
        }

        public PlayerState(EncounterState parent) : base(parent)
        {
            foreach (TrophySheet trophy in parent.playerSheet.trophies)
            {
                foreach (string skill_name in trophy.skills)
                    this.Skills.Add(GameSkill.GetSkill(skill_name));

                foreach (string passive_name in trophy.passives)
                    this.Passives.Add(GamePassive.GetPassive(passive_name));
            }
        }

        public void ResetToken()
        {
            this.tokenList.AddRange(this.encounter.playerSheet.tokenDrawList);
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
