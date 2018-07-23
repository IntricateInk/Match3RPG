using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Encounter
{
    public sealed partial class EncounterSheet : ITooltip
    {
		        public static EncounterSheet mole_1 = new EncounterSheet
            (
                name: "Minor Mole Infestation",
                icon: "skills/bash",
                tooltip: "Hole-y Mole-y! That IS A LOT OF MOLES.",
                
				mainObjectives: new string[] 
				{
				
"mole_1_main_agi",
"mole_1_main_cha",
"mole_main_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
"mole_bonus_luk"

				},
				
				passives: new string[] 
				{
				
"Mole Infestation! (2)"

				}
            );

        public static EncounterSheet mole_2 = new EncounterSheet
            (
                name: "Mole Infestation",
                icon: "skills/bash",
                tooltip: "Hole-y Mole-y! That IS A LOT OF MOLES.",
                
				mainObjectives: new string[] 
				{
				
"mole_2_main_agi",
"mole_2_main_cha",
"mole_main_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
"mole_bonus_luk"

				},
				
				passives: new string[] 
				{
				
"Mole Infestation! (3)"

				}
            );

        public static EncounterSheet mole_3 = new EncounterSheet
            (
                name: "Major Mole Infestation!",
                icon: "skills/bash",
                tooltip: "Hole-y Mole-y! That IS A LOT OF MOLES.",
                
				mainObjectives: new string[] 
				{
				
"mole_3_main_agi",
"mole_3_main_cha",
"mole_main_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
"mole_bonus_luk"

				},
				
				passives: new string[] 
				{
				
"Mole Infestation! (4)"

				}
            );

        public static EncounterSheet phantom_str = new EncounterSheet
            (
                name: "Phantom Berserker",
                icon: "tokens/str",
                tooltip: "The restless spirit of a dead warrior haunts you.",
                
				mainObjectives: new string[] 
				{
				
"phantom_main_agi_str_win",
"phantom_main_str_loss",
"phantom_main_agi_loss",
"phantom_main_turn_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Phantom Berserker"

				}
            );

        public static EncounterSheet phantom_agi = new EncounterSheet
            (
                name: "Phantom Swindler",
                icon: "tokens/agi",
                tooltip: "The restless spirit of a dead rogue haunts you.",
                
				mainObjectives: new string[] 
				{
				
"phantom_main_agi_int_win",
"phantom_main_agi_loss",
"phantom_main_int_loss",
"phantom_main_turn_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Phantom Swindler"

				}
            );

        public static EncounterSheet phantom_int = new EncounterSheet
            (
                name: "Phantom Navigator",
                icon: "tokens/int",
                tooltip: "The restless spirit of a dead navigator haunts you.",
                
				mainObjectives: new string[] 
				{
				
"phantom_main_int_cha_win",
"phantom_main_cha_loss",
"phantom_main_int_loss",
"phantom_main_turn_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Phantom Navigator"

				}
            );

        public static EncounterSheet phantom_luk = new EncounterSheet
            (
                name: "Phantom Jester",
                icon: "tokens/luk",
                tooltip: "The restless spirit of a dead jester haunts you.",
                
				mainObjectives: new string[] 
				{
				
"phantom_main_agi_luk_win",
"phantom_main_agi_loss",
"phantom_main_luk_loss",
"phantom_main_turn_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Phantom Jester"

				}
            );

        public static EncounterSheet phantom_cha = new EncounterSheet
            (
                name: "Phantom Noble",
                icon: "tokens/cha",
                tooltip: "The restless spirit of a dead noble haunts you.",
                
				mainObjectives: new string[] 
				{
				
"phantom_main_cha_luk_win",
"phantom_main_cha_loss",
"phantom_main_luk_loss",
"phantom_main_turn_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Phantom Noble"

				}
            );

        public static EncounterSheet monkey_1 = new EncounterSheet
            (
                name: "Monkey Forest",
                icon: "tokens/agi",
                tooltip: "A forest full of monkeys…… great",
                
				mainObjectives: new string[] 
				{
				
"monkey_luk_win",
"monkey_1_stragi_win",
"monkey_1_intcha_win",
"monkey_1_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Monkey Jungle"

				}
            );

        public static EncounterSheet monkey_2 = new EncounterSheet
            (
                name: "Monkey Jungle",
                icon: "tokens/agi",
                tooltip: "A forest full of monkeys…… great",
                
				mainObjectives: new string[] 
				{
				
"monkey_luk_win",
"monkey_2_stragi_win",
"monkey_2_intcha_win",
"monkey_2_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Monkey Jungle"

				}
            );

        public static EncounterSheet monkey_3 = new EncounterSheet
            (
                name: "Monkey Thicklet",
                icon: "tokens/agi",
                tooltip: "A forest full of monkeys…… great",
                
				mainObjectives: new string[] 
				{
				
"monkey_luk_win",
"monkey_3_stragi_win",
"monkey_3_intcha_win",
"monkey_3_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Monkey Jungle"

				}
            );

        public static EncounterSheet wildfire_1 = new EncounterSheet
            (
                name: "Small Forest Fire",
                icon: "tokens/agi",
                tooltip: "The forest is on fire! The forest is on fire!",
                
				mainObjectives: new string[] 
				{
				
"wildfire_1_turn_win",
"wildfire_1_agi_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Small Forest Fire!"

				}
            );

        public static EncounterSheet wildfire_2 = new EncounterSheet
            (
                name: "Forest Fire",
                icon: "tokens/agi",
                tooltip: "The forest is on fire! The forest is on fire!",
                
				mainObjectives: new string[] 
				{
				
"wildfire_2_turn_win",
"wildfire_2_agi_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Forest Fire!"

				}
            );

        public static EncounterSheet wildfire_3 = new EncounterSheet
            (
                name: "Blazing Forest Fire",
                icon: "tokens/agi",
                tooltip: "The forest is on fire! The forest is on fire!",
                
				mainObjectives: new string[] 
				{
				
"wildfire_3_turn_win",
"wildfire_3_agi_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Blazing Forest Fire!"

				}
            );

        public static EncounterSheet dark_room_1 = new EncounterSheet
            (
                name: "Dark Room",
                icon: "tokens/agi",
                tooltip: "The room is really dark",
                
				mainObjectives: new string[] 
				{
				
"dark_room_1_win",
"dark_room_main_loss",
"dark_room_1_turn_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Dark Room"

				}
            );

        public static EncounterSheet dark_room_2 = new EncounterSheet
            (
                name: "Bloodstained Dark Room",
                icon: "tokens/agi",
                tooltip: "The room is really dark",
                
				mainObjectives: new string[] 
				{
				
"dark_room_2_win",
"dark_room_main_loss",
"dark_room_2_turn_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Bloodstained Dark Room"

				}
            );

        public static EncounterSheet dark_room_3 = new EncounterSheet
            (
                name: "Torture Chamber",
                icon: "tokens/agi",
                tooltip: "The room is really dark",
                
				mainObjectives: new string[] 
				{
				
"dark_room_3_win",
"dark_room_main_loss",
"dark_room_3_turn_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Torture Chamber"

				}
            );

        public static EncounterSheet siren_1 = new EncounterSheet
            (
                name: "Ship Graveyard",
                icon: "tokens/cha",
                tooltip: "A beautiful song washes over you.",
                
				mainObjectives: new string[] 
				{
				
"siren_1_int_win",
"siren_1_str_win",
"siren_1_cha_loss",
"siren_1_agi_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
"siren_bonus_luk"

				},
				
				passives: new string[] 
				{
				
"Ship Graveyard"

				}
            );

        public static EncounterSheet siren_2 = new EncounterSheet
            (
                name: "Cape of the Lost",
                icon: "tokens/cha",
                tooltip: "A beautiful song washes over you.",
                
				mainObjectives: new string[] 
				{
				
"siren_2_int_win",
"siren_2_str_win",
"siren_2_cha_loss",
"siren_2_agi_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
"siren_bonus_luk"

				},
				
				passives: new string[] 
				{
				
"Cape of the Lost"

				}
            );

        public static EncounterSheet siren_3 = new EncounterSheet
            (
                name: "Basin of Sorrow",
                icon: "tokens/cha",
                tooltip: "A beautiful song washes over you.",
                
				mainObjectives: new string[] 
				{
				
"siren_3_int_win",
"siren_3_str_win",
"siren_3_cha_loss",
"siren_3_agi_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
"siren_bonus_luk"

				},
				
				passives: new string[] 
				{
				
"Basin of Sorrow"

				}
            );

        public static EncounterSheet zombie_1 = new EncounterSheet
            (
                name: "Unearthed Graveyard",
                icon: "skills/bash",
                tooltip: "The graves are empty.",
                
				mainObjectives: new string[] 
				{
				
"zombie_1_str_win",
"zombie_1_agi_win",
"zombie_1_stragi_lose"

				},
                
				bonusObjectives: new string[] 
				{
				
"zombie_bonus_int",
"zombie_bonus_cha"

				},
				
				passives: new string[] 
				{
				
"Unearthed Graveyard"

				}
            );

        public static EncounterSheet zombie_2 = new EncounterSheet
            (
                name: "Desecrated Ground",
                icon: "skills/bash",
                tooltip: "The graves are empty.",
                
				mainObjectives: new string[] 
				{
				
"zombie_2_str_win",
"zombie_2_agi_win",
"zombie_2_stragi_lose"

				},
                
				bonusObjectives: new string[] 
				{
				
"zombie_bonus_int",
"zombie_bonus_cha"

				},
				
				passives: new string[] 
				{
				
"Desecrated Ground"

				}
            );

        public static EncounterSheet zombie_3 = new EncounterSheet
            (
                name: "Necropolis",
                icon: "skills/bash",
                tooltip: "The graves are empty.",
                
				mainObjectives: new string[] 
				{
				
"zombie_3_str_win",
"zombie_3_agi_win",
"zombie_3_stragi_lose"

				},
                
				bonusObjectives: new string[] 
				{
				
"zombie_bonus_int",
"zombie_bonus_cha"

				},
				
				passives: new string[] 
				{
				
"Necropolis"

				}
            );


    }
}