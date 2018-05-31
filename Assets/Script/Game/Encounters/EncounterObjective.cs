using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Character;

namespace Match3.Game.Encounter
{

    public struct EncounterObjectiveCondition
    {
        public int Strength;
        public int Agility;
        public int Intelligence;
        public int Charisma;
        public int Luck;
        public int Time;
        public int Turn;

        public Condition StrengthCondition;
        public Condition AgilityCondition;
        public Condition IntelligenceCondition;
        public Condition CharismaCondition;
        public Condition LuckCondition;
        public Condition TimeCondition;
        public Condition TurnCondition;

        public EncounterObjectiveCondition(
            int Strength = 0,
            int Agility = 0,
            int Intelligence = 0,
            int Charisma = 0,
            int Luck = 0,
            int Time = 0,
            int Turn = 0,

            Condition StrengthCondition = Condition.NONE,
            Condition AgilityCondition = Condition.NONE,
            Condition IntelligenceCondition = Condition.NONE,
            Condition CharismaCondition = Condition.NONE,
            Condition LuckCondition = Condition.NONE,
            Condition TimeCondition = Condition.NONE,
            Condition TurnCondition = Condition.NONE
        )
        {
            this.Strength = Strength;
            this.Agility = Agility;
            this.Intelligence = Intelligence;
            this.Charisma = Charisma;
            this.Luck = Luck;
            this.Time = Time;
            this.Turn = Turn;

            this.StrengthCondition = StrengthCondition;
            this.AgilityCondition = AgilityCondition;
            this.IntelligenceCondition = IntelligenceCondition;
            this.CharismaCondition = CharismaCondition;
            this.LuckCondition = LuckCondition;
            this.TimeCondition = TimeCondition;
            this.TurnCondition = TurnCondition;
        }

        public enum Condition
        {
            EQUAL_AND_LESS,
            EQUAL_AND_MORE,
            EQUAL,
            NONE
        }
    }

    public sealed class EncounterObjective : ITooltip
    {
        public EncounterObjective
            (
            string name,
            string sprite,
            string tooltip,
            EncounterObjectiveCondition condition,
            Reward reward
            )
        {
            this.name = name;
            this.sprite = sprite;
            this.tooltip = tooltip;
            this.completion = condition;
            this.reward = reward;
        }

        public string name { get; private set; }
        public string sprite { get; private set; }
        public string tooltip { get; private set; }
        public readonly Reward reward;

        private readonly EncounterObjectiveCondition completion;

        internal bool isCompleted(PlayerState player)
        {
            // str
            if (!this.DoCheck(
                player.Resources[(int)TokenType.STRENGTH],
                completion.Strength, completion.StrengthCondition))
                return false;

            // agi
            if (!this.DoCheck(
                player.Resources[(int)TokenType.AGILITY],
                completion.Agility, completion.AgilityCondition))
                return false;

            // int
            if (!this.DoCheck(
                player.Resources[(int)TokenType.INTELLIGENCE],
                completion.Intelligence, completion.IntelligenceCondition))
                return false;

            // cha
            if (!this.DoCheck(
                player.Resources[(int)TokenType.CHARISMA],
                completion.Charisma, completion.CharismaCondition))
                return false;

            // luk
            if (!this.DoCheck(
                player.Resources[(int)TokenType.LUCK],
                completion.Luck, completion.LuckCondition))
                return false;
            
            // turn
            if (!this.DoCheck(player.Turn,
                completion.Turn, completion.TurnCondition))
                return false;

            // time
            if (!this.DoCheck(player.Time, 
                completion.Time, completion.TimeCondition))
                return false;

            return true;
        }
        
        private bool DoCheck(float value, int checkValue, EncounterObjectiveCondition.Condition condition)
        {
            return DoCheck((int)value, checkValue, condition);
        }

        private bool DoCheck(int value, int checkValue, EncounterObjectiveCondition.Condition condition)
        {
            switch (condition)
            {
                case EncounterObjectiveCondition.Condition.EQUAL:
                    return value == checkValue;
                case EncounterObjectiveCondition.Condition.EQUAL_AND_LESS:
                    return value <= checkValue;
                case EncounterObjectiveCondition.Condition.EQUAL_AND_MORE:
                    return value >= checkValue;
                default:
                    return true;
            }
        }
    }
}