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


    }
}