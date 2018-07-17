using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Encounter
{
    public sealed partial class EncounterObjective : ITooltip
    {
		
        public static EncounterObjective TEST_1 = new EncounterObjective
        (
			uid: "TEST_1",
            name: "Beat Up",
            sprite: "skills/bash",
            tooltip: "Beat up the bandits",
			
			GoldReward: 10,
            ExpReward: 5,
            TrophyReward: new string[] {
"Honor"
},
            
            MinStrength: 30,
            MaxStrength: 60, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTime: -1,
            MaxTime: 301,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective TEST_2 = new EncounterObjective
        (
			uid: "TEST_2",
            name: "Punch",
            sprite: "skills/bash",
            tooltip: "A satisfying punch!",
			
			GoldReward: 20,
            ExpReward: 4,
            TrophyReward: new string[] {
"Bloodthristy"
},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 0,
            MaxAgility: 20,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: 1,
            MaxLuck: 99,

            MinTime: -1,
            MaxTime: 301,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective TEST = new EncounterObjective
        (
			uid: "TEST",
            name: "sample",
            sprite: "",
            tooltip: "You shouldn't be seeing this",
			
			GoldReward: 30,
            ExpReward: 3,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTime: -1,
            MaxTime: 301,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective TEST_3 = new EncounterObjective
        (
			uid: "TEST_3",
            name: "Turn Test",
            sprite: "skills/bash",
            tooltip: "Efficiency!",
			
			GoldReward: 40,
            ExpReward: 2,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTime: -1,
            MaxTime: 301,

            MinTurn: 10,
            MaxTurn: 99
        );


        public static EncounterObjective TEST_4 = new EncounterObjective
        (
			uid: "TEST_4",
            name: "Time Test",
            sprite: "skills/bash",
            tooltip: "Your time is running out",
			
			GoldReward: 50,
            ExpReward: 1,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTime: 0,
            MaxTime: 60,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective mole_encounter_1_main_loss = new EncounterObjective
        (
			uid: "mole_encounter_1_main_loss",
            name: "Burried alive",
            sprite: "tokens/agi",
            tooltip: "You were slower than a bunch of moles, and got burried alive. RIP",
			
			GoldReward: -20,
            ExpReward: -10,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 0,
            MaxAgility: 10,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTime: -1,
            MaxTime: 301,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective mole_encounter_1_bonus = new EncounterObjective
        (
			uid: "mole_encounter_1_bonus",
            name: "Befriend the Mole",
            sprite: "tokens/cha",
            tooltip: "Moles are friends, not food. Am I doing this right?",
			
			GoldReward: 0,
            ExpReward: 0,
            TrophyReward: new string[] {
"Tamed Mole?"
},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: 80,
            MaxCharisma: 99,

            MinLuck: -1,
            MaxLuck: 100,

            MinTime: -1,
            MaxTime: 301,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective mole_encounter_1_main_agi_50 = new EncounterObjective
        (
			uid: "mole_encounter_1_main_agi_50",
            name: "Escape the moles!",
            sprite: "tokens/agi",
            tooltip: "Jack be nimble, Jack be quick, Jack jump over all the holes, wow there are a lot of holes.",
			
			GoldReward: 0,
            ExpReward: 50,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 50,
            MaxAgility: 99,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTime: -1,
            MaxTime: 301,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective mole_encounter_1_main_agi_60 = new EncounterObjective
        (
			uid: "mole_encounter_1_main_agi_60",
            name: "Escape the moles!",
            sprite: "tokens/agi",
            tooltip: "Jack be nimble, Jack be quick, Jack jump over all the holes, wow there are a lot of holes.",
			
			GoldReward: 0,
            ExpReward: 50,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 60,
            MaxAgility: 99,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTime: -1,
            MaxTime: 301,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective mole_encounter_1_main_agi_70 = new EncounterObjective
        (
			uid: "mole_encounter_1_main_agi_70",
            name: "Escape the moles!",
            sprite: "tokens/agi",
            tooltip: "Jack be nimble, Jack be quick, Jack jump over all the holes, wow there are a lot of holes.",
			
			GoldReward: 0,
            ExpReward: 50,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 70,
            MaxAgility: 99,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTime: -1,
            MaxTime: 301,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective mole_encounter_1_main_agi_80 = new EncounterObjective
        (
			uid: "mole_encounter_1_main_agi_80",
            name: "Escape the moles!",
            sprite: "tokens/agi",
            tooltip: "Jack be nimble, Jack be quick, Jack jump over all the holes, wow there are a lot of holes.",
			
			GoldReward: 0,
            ExpReward: 50,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 80,
            MaxAgility: 99,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTime: -1,
            MaxTime: 301,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective mole_encounter_1_main_agi_90 = new EncounterObjective
        (
			uid: "mole_encounter_1_main_agi_90",
            name: "Escape the moles!",
            sprite: "tokens/agi",
            tooltip: "Jack be nimble, Jack be quick, Jack jump over all the holes, wow there are a lot of holes.",
			
			GoldReward: 0,
            ExpReward: 50,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 90,
            MaxAgility: 99,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTime: -1,
            MaxTime: 301,

            MinTurn: -1,
            MaxTurn: 100
        );


    }
}
