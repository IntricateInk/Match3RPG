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
			
			type: "LOSE",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "BONUS",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
            tooltip: "Cursed by the phantom……",
			
			type: "LOSE",
			
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
            tooltip: "Cursed by the phantom……",
			
			type: "LOSE",
			
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
            tooltip: "Cursed by the phantom……",
			
			type: "LOSE",
			
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
            tooltip: "Cursed by the phantom……",
			
			type: "LOSE",
			
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
            tooltip: "Cursed by the phantom……",
			
			type: "LOSE",
			
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
			
			type: "LOSE",
			
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
            tooltip: "Robbed by monkeys…",
			
			type: "LOSE",
			
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
            tooltip: "Robbed by monkeys…",
			
			type: "LOSE",
			
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
            tooltip: "Robbed by monkeys…",
			
			type: "LOSE",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
            tooltip: "Something else caught the monkeys' attention… but what?",
			
			type: "WIN",
			
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
			
			type: "LOSE",
			
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
			
			type: "LOSE",
			
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
			
			type: "LOSE",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "LOSE",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "LOSE",
			
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
			
			type: "LOSE",
			
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
			
			type: "LOSE",
			
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
			
			type: "LOSE",
			
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
			
			type: "LOSE",
			
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
			
			type: "LOSE",
			
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
			
			type: "LOSE",
			
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
			
			type: "LOSE",
			
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
			
			type: "LOSE",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
            tooltip: "Treasure….?",
			
			type: "BONUS",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "WIN",
			
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
			
			type: "BONUS",
			
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
			
			type: "BONUS",
			
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
			
			type: "LOSE",
			
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
			
			type: "LOSE",
			
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
			
			type: "LOSE",
			
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


        public static EncounterObjective ranger_1_turn_loss = new EncounterObjective
        (
			uid: "ranger_1_turn_loss",
            name: "Retreat",
            sprite: "tokens/turn",
            tooltip: "The ranger escapes",
			
			type: "LOSE",
			
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

            MinTurn: 12,
            MaxTurn: 99
        );


        public static EncounterObjective ranger_1_agi_win = new EncounterObjective
        (
			uid: "ranger_1_agi_win",
            name: "Feat of Skill",
            sprite: "tokens/agi",
            tooltip: "You best the ranger at her craft",
			
			type: "WIN",
			
			GoldReward: 30,
            ExpReward: 60,
            TrophyReward: new string[] {
"Plywood Bow"
},
            
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

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective ranger_1_cha_win = new EncounterObjective
        (
			uid: "ranger_1_cha_win",
            name: "Convincing",
            sprite: "tokens/cha",
            tooltip: "You convince the ranger to join you",
			
			type: "WIN",
			
			GoldReward: 0,
            ExpReward: 20,
            TrophyReward: new string[] {
"Leader of Men"
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


        public static EncounterObjective ranger_1_int_bonus = new EncounterObjective
        (
			uid: "ranger_1_int_bonus",
            name: "Perceptive",
            sprite: "tokens/int",
            tooltip: "You learn something from the ranger's moves",
			
			type: "BONUS",
			
			GoldReward: 0,
            ExpReward: 40,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: 40,
            MaxIntelligence: 99,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective spiked_hole_1_str_loss = new EncounterObjective
        (
			uid: "spiked_hole_1_str_loss",
            name: "Fall",
            sprite: "tokens/str",
            tooltip: "Your grip weakens… and you fall.",
			
			type: "LOSE",
			
			GoldReward: -10,
            ExpReward: -20,
            TrophyReward: new string[] {},
            
            MinStrength: 0,
            MaxStrength: 15, 
			
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


        public static EncounterObjective spiked_hole_2_str_loss = new EncounterObjective
        (
			uid: "spiked_hole_2_str_loss",
            name: "Fall",
            sprite: "tokens/str",
            tooltip: "Your grip weakens… and you fall.",
			
			type: "LOSE",
			
			GoldReward: -20,
            ExpReward: -40,
            TrophyReward: new string[] {},
            
            MinStrength: 0,
            MaxStrength: 20, 
			
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


        public static EncounterObjective spiked_hole_3_str_loss = new EncounterObjective
        (
			uid: "spiked_hole_3_str_loss",
            name: "Fall",
            sprite: "tokens/str",
            tooltip: "Your grip weakens… and you fall.",
			
			type: "LOSE",
			
			GoldReward: -30,
            ExpReward: -60,
            TrophyReward: new string[] {},
            
            MinStrength: 0,
            MaxStrength: 25, 
			
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


        public static EncounterObjective spiked_hole_1_agi_win = new EncounterObjective
        (
			uid: "spiked_hole_1_agi_win",
            name: "Nimble",
            sprite: "skills/sleight",
            tooltip: "You climb out",
			
			type: "WIN",
			
			GoldReward: 0,
            ExpReward: 25,
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


        public static EncounterObjective spiked_hole_2_agi_win = new EncounterObjective
        (
			uid: "spiked_hole_2_agi_win",
            name: "Nimble",
            sprite: "skills/sleight",
            tooltip: "You climb out",
			
			type: "WIN",
			
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


        public static EncounterObjective spiked_hole_3_agi_win = new EncounterObjective
        (
			uid: "spiked_hole_3_agi_win",
            name: "Nimble",
            sprite: "skills/sleight",
            tooltip: "You climb out",
			
			type: "WIN",
			
			GoldReward: 0,
            ExpReward: 75,
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


        public static EncounterObjective spiked_hole_int_bonus = new EncounterObjective
        (
			uid: "spiked_hole_int_bonus",
            name: "Observe",
            sprite: "tokens/int",
            tooltip: "You learn something about traps",
			
			type: "BONUS",
			
			GoldReward: 0,
            ExpReward: 20,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: -1,
            MaxAgility: 100,

            MinIntelligence: 30,
            MaxIntelligence: 99,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: -1,
            MaxLuck: 100,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective spiked_hole_luk_bonus = new EncounterObjective
        (
			uid: "spiked_hole_luk_bonus",
            name: "Lucky Find",
            sprite: "tokens/luk",
            tooltip: "Some gold? Perhaps it belongs to the previous unfortunate victim",
			
			type: "BONUS",
			
			GoldReward: 40,
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

            MinLuck: 40,
            MaxLuck: 99,

            MinTurn: -1,
            MaxTurn: 100
        );


        public static EncounterObjective drown_1_str_win = new EncounterObjective
        (
			uid: "drown_1_str_win",
            name: "Swim to Shore",
            sprite: "tokens/str",
            tooltip: "You swim to land",
			
			type: "WIN",
			
			GoldReward: 0,
            ExpReward: 40,
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


        public static EncounterObjective drown_2_str_win = new EncounterObjective
        (
			uid: "drown_2_str_win",
            name: "Swim to Shore",
            sprite: "tokens/str",
            tooltip: "You swim to land",
			
			type: "WIN",
			
			GoldReward: 0,
            ExpReward: 60,
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


        public static EncounterObjective drown_3_str_win = new EncounterObjective
        (
			uid: "drown_3_str_win",
            name: "Swim to Shore",
            sprite: "tokens/str",
            tooltip: "You swim to land",
			
			type: "WIN",
			
			GoldReward: 0,
            ExpReward: 80,
            TrophyReward: new string[] {},
            
            MinStrength: 70,
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


        public static EncounterObjective drown_1_turn_loss = new EncounterObjective
        (
			uid: "drown_1_turn_loss",
            name: "Drown",
            sprite: "tokens/str",
            tooltip: "You drown",
			
			type: "LOSE",
			
			GoldReward: 0,
            ExpReward: -40,
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


        public static EncounterObjective drown_2_turn_loss = new EncounterObjective
        (
			uid: "drown_2_turn_loss",
            name: "Drown",
            sprite: "tokens/str",
            tooltip: "You drown",
			
			type: "LOSE",
			
			GoldReward: 0,
            ExpReward: -60,
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


        public static EncounterObjective drown_3_turn_loss = new EncounterObjective
        (
			uid: "drown_3_turn_loss",
            name: "Drown",
            sprite: "tokens/str",
            tooltip: "You drown",
			
			type: "LOSE",
			
			GoldReward: 0,
            ExpReward: -80,
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


        public static EncounterObjective drown_luk_bonus = new EncounterObjective
        (
			uid: "drown_luk_bonus",
            name: "Hidden Treasure",
            sprite: "tokens/luk",
            tooltip: "You find some hidden treasure",
			
			type: "BONUS",
			
			GoldReward: 100,
            ExpReward: 30,
            TrophyReward: new string[] {},
            
            MinStrength: -1,
            MaxStrength: 100, 
			
            MinAgility: 70,
            MaxAgility: 99,

            MinIntelligence: -1,
            MaxIntelligence: 100,

            MinCharisma: -1,
            MaxCharisma: 100,

            MinLuck: 70,
            MaxLuck: 99,

            MinTurn: -1,
            MaxTurn: 100
        );


    }
}
