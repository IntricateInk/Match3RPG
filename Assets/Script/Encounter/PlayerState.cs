using Match3.Character;
using Match3.Encounter.Effect.Skill;
using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Encounter.Effect.Passive;

namespace Match3.Encounter
{
    internal class PlayerState : EncounterSubState
    {
        private readonly int[] resources = new int[(int)TokenType.COUNT];

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
            int i = 0;

            foreach (TrophySheet trophy in parent.playerSheet.trophies)
            {
                foreach (string skill_name in trophy.skills)
                {
                    GameSkill skill = GameSkill.GetSkill(skill_name);

                    if (this.Skills.Contains(skill)) continue;

                    this.Skills.Add(skill);
                    UIAnimationManager.AddAnimation(new UIInstruction_AddSkill(skill, i));
                    i++;
                }

                foreach (string passive_name in trophy.passives)
                {
                    GamePassive passive = GamePassive.GetPassive(passive_name);

                    this.Passives.Add(passive);
                    UIAnimationManager.AddAnimation(new UIInstruction_AddBuff(passive));
                }

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
        
        public void ApplyBuff(string buff_name) { ApplyBuff(GamePassive.GetPassive(buff_name)); }

        public void ApplyBuff(GamePassive buff)
        {
            this.Passives.Add(buff);
        }

        public int GetResource(TokenType type)
        {
            return this.resources[type.AsInt()];
        }

        public void GainResource(TokenType type, int amount)
        {
            this.resources[type.AsInt()] += amount;

            UIAnimationManager.AddAnimation(new UIInstruction_UpdateResources(type, this.GetResource(type)), true);
        }
    }
}
