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
			
			GoldReward: 0,
            ExpReward: 0,
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
			
			GoldReward: 0,
            ExpReward: 0,
            TrophyReward: new string[] {
"Bloodthristy"
},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 20,
            MaxAgility: 30,

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
			
			GoldReward: 0,
            ExpReward: 0,
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
			
			GoldReward: 0,
            ExpReward: 0,
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
			
			GoldReward: 0,
            ExpReward: 0,
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

            MinTurn: 0,
            MaxTurn: 60
        );


    }
}
