using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Encounter
{
    public sealed partial class EncounterSheet : ITooltip
    {
		        public static EncounterSheet mole_1 = new EncounterSheet
            (
                name: @"Minor Mole Infestation",
                icon: @"icons/burrow",
                tooltip: @"Hole-y Mole-y! That IS A LOT OF MOLES.

Match AGI to meet the goal while ensuring that the Moles that spawn do not reach the bottom.
Moles can be destroyed either by using certain skills or by matching them.",
                
				min_depth: 1,
				max_depth: 2,
				
				objectives: new string[] 
				{
				
"mole_1_main_agi",
"mole_1_main_cha",
"mole_main_loss",
"mole_bonus_luk"

				},
                
				passives: new string[] 
				{
				
"Mole Infestation! (2)"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					1000,
					0,
					0
				}
            );

        public static EncounterSheet mole_2 = new EncounterSheet
            (
                name: @"Mole Infestation",
                icon: @"icons/burrow",
                tooltip: @"Hole-y Mole-y! That IS A LOT OF MOLES.

Match AGI to meet the goal while ensuring that the Moles that spawn do not reach the bottom.
Moles can be destroyed either by using certain skills or by matching them.",
                
				min_depth: 3,
				max_depth: 4,
				
				objectives: new string[] 
				{
				
"mole_2_main_agi",
"mole_2_main_cha",
"mole_main_loss",
"mole_bonus_luk"

				},
                
				passives: new string[] 
				{
				
"Mole Infestation! (3)"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					1000,
					0,
					0
				}
            );

        public static EncounterSheet mole_3 = new EncounterSheet
            (
                name: @"Major Mole Infestation!",
                icon: @"icons/burrow",
                tooltip: @"Hole-y Mole-y! That IS A LOT OF MOLES.

Match AGI to meet the goal while ensuring that the Moles that spawn do not reach the bottom.
Moles can be destroyed either by using certain skills or by matching them.",
                
				min_depth: 5,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"mole_3_main_agi",
"mole_3_main_cha",
"mole_main_loss",
"mole_bonus_luk"

				},
                
				passives: new string[] 
				{
				
"Mole Infestation! (4)"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					1000,
					0,
					0
				}
            );

        public static EncounterSheet phantom_str = new EncounterSheet
            (
                name: @"Phantom Berserker",
                icon: @"icons/phantom",
                tooltip: @"The restless spirit of a dead warrior haunts you.

Match STR and AGI tokens every turn to stay alive.
Win by matching an exact amount of STR and AGI tokens on the same turn.",
                
				min_depth: 1,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"phantom_main_agi_str_win",
"phantom_main_str_loss",
"phantom_main_agi_loss",
"phantom_main_turn_loss"

				},
                
				passives: new string[] 
				{
				
"Phantom Berserker"

				},
				
				weights: new int[]
				{
					0,
					0,
					200,
					0,
					200,
					0
				}
            );

        public static EncounterSheet phantom_agi = new EncounterSheet
            (
                name: @"Phantom Swindler",
                icon: @"icons/phantom",
                tooltip: @"The restless spirit of a dead warrior haunts you.

Match AGI and INT tokens every turn to stay alive.
Win by matching an exact amount of AGI and INT tokens on the same turn.",
                
				min_depth: 1,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"phantom_main_agi_int_win",
"phantom_main_agi_loss",
"phantom_main_int_loss",
"phantom_main_turn_loss"

				},
                
				passives: new string[] 
				{
				
"Phantom Swindler"

				},
				
				weights: new int[]
				{
					0,
					0,
					200,
					0,
					200,
					0
				}
            );

        public static EncounterSheet phantom_int = new EncounterSheet
            (
                name: @"Phantom Navigator",
                icon: @"icons/phantom",
                tooltip: @"The restless spirit of a dead warrior haunts you.

Match INT and CHA tokens every turn to stay alive.
Win by matching an exact amount of INT and CHA tokens on the same turn.",
                
				min_depth: 1,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"phantom_main_int_cha_win",
"phantom_main_cha_loss",
"phantom_main_int_loss",
"phantom_main_turn_loss"

				},
                
				passives: new string[] 
				{
				
"Phantom Navigator"

				},
				
				weights: new int[]
				{
					0,
					0,
					200,
					0,
					200,
					0
				}
            );

        public static EncounterSheet phantom_luk = new EncounterSheet
            (
                name: @"Phantom Jester",
                icon: @"icons/phantom",
                tooltip: @"The restless spirit of a dead warrior haunts you.

Match AGI and LUK tokens every turn to stay alive.
Win by matching an exact amount of AGI and LUK tokens on the same turn.",
                
				min_depth: 1,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"phantom_main_agi_luk_win",
"phantom_main_agi_loss",
"phantom_main_luk_loss",
"phantom_main_turn_loss"

				},
                
				passives: new string[] 
				{
				
"Phantom Jester"

				},
				
				weights: new int[]
				{
					0,
					0,
					200,
					0,
					200,
					0
				}
            );

        public static EncounterSheet phantom_cha = new EncounterSheet
            (
                name: @"Phantom Noble",
                icon: @"icons/phantom",
                tooltip: @"The restless spirit of a dead warrior haunts you.

Match CHA and LUK tokens every turn to stay alive.
Win by matching an exact amount of CHA and LUK tokens on the same turn.",
                
				min_depth: 1,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"phantom_main_cha_luk_win",
"phantom_main_cha_loss",
"phantom_main_luk_loss",
"phantom_main_turn_loss"

				},
                
				passives: new string[] 
				{
				
"Phantom Noble"

				},
				
				weights: new int[]
				{
					0,
					0,
					200,
					0,
					200,
					0
				}
            );

        public static EncounterSheet monkey_1 = new EncounterSheet
            (
                name: @"Monkey Forest",
                icon: @"icons/forest_1",
                tooltip: @"A forest full of monkeys…… great

Monkeys that spawn mimic your highest resource, but to win you will need to gather two different resource types.
Keep an eye on both resource types of the goal!",
                
				min_depth: 1,
				max_depth: 2,
				
				objectives: new string[] 
				{
				
"monkey_luk_win",
"monkey_1_stragi_win",
"monkey_1_intcha_win",
"monkey_1_loss"

				},
                
				passives: new string[] 
				{
				
"Monkey Jungle"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					1000,
					0,
					0
				}
            );

        public static EncounterSheet monkey_2 = new EncounterSheet
            (
                name: @"Monkey Jungle",
                icon: @"icons/forest_1",
                tooltip: @"A forest full of monkeys…… great

Monkeys that spawn mimic your highest resource, but to win you will need to gather two different resource types.
Keep an eye on both resource types of the goal!",
                
				min_depth: 3,
				max_depth: 4,
				
				objectives: new string[] 
				{
				
"monkey_luk_win",
"monkey_2_stragi_win",
"monkey_2_intcha_win",
"monkey_2_loss"

				},
                
				passives: new string[] 
				{
				
"Monkey Jungle"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					1000,
					0,
					0
				}
            );

        public static EncounterSheet monkey_3 = new EncounterSheet
            (
                name: @"Monkey Thicklet",
                icon: @"icons/forest_1",
                tooltip: @"A forest full of monkeys…… great

Monkeys that spawn mimic your highest resource, but to win you will need to gather two different resource types.
Keep an eye on both resource types of the goal!",
                
				min_depth: 5,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"monkey_luk_win",
"monkey_3_stragi_win",
"monkey_3_intcha_win",
"monkey_3_loss"

				},
                
				passives: new string[] 
				{
				
"Monkey Jungle"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					1000,
					0,
					0
				}
            );

        public static EncounterSheet wildfire_1 = new EncounterSheet
            (
                name: @"Small Forest Fire",
                icon: @"icons/fire_2",
                tooltip: @"The forest is on fire! The forest is on fire!

Wildfire spreads and destroys tokens. Keep your Crew away from the Wildfire.
Match or destroy Wildfire tokens to prevent them from spreading.",
                
				min_depth: 1,
				max_depth: 2,
				
				objectives: new string[] 
				{
				
"wildfire_1_turn_win",
"wildfire_1_agi_loss"

				},
                
				passives: new string[] 
				{
				
"Small Forest Fire!"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					1000,
					0,
					0
				}
            );

        public static EncounterSheet wildfire_2 = new EncounterSheet
            (
                name: @"Forest Fire",
                icon: @"icons/fire_2",
                tooltip: @"The forest is on fire! The forest is on fire!

Wildfire spreads and destroys tokens. Keep your Crew away from the Wildfire.
Match or destroy Wildfire tokens to prevent them from spreading.",
                
				min_depth: 3,
				max_depth: 4,
				
				objectives: new string[] 
				{
				
"wildfire_2_turn_win",
"wildfire_2_agi_loss"

				},
                
				passives: new string[] 
				{
				
"Forest Fire!"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					1000,
					0,
					0
				}
            );

        public static EncounterSheet wildfire_3 = new EncounterSheet
            (
                name: @"Blazing Forest Fire",
                icon: @"icons/fire_2",
                tooltip: @"The forest is on fire! The forest is on fire!

Wildfire spreads and destroys tokens. Keep your Crew away from the Wildfire.
Match or destroy Wildfire tokens to prevent them from spreading.",
                
				min_depth: 5,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"wildfire_3_turn_win",
"wildfire_3_agi_loss"

				},
                
				passives: new string[] 
				{
				
"Blazing Forest Fire!"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					1000,
					0,
					0
				}
            );

        public static EncounterSheet dark_room_1 = new EncounterSheet
            (
                name: @"Dark Room",
                icon: @"icons/ambush",
                tooltip: @"The room is really dark

Match tokens to get to the goal! However, be cautious when making matches on top of traps as they can kill your Crew.",
                
				min_depth: 1,
				max_depth: 2,
				
				objectives: new string[] 
				{
				
"dark_room_1_win",
"dark_room_main_loss",
"dark_room_1_turn_loss"

				},
                
				passives: new string[] 
				{
				
"Dark Room"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					0,
					1000,
					0
				}
            );

        public static EncounterSheet dark_room_2 = new EncounterSheet
            (
                name: @"Bloodstained Dark Room",
                icon: @"icons/ambush",
                tooltip: @"The room is really dark

Match tokens to get to the goal! However, be cautious when making matches on top of traps as they can kill your Crew.",
                
				min_depth: 3,
				max_depth: 4,
				
				objectives: new string[] 
				{
				
"dark_room_2_win",
"dark_room_main_loss",
"dark_room_2_turn_loss"

				},
                
				passives: new string[] 
				{
				
"Bloodstained Dark Room"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					0,
					1000,
					0
				}
            );

        public static EncounterSheet dark_room_3 = new EncounterSheet
            (
                name: @"Torture Chamber",
                icon: @"icons/ambush",
                tooltip: @"The room is really dark

Match tokens to get to the goal! However, be cautious when making matches on top of traps as they can kill your Crew.",
                
				min_depth: 5,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"dark_room_3_win",
"dark_room_main_loss",
"dark_room_3_turn_loss"

				},
                
				passives: new string[] 
				{
				
"Torture Chamber"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					0,
					1000,
					0
				}
            );

        public static EncounterSheet siren_1 = new EncounterSheet
            (
                name: @"Ship Graveyard",
                icon: @"icons/charm",
                tooltip: @"A beautiful song washes over you.

Match STR or INT to defeat the Sirens.
Try to keep your Crew away from the Sirens, as they will be destroyed if they are matched.",
                
				min_depth: 1,
				max_depth: 2,
				
				objectives: new string[] 
				{
				
"siren_1_int_win",
"siren_1_str_win",
"siren_1_cha_loss",
"siren_1_agi_loss",
"siren_bonus_luk"

				},
                
				passives: new string[] 
				{
				
"Ship Graveyard"

				},
				
				weights: new int[]
				{
					0,
					1000,
					0,
					0,
					0,
					0
				}
            );

        public static EncounterSheet siren_2 = new EncounterSheet
            (
                name: @"Cape of the Lost",
                icon: @"icons/charm",
                tooltip: @"A beautiful song washes over you.

Match STR or INT to defeat the Sirens.
Try to keep your Crew away from the Sirens, as they will be destroyed if they are matched.",
                
				min_depth: 3,
				max_depth: 4,
				
				objectives: new string[] 
				{
				
"siren_2_int_win",
"siren_2_str_win",
"siren_2_cha_loss",
"siren_2_agi_loss",
"siren_bonus_luk"

				},
                
				passives: new string[] 
				{
				
"Cape of the Lost"

				},
				
				weights: new int[]
				{
					0,
					1000,
					0,
					0,
					0,
					0
				}
            );

        public static EncounterSheet siren_3 = new EncounterSheet
            (
                name: @"Basin of Sorrow",
                icon: @"icons/charm",
                tooltip: @"A beautiful song washes over you.

Match STR or INT to defeat the Sirens.
Try to keep your Crew away from the Sirens, as they will be destroyed if they are matched.",
                
				min_depth: 5,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"siren_3_int_win",
"siren_3_str_win",
"siren_3_cha_loss",
"siren_3_agi_loss",
"siren_bonus_luk"

				},
                
				passives: new string[] 
				{
				
"Basin of Sorrow"

				},
				
				weights: new int[]
				{
					0,
					1000,
					0,
					0,
					0,
					0
				}
            );

        public static EncounterSheet zombie_1 = new EncounterSheet
            (
                name: @"Unearthed Graveyard",
                icon: @"icons/undead_2",
                tooltip: @"The graves are empty.

Match resources to the goal. Zombies will delay you by consuming your resources.
Zombies can be destroyed by using skills or matching them.",
                
				min_depth: 1,
				max_depth: 2,
				
				objectives: new string[] 
				{
				
"zombie_1_str_win",
"zombie_1_agi_win",
"zombie_1_stragi_lose",
"zombie_bonus_int",
"zombie_bonus_cha"

				},
                
				passives: new string[] 
				{
				
"Unearthed Graveyard"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					0,
					1000,
					0
				}
            );

        public static EncounterSheet zombie_2 = new EncounterSheet
            (
                name: @"Desecrated Ground",
                icon: @"icons/undead_2",
                tooltip: @"The graves are empty.

Match resources to the goal. Zombies will delay you by consuming your resources.
Zombies can be destroyed by using skills or matching them.",
                
				min_depth: 3,
				max_depth: 4,
				
				objectives: new string[] 
				{
				
"zombie_2_str_win",
"zombie_2_agi_win",
"zombie_2_stragi_lose",
"zombie_bonus_int",
"zombie_bonus_cha"

				},
                
				passives: new string[] 
				{
				
"Desecrated Ground"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					0,
					1000,
					0
				}
            );

        public static EncounterSheet zombie_3 = new EncounterSheet
            (
                name: @"Necropolis",
                icon: @"icons/undead_2",
                tooltip: @"The graves are empty.

Match resources to the goal. Zombies will delay you by consuming your resources.
Zombies can be destroyed by using skills or matching them.",
                
				min_depth: 5,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"zombie_3_str_win",
"zombie_3_agi_win",
"zombie_3_stragi_lose",
"zombie_bonus_int",
"zombie_bonus_cha"

				},
                
				passives: new string[] 
				{
				
"Necropolis"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					0,
					1000,
					0
				}
            );

        public static EncounterSheet ranger_1 = new EncounterSheet
            (
                name: @"Ranger",
                icon: @"icons/ranger_dash",
                tooltip: @"The silent ranger strikes

The Ranger switches between two modes: Dash and Arrow.
In Dash Mode, the Ranger places Crew and Markers on the board. Markers transform token to AGI.
In Arrow Mode, the Ranger destroys all AGI tokens and tokens nearby AGI tokens. Keep your Crew away!",
                
				min_depth: 1,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"ranger_1_turn_loss",
"ranger_1_agi_win",
"ranger_1_cha_win",
"ranger_1_int_bonus"

				},
                
				passives: new string[] 
				{
				
"Ranger - Dash"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					0,
					0,
					1000
				}
            );

        public static EncounterSheet spiked_hole_1 = new EncounterSheet
            (
                name: @"Hidden Trap",
                icon: @"icons/spiked_hole",
                tooltip: @"You fall into a deep, deep hole

Keep your Crew near the top while you gain enough AGI to win.",
                
				min_depth: 1,
				max_depth: 2,
				
				objectives: new string[] 
				{
				
"spiked_hole_1_agi_win",
"spiked_hole_1_str_loss",
"spiked_hole_int_bonus",
"spiked_hole_luk_bonus"

				},
                
				passives: new string[] 
				{
				
"Hidden Trap"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					0,
					1000,
					0
				}
            );

        public static EncounterSheet spiked_hole_2 = new EncounterSheet
            (
                name: @"Covered Pit",
                icon: @"icons/spiked_hole",
                tooltip: @"You fall into a deep, deep hole

Keep your Crew near the top while you gain enough AGI to win.",
                
				min_depth: 3,
				max_depth: 4,
				
				objectives: new string[] 
				{
				
"spiked_hole_2_agi_win",
"spiked_hole_2_str_loss",
"spiked_hole_int_bonus",
"spiked_hole_luk_bonus"

				},
                
				passives: new string[] 
				{
				
"Covered Pit"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					0,
					1000,
					0
				}
            );

        public static EncounterSheet spiked_hole_3 = new EncounterSheet
            (
                name: @"Death Trap",
                icon: @"icons/spiked_hole",
                tooltip: @"You fall into a deep, deep hole

Keep your Crew near the top while you gain enough AGI to win.",
                
				min_depth: 5,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"spiked_hole_3_agi_win",
"spiked_hole_3_str_loss",
"spiked_hole_int_bonus",
"spiked_hole_luk_bonus"

				},
                
				passives: new string[] 
				{
				
"Death Trap"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					0,
					1000,
					0
				}
            );

        public static EncounterSheet drown_1 = new EncounterSheet
            (
                name: @"Shipwrecked",
                icon: @"icons/water",
                tooltip: @"That is a lot of water?

Water flows downwards, blanking tokens. The flow can be controlled by using skills to destroy or match tokens with Water.",
                
				min_depth: 1,
				max_depth: 2,
				
				objectives: new string[] 
				{
				
"drown_1_str_win",
"drown_1_turn_loss",
"drown_luk_bonus"

				},
                
				passives: new string[] 
				{
				
"Shipwrecked"

				},
				
				weights: new int[]
				{
					1000,
					1000,
					0,
					0,
					0,
					0
				}
            );

        public static EncounterSheet drown_2 = new EncounterSheet
            (
                name: @"Whirlpool",
                icon: @"icons/water",
                tooltip: @"That is a lot of water?

Water flows downwards, blanking tokens. The flow can be controlled by using skills to destroy or match tokens with Water.",
                
				min_depth: 3,
				max_depth: 4,
				
				objectives: new string[] 
				{
				
"drown_2_str_win",
"drown_2_turn_loss",
"drown_luk_bonus"

				},
                
				passives: new string[] 
				{
				
"Whirlpool"

				},
				
				weights: new int[]
				{
					1000,
					1000,
					0,
					0,
					0,
					0
				}
            );

        public static EncounterSheet drown_3 = new EncounterSheet
            (
                name: @"Bermuda Triangle?",
                icon: @"icons/water",
                tooltip: @"That is a lot of water?

Water flows downwards, blanking tokens. The flow can be controlled by using skills to destroy or match tokens with Water.",
                
				min_depth: 5,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"drown_3_str_win",
"drown_3_turn_loss",
"drown_luk_bonus"

				},
                
				passives: new string[] 
				{
				
"Bermuda Triangle?"

				},
				
				weights: new int[]
				{
					1000,
					1000,
					0,
					0,
					0,
					0
				}
            );

        public static EncounterSheet spirit_1 = new EncounterSheet
            (
                name: @"Whispering Forest",
                icon: @"icons/chakra_green",
                tooltip: @"The spirits wander freely here… perhaps you could learn something from them?

Move the tokens with the Spirit to the Spirit Catchers to quickly gain INT within the turn limit.",
                
				min_depth: 1,
				max_depth: 2,
				
				objectives: new string[] 
				{
				
"spirit_1_int_win",
"spirit_1_turn_loss",
"spirit_luk_agi_bonus"

				},
                
				passives: new string[] 
				{
				
"Whispering Forest"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					1000,
					0,
					0
				}
            );

        public static EncounterSheet spirit_2 = new EncounterSheet
            (
                name: @"Verdent Forest",
                icon: @"icons/chakra_green",
                tooltip: @"The spirits wander freely here… perhaps you could learn something from them?

Move the tokens with the Spirit to the Spirit Catchers to quickly gain INT within the turn limit.",
                
				min_depth: 3,
				max_depth: 4,
				
				objectives: new string[] 
				{
				
"spirit_2_int_win",
"spirit_2_turn_loss",
"spirit_luk_agi_bonus"

				},
                
				passives: new string[] 
				{
				
"Verdent Forest"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					1000,
					0,
					0
				}
            );

        public static EncounterSheet spirit_3 = new EncounterSheet
            (
                name: @"Heart of the Forest",
                icon: @"icons/chakra_green",
                tooltip: @"The spirits wander freely here… perhaps you could learn something from them?

Move the tokens with the Spirit to the Spirit Catchers to quickly gain INT within the turn limit.",
                
				min_depth: 5,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"spirit_3_int_win",
"spirit_3_turn_loss",
"spirit_luk_agi_bonus"

				},
                
				passives: new string[] 
				{
				
"Heart of the Forest"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					1000,
					0,
					0
				}
            );

        public static EncounterSheet water_zombie_1 = new EncounterSheet
            (
                name: @"Bloated Corpses",
                icon: @"icons/undead_1",
                tooltip: @"The drowned dead attack!

Deal with Water by moving it downwards, and kill the zombies before the spread. But be wary of destroying Plague tokens, which spawn more Zombies.",
                
				min_depth: 3,
				max_depth: 4,
				
				objectives: new string[] 
				{
				
"water_zombie_win_1",
"water_zombie_loss_1"

				},
                
				passives: new string[] 
				{
				
"Bloated Corpses"

				},
				
				weights: new int[]
				{
					1000,
					0,
					0,
					0,
					0,
					0
				}
            );

        public static EncounterSheet water_zombie_2 = new EncounterSheet
            (
                name: @"Drowned Dead",
                icon: @"icons/undead_1",
                tooltip: @"The drowned dead attack!

Deal with Water by moving it downwards, and kill the zombies before the spread. But be wary of destroying Plague tokens, which spawn more Zombies.",
                
				min_depth: 5,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"water_zombie_win_2",
"water_zombie_loss_2"

				},
                
				passives: new string[] 
				{
				
"Drowned Dead"

				},
				
				weights: new int[]
				{
					1000,
					0,
					0,
					0,
					0,
					0
				}
            );

        public static EncounterSheet puck_1 = new EncounterSheet
            (
                name: @"Puck",
                icon: @"icons/arcane_blast",
                tooltip: @"Puck is the master of mischief!

Guide the Fairies to the Spirit Catcher, but watch out. Puck spawns Brimstone, Reagent and Wildfire which influences the board heavily.",
                
				min_depth: 1,
				max_depth: 99,
				
				objectives: new string[] 
				{
				
"puck_luk_win",
"puck_turn_loss"

				},
                
				passives: new string[] 
				{
				
"Puck"

				},
				
				weights: new int[]
				{
					0,
					0,
					0,
					0,
					0,
					1000
				}
            );


    }
}