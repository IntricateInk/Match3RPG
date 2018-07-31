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
        private readonly int[] resources = new int[TokenTypeHelper.ResourceCount()];
        public int[] Resources { get { return (int[])this.resources.Clone(); } }

        public readonly List<CharacterPassive> Passives = new List<CharacterPassive>();
        public readonly List<GameSkill> Skills = new List<GameSkill>();
        
        private int _Energy = 0;
        public int Energy
        {
            get { return _Energy; }
            set
            {
                _Energy = value;

                UIAnimationManager.AddAnimation(new UIInstruction_SetEnergy(this.Energy));
            }
        }

        private int _Turn;
        public int Turn
        {
            get { return this._Turn; }
            set
            {
                this._Turn = value;
                
                UIAnimationManager.AddAnimation(new UIInstruction_SetTurns(this.Turn));
            }
        }

        private float _Time = 0f;

        public float Time {
            get { return this._Time; }
            internal set
            {
                this._Time = value;

                UIAnimationManager.AddInstruction(new UIInstruction_SetTime(this.Time));
            }
        }

        public int MaximumEnergy { get { return 3; } }

        public PlayerState(EncounterState parent) : base(parent)
        {
        }

        internal void Initialize()
        {
            int i = 0;

            foreach (TrophySheet trophy in encounter.playerSheet.trophies)
            {
                foreach (string skill_name in trophy.skills)
                {
                    GameSkill skill = GameSkill.GetSkill(skill_name);

                    if (this.Skills.Contains(skill)) continue;

                    this.Skills.Add(skill);
                    UIAnimationManager.AddInstruction(new UIInstruction_AddSkill(skill, i));
                    i++;
                }

                foreach (string passive_name in trophy.passives)
                {
                    CharacterPassive passive = CharacterPassive.GetPassive(passive_name);

                    this.ApplyBuff(passive);
                }
            }

            foreach (string passive_name in encounter.encounterSheet.passives)
            {
                CharacterPassive passive = CharacterPassive.GetPassive(passive_name);

                this.ApplyBuff(passive);
            }
        }
        
        public void ApplyBuff(CharacterPassive buff)
        {
            this.Passives.Add(buff);
            buff.OnApplyPassive(encounter, new List<TokenState>());
            UIAnimationManager.AddAnimation(new UI_InstructionDisplayBuff(buff, true));
        }
        
        public void RemoveBuff(CharacterPassive buff)
        {
            buff.OnRemovePassive(encounter, new List<TokenState>());
            this.Passives.Remove(buff);
            UIAnimationManager.AddAnimation(new UI_InstructionDisplayBuff(buff, false));
        }

        internal void UseEnergy(int energyCost)
        {
            this.Energy -= energyCost;
        }

        public int GetResource(TokenType type)
        {
            if (type == TokenType.BLANK) return 0;
            return this.resources[type.AsInt()];
        }

        public void GainResource(TokenType type, int amount)
        {
            if (type == TokenType.BLANK) return;

            this.resources[type.AsInt()] += amount;
            this.resources[type.AsInt()] = Mathf.Clamp(this.resources[type.AsInt()], 0, 99);

            UIAnimationManager.AddAnimation(new UIInstruction_UpdateResources(type, this.GetResource(type)));
        }
    }
}
