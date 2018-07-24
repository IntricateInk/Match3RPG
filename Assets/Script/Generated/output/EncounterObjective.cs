using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Encounter
{
    public sealed partial class EncounterObjective : ITooltip
    {
		
        public static EncounterObjective mole_main_loss = new EncounterObjective
        (
			uid: "mole_main_loss",
            name: "Burried alive",
            sprite: "tokens/agi",
            tooltip: "You were slower than a bunch of moles, and got burried alive. RIP",
			
			GoldReward: -20,
            ExpReward: -10,
            TrophyReward: new string[] {},
            
            MinStrength: 0,
            MaxStrength: 10, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective mole_1_main_agi = new EncounterObjective
        (
			uid: "mole_1_main_agi",
            name: "Escape the moles!",
            sprite: "tokens/agi",
            tooltip: "Jack be nimble, Jack be quick, Jack jump over all the holes, wow there are a lot of holes.",
			
			GoldReward: 0,
            ExpReward: 50,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 30,
            MaxAgility: 99,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective mole_2_main_agi = new EncounterObjective
        (
			uid: "mole_2_main_agi",
            name: "Escape the moles!",
            sprite: "tokens/agi",
            tooltip: "Jack be nimble, Jack be quick, Jack jump over all the holes, wow there are a lot of holes.",
			
			GoldReward: 0,
            ExpReward: 50,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 45,
            MaxAgility: 99,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective mole_3_main_agi = new EncounterObjective
        (
			uid: "mole_3_main_agi",
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

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective mole_1_main_cha = new EncounterObjective
        (
			uid: "mole_1_main_cha",
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

            MinCharisma: 50,
            MaxCharisma: 99,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective mole_2_main_cha = new EncounterObjective
        (
			uid: "mole_2_main_cha",
            name: "Befriend the Mole",
            sprite: "tokens/cha",
            tooltip: "Moles are friends, not food. Am I doing this right?",
			
			GoldReward: 0,
            ExpReward: 50,
            TrophyReward: new string[] {
"Tamed Mole?"
},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: 60,
            MaxCharisma: 99,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective mole_3_main_cha = new EncounterObjective
        (
			uid: "mole_3_main_cha",
            name: "Befriend the Mole",
            sprite: "tokens/cha",
            tooltip: "Moles are friends, not food. Am I doing this right?",
			
			GoldReward: 0,
            ExpReward: 100,
            TrophyReward: new string[] {
"Tamed Mole?"
},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: 70,
            MaxCharisma: 99,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective mole_bonus_luk = new EncounterObjective
        (
			uid: "mole_bonus_luk",
            name: "Unearthed Treasure",
            sprite: "tokens/luk",
            tooltip: "Would you look at that, it's treasure!",
			
			GoldReward: 100,
            ExpReward: 0,
            TrophyReward: new string[] {
"Golden Coin"
},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: 80,
            MaxLuck: 99,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective phantom_main_agi_str_win = new EncounterObjective
        (
			uid: "phantom_main_agi_str_win",
            name: "Ward",
            sprite: "tokens/int",
            tooltip: "Defeat the phantom!",
			
			GoldReward: 0,
            ExpReward: 100,
            TrophyReward: new string[] {},
            
            MinStrength: 9,
            MaxStrength: 13, 
			
            MinAgility: 9,
            MaxAgility: 13,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective phantom_main_agi_int_win = new EncounterObjective
        (
			uid: "phantom_main_agi_int_win",
            name: "Ward",
            sprite: "tokens/int",
            tooltip: "Defeat the phantom!",
			
			GoldReward: 0,
            ExpReward: 100,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 9,
            MaxAgility: 13,

            MinIntelligence: 9,
            MaxIntelligence: 13,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective phantom_main_int_cha_win = new EncounterObjective
        (
			uid: "phantom_main_int_cha_win",
            name: "Ward",
            sprite: "tokens/int",
            tooltip: "Defeat the phantom!",
			
			GoldReward: 0,
            ExpReward: 100,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: 9,
            MaxIntelligence: 13,

            MinCharisma: 9,
            MaxCharisma: 13,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective phantom_main_agi_luk_win = new EncounterObjective
        (
			uid: "phantom_main_agi_luk_win",
            name: "Ward",
            sprite: "tokens/int",
            tooltip: "Defeat the phantom!",
			
			GoldReward: 0,
            ExpReward: 100,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 9,
            MaxAgility: 13,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: 9,
            MaxLuck: 13,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective phantom_main_cha_luk_win = new EncounterObjective
        (
			uid: "phantom_main_cha_luk_win",
            name: "Ward",
            sprite: "tokens/int",
            tooltip: "Defeat the phantom!",
			
			GoldReward: 0,
            ExpReward: 100,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: 9,
            MaxCharisma: 13,

            MinLuck: 9,
            MaxLuck: 13,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective phantom_main_str_loss = new EncounterObjective
        (
			uid: "phantom_main_str_loss",
            name: "Cursed",
            sprite: "tokens/str",
            tooltip: "Cursed by the phantom��",
			
			GoldReward: 0,
            ExpReward: -100,
            TrophyReward: new string[] {},
            
            MinStrength: 0,
            MaxStrength: 2, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: 2,
            MaxTurn: 99
        );


        public static EncounterObjective phantom_main_agi_loss = new EncounterObjective
        (
			uid: "phantom_main_agi_loss",
            name: "Cursed",
            sprite: "tokens/agi",
            tooltip: "Cursed by the phantom��",
			
			GoldReward: 0,
            ExpReward: -100,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 0,
            MaxAgility: 2,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: 2,
            MaxTurn: 99
        );


        public static EncounterObjective phantom_main_int_loss = new EncounterObjective
        (
			uid: "phantom_main_int_loss",
            name: "Cursed",
            sprite: "tokens/int",
            tooltip: "Cursed by the phantom��",
			
			GoldReward: 0,
            ExpReward: -100,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: 0,
            MaxIntelligence: 2,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: 2,
            MaxTurn: 99
        );


        public static EncounterObjective phantom_main_cha_loss = new EncounterObjective
        (
			uid: "phantom_main_cha_loss",
            name: "Cursed",
            sprite: "tokens/cha",
            tooltip: "Cursed by the phantom��",
			
			GoldReward: 0,
            ExpReward: -100,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: 0,
            MaxCharisma: 2,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: 2,
            MaxTurn: 99
        );


        public static EncounterObjective phantom_main_luk_loss = new EncounterObjective
        (
			uid: "phantom_main_luk_loss",
            name: "Cursed",
            sprite: "tokens/luk",
            tooltip: "Cursed by the phantom��",
			
			GoldReward: 0,
            ExpReward: -100,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: 0,
            MaxLuck: 2,

            MinTurn: 2,
            MaxTurn: 99
        );


        public static EncounterObjective phantom_main_turn_loss = new EncounterObjective
        (
			uid: "phantom_main_turn_loss",
            name: "Haunted",
            sprite: "tokens/luk",
            tooltip: "You toss and turn, unable to shake off the terrible feeling",
			
			GoldReward: 0,
            ExpReward: -20,
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

            MinTurn: 10,
            MaxTurn: 99
        );


        public static EncounterObjective monkey_1_loss = new EncounterObjective
        (
			uid: "monkey_1_loss",
            name: "Robbed",
            sprite: "tokens/agi",
            tooltip: "Robbed by monkeys�",
			
			GoldReward: -50,
            ExpReward: -100,
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

            MinTurn: 20,
            MaxTurn: 99
        );


        public static EncounterObjective monkey_2_loss = new EncounterObjective
        (
			uid: "monkey_2_loss",
            name: "Robbed",
            sprite: "tokens/agi",
            tooltip: "Robbed by monkeys�",
			
			GoldReward: -50,
            ExpReward: -100,
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

            MinTurn: 15,
            MaxTurn: 99
        );


        public static EncounterObjective monkey_3_loss = new EncounterObjective
        (
			uid: "monkey_3_loss",
            name: "Robbed",
            sprite: "tokens/agi",
            tooltip: "Robbed by monkeys�",
			
			GoldReward: -50,
            ExpReward: -100,
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

            MinTurn: 10,
            MaxTurn: 99
        );


        public static EncounterObjective monkey_1_stragi_win = new EncounterObjective
        (
			uid: "monkey_1_stragi_win",
            name: "Beat Up",
            sprite: "tokens/str",
            tooltip: "SHOO",
			
			GoldReward: 0,
            ExpReward: 30,
            TrophyReward: new string[] {},
            
            MinStrength: 25,
            MaxStrength: 99, 
			
            MinAgility: 25,
            MaxAgility: 99,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective monkey_2_stragi_win = new EncounterObjective
        (
			uid: "monkey_2_stragi_win",
            name: "Beat Up",
            sprite: "tokens/str",
            tooltip: "SHOO",
			
			GoldReward: 0,
            ExpReward: 70,
            TrophyReward: new string[] {},
            
            MinStrength: 35,
            MaxStrength: 99, 
			
            MinAgility: 35,
            MaxAgility: 99,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective monkey_3_stragi_win = new EncounterObjective
        (
			uid: "monkey_3_stragi_win",
            name: "Beat Up",
            sprite: "tokens/str",
            tooltip: "SHOO",
			
			GoldReward: 0,
            ExpReward: 100,
            TrophyReward: new string[] {},
            
            MinStrength: 30,
            MaxStrength: 40, 
			
            MinAgility: 30,
            MaxAgility: 40,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective monkey_1_intcha_win = new EncounterObjective
        (
			uid: "monkey_1_intcha_win",
            name: "Tame",
            sprite: "tokens/int",
            tooltip: "I mean, you are almost a monkey right? Be nice.",
			
			GoldReward: 0,
            ExpReward: 10,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: 25,
            MaxIntelligence: 99,

            MinCharisma: 25,
            MaxCharisma: 99,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective monkey_2_intcha_win = new EncounterObjective
        (
			uid: "monkey_2_intcha_win",
            name: "Tame",
            sprite: "tokens/int",
            tooltip: "I mean, you are almost a monkey right? Be nice.",
			
			GoldReward: 0,
            ExpReward: 20,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: 35,
            MaxIntelligence: 99,

            MinCharisma: 35,
            MaxCharisma: 99,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective monkey_3_intcha_win = new EncounterObjective
        (
			uid: "monkey_3_intcha_win",
            name: "Tame",
            sprite: "tokens/int",
            tooltip: "I mean, you are almost a monkey right? Be nice.",
			
			GoldReward: 0,
            ExpReward: 30,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: 30,
            MaxIntelligence: 40,

            MinCharisma: 30,
            MaxCharisma: 40,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective monkey_luk_win = new EncounterObjective
        (
			uid: "monkey_luk_win",
            name: "Lucky Break",
            sprite: "tokens/luk",
            tooltip: "Something else caught the monkeys' attention� but what?",
			
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

            MinLuck: 70,
            MaxLuck: 99,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective wildfire_1_agi_loss = new EncounterObjective
        (
			uid: "wildfire_1_agi_loss",
            name: "Burnt",
            sprite: "tokens/agi",
            tooltip: "You were too slow, and got burnt by the flames",
			
			GoldReward: 0,
            ExpReward: -25,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 0,
            MaxAgility: 20,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective wildfire_2_agi_loss = new EncounterObjective
        (
			uid: "wildfire_2_agi_loss",
            name: "Burnt",
            sprite: "tokens/agi",
            tooltip: "You were too slow, and got burnt by the flames",
			
			GoldReward: 0,
            ExpReward: -40,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 0,
            MaxAgility: 25,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective wildfire_3_agi_loss = new EncounterObjective
        (
			uid: "wildfire_3_agi_loss",
            name: "Burnt",
            sprite: "tokens/agi",
            tooltip: "You were too slow, and got burnt by the flames",
			
			GoldReward: 0,
            ExpReward: -55,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 0,
            MaxAgility: 30,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective wildfire_1_turn_win = new EncounterObjective
        (
			uid: "wildfire_1_turn_win",
            name: "Survive!",
            sprite: "tokens/agi",
            tooltip: "You escape the flames! Phew.",
			
			GoldReward: 0,
            ExpReward: 20,
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

            MinTurn: 5,
            MaxTurn: 99
        );


        public static EncounterObjective wildfire_2_turn_win = new EncounterObjective
        (
			uid: "wildfire_2_turn_win",
            name: "Survive!",
            sprite: "tokens/agi",
            tooltip: "You escape the flames! Phew.",
			
			GoldReward: 0,
            ExpReward: 40,
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

            MinTurn: 8,
            MaxTurn: 99
        );


        public static EncounterObjective wildfire_3_turn_win = new EncounterObjective
        (
			uid: "wildfire_3_turn_win",
            name: "Survive!",
            sprite: "tokens/agi",
            tooltip: "You escape the flames! Phew.",
			
			GoldReward: 0,
            ExpReward: 60,
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

            MinTurn: 15,
            MaxTurn: 99
        );


        public static EncounterObjective dark_room_main_loss = new EncounterObjective
        (
			uid: "dark_room_main_loss",
            name: "Trapped!",
            sprite: "tokens/agi",
            tooltip: "Caught by traps in the dark room",
			
			GoldReward: 0,
            ExpReward: -100,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 0,
            MaxAgility: 3,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective dark_room_1_win = new EncounterObjective
        (
			uid: "dark_room_1_win",
            name: "Escape",
            sprite: "tokens/int",
            tooltip: "You escape the room and find a small treasure",
			
			GoldReward: 40,
            ExpReward: 40,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: 15,
            MaxIntelligence: 99,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective dark_room_2_win = new EncounterObjective
        (
			uid: "dark_room_2_win",
            name: "Escape",
            sprite: "tokens/int",
            tooltip: "You escape the room and find a small treasure",
			
			GoldReward: 60,
            ExpReward: 60,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: 20,
            MaxIntelligence: 99,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective dark_room_3_win = new EncounterObjective
        (
			uid: "dark_room_3_win",
            name: "Escape",
            sprite: "tokens/int",
            tooltip: "You escape the room and find a small treasure",
			
			GoldReward: 80,
            ExpReward: 80,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: 25,
            MaxIntelligence: 99,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective dark_room_1_turn_loss = new EncounterObjective
        (
			uid: "dark_room_1_turn_loss",
            name: "Suffocate",
            sprite: "tokens/agi",
            tooltip: "You ran out of air",
			
			GoldReward: 0,
            ExpReward: -100,
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

            MinTurn: 12,
            MaxTurn: 99
        );


        public static EncounterObjective dark_room_2_turn_loss = new EncounterObjective
        (
			uid: "dark_room_2_turn_loss",
            name: "Suffocate",
            sprite: "tokens/agi",
            tooltip: "You ran out of air",
			
			GoldReward: 0,
            ExpReward: -100,
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

            MinTurn: 10,
            MaxTurn: 99
        );


        public static EncounterObjective dark_room_3_turn_loss = new EncounterObjective
        (
			uid: "dark_room_3_turn_loss",
            name: "Suffocate",
            sprite: "tokens/agi",
            tooltip: "You ran out of air",
			
			GoldReward: 0,
            ExpReward: -100,
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

            MinTurn: 8,
            MaxTurn: 99
        );


        public static EncounterObjective siren_1_cha_loss = new EncounterObjective
        (
			uid: "siren_1_cha_loss",
            name: "Charmed",
            sprite: "tokens/cha",
            tooltip: "You give in to the allure of the sirens",
			
			GoldReward: 0,
            ExpReward: -80,
            TrophyReward: new string[] {},
            
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

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective siren_2_cha_loss = new EncounterObjective
        (
			uid: "siren_2_cha_loss",
            name: "Charmed",
            sprite: "tokens/cha",
            tooltip: "You give in to the allure of the sirens",
			
			GoldReward: 0,
            ExpReward: -100,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: 75,
            MaxCharisma: 99,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective siren_3_cha_loss = new EncounterObjective
        (
			uid: "siren_3_cha_loss",
            name: "Charmed",
            sprite: "tokens/cha",
            tooltip: "You give in to the allure of the sirens",
			
			GoldReward: 0,
            ExpReward: -120,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: 70,
            MaxCharisma: 99,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective siren_1_agi_loss = new EncounterObjective
        (
			uid: "siren_1_agi_loss",
            name: "Distracted",
            sprite: "tokens/agi",
            tooltip: "Distracted by the sirens, you slip and fall into the water",
			
			GoldReward: -40,
            ExpReward: 0,
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

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective siren_2_agi_loss = new EncounterObjective
        (
			uid: "siren_2_agi_loss",
            name: "Distracted",
            sprite: "tokens/agi",
            tooltip: "Distracted by the sirens, you slip and fall into the water",
			
			GoldReward: -60,
            ExpReward: 0,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 0,
            MaxAgility: 15,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective siren_3_agi_loss = new EncounterObjective
        (
			uid: "siren_3_agi_loss",
            name: "Distracted",
            sprite: "tokens/agi",
            tooltip: "Distracted by the sirens, you slip and fall into the water",
			
			GoldReward: -80,
            ExpReward: 0,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 0,
            MaxAgility: 15,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective siren_1_str_win = new EncounterObjective
        (
			uid: "siren_1_str_win",
            name: "Force of Will",
            sprite: "tokens/str",
            tooltip: "With a strong will, you ignore the cries of the siren",
			
			GoldReward: 0,
            ExpReward: 100,
            TrophyReward: new string[] {},
            
            MinStrength: 30,
            MaxStrength: 99, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective siren_2_str_win = new EncounterObjective
        (
			uid: "siren_2_str_win",
            name: "Force of Will",
            sprite: "tokens/str",
            tooltip: "With a strong will, you ignore the cries of the siren",
			
			GoldReward: 0,
            ExpReward: 120,
            TrophyReward: new string[] {},
            
            MinStrength: 35,
            MaxStrength: 99, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective siren_3_str_win = new EncounterObjective
        (
			uid: "siren_3_str_win",
            name: "Force of Will",
            sprite: "tokens/str",
            tooltip: "With a strong will, you ignore the cries of the siren",
			
			GoldReward: 0,
            ExpReward: 140,
            TrophyReward: new string[] {},
            
            MinStrength: 40,
            MaxStrength: 99, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective siren_1_int_win = new EncounterObjective
        (
			uid: "siren_1_int_win",
            name: "Cunning Ploy",
            sprite: "tokens/int",
            tooltip: "You devise a plan that will allow you to escape the sirens",
			
			GoldReward: 0,
            ExpReward: 60,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: 15,
            MaxIntelligence: 99,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective siren_2_int_win = new EncounterObjective
        (
			uid: "siren_2_int_win",
            name: "Cunning Ploy",
            sprite: "tokens/int",
            tooltip: "You devise a plan that will allow you to escape the sirens",
			
			GoldReward: 0,
            ExpReward: 80,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: 20,
            MaxIntelligence: 99,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective siren_3_int_win = new EncounterObjective
        (
			uid: "siren_3_int_win",
            name: "Cunning Ploy",
            sprite: "tokens/int",
            tooltip: "You devise a plan that will allow you to escape the sirens",
			
			GoldReward: 0,
            ExpReward: 100,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: 25,
            MaxIntelligence: 99,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective siren_bonus_luk = new EncounterObjective
        (
			uid: "siren_bonus_luk",
            name: "Unexpected Treasure!",
            sprite: "tokens/luk",
            tooltip: "Treasure�.?",
			
			GoldReward: 100,
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

            MinLuck: 60,
            MaxLuck: 99,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective zombie_1_str_win = new EncounterObjective
        (
			uid: "zombie_1_str_win",
            name: "Fight",
            sprite: "tokens/str",
            tooltip: "Through sheer force, you beat your way through the dead.",
			
			GoldReward: 20,
            ExpReward: 80,
            TrophyReward: new string[] {},
            
            MinStrength: 30,
            MaxStrength: 99, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective zombie_2_str_win = new EncounterObjective
        (
			uid: "zombie_2_str_win",
            name: "Fight",
            sprite: "tokens/str",
            tooltip: "Through sheer force, you beat your way through the dead.",
			
			GoldReward: 25,
            ExpReward: 100,
            TrophyReward: new string[] {},
            
            MinStrength: 40,
            MaxStrength: 99, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective zombie_3_str_win = new EncounterObjective
        (
			uid: "zombie_3_str_win",
            name: "Fight",
            sprite: "tokens/str",
            tooltip: "Through sheer force, you beat your way through the dead.",
			
			GoldReward: 30,
            ExpReward: 120,
            TrophyReward: new string[] {},
            
            MinStrength: 50,
            MaxStrength: 99, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective zombie_1_agi_win = new EncounterObjective
        (
			uid: "zombie_1_agi_win",
            name: "Escape",
            sprite: "tokens/agi",
            tooltip: "With nimble feet, you escape the zombies",
			
			GoldReward: 0,
            ExpReward: 80,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 30,
            MaxAgility: 99,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective zombie_2_agi_win = new EncounterObjective
        (
			uid: "zombie_2_agi_win",
            name: "Escape",
            sprite: "tokens/agi",
            tooltip: "With nimble feet, you escape the zombies",
			
			GoldReward: 0,
            ExpReward: 100,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 40,
            MaxAgility: 99,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective zombie_3_agi_win = new EncounterObjective
        (
			uid: "zombie_3_agi_win",
            name: "Escape",
            sprite: "tokens/agi",
            tooltip: "With nimble feet, you escape the zombies",
			
			GoldReward: 0,
            ExpReward: 120,
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

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective zombie_bonus_int = new EncounterObjective
        (
			uid: "zombie_bonus_int",
            name: "Learn by Observation",
            sprite: "tokens/int",
            tooltip: "Your keen eyes pick up some information about the dead.",
			
			GoldReward: 0,
            ExpReward: 100,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: 70,
            MaxIntelligence: 99,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective zombie_bonus_cha = new EncounterObjective
        (
			uid: "zombie_bonus_cha",
            name: "Convince the zombies?",
            sprite: "tokens/cha",
            tooltip: "So um, I guess even the dead can communicate",
			
			GoldReward: 0,
            ExpReward: 100,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: 70,
            MaxCharisma: 99,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective zombie_1_stragi_lose = new EncounterObjective
        (
			uid: "zombie_1_stragi_lose",
            name: "Captured by the unliving",
            sprite: "tokens/str",
            tooltip: "The grasp of the dead does not relent",
			
			GoldReward: -30,
            ExpReward: -50,
            TrophyReward: new string[] {},
            
            MinStrength: 0,
            MaxStrength: 2, 
			
            MinAgility: 0,
            MaxAgility: 2,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective zombie_2_stragi_lose = new EncounterObjective
        (
			uid: "zombie_2_stragi_lose",
            name: "Captured by the unliving",
            sprite: "tokens/str",
            tooltip: "The grasp of the dead does not relent",
			
			GoldReward: -45,
            ExpReward: -75,
            TrophyReward: new string[] {},
            
            MinStrength: 0,
            MaxStrength: 2, 
			
            MinAgility: 0,
            MaxAgility: 2,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective zombie_3_stragi_lose = new EncounterObjective
        (
			uid: "zombie_3_stragi_lose",
            name: "Captured by the unliving",
            sprite: "tokens/str",
            tooltip: "The grasp of the dead does not relent",
			
			GoldReward: -60,
            ExpReward: -100,
            TrophyReward: new string[] {},
            
            MinStrength: 0,
            MaxStrength: 2, 
			
            MinAgility: 0,
            MaxAgility: 2,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


    }
}
