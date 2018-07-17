using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Encounter
{
    public sealed partial class EncounterSheet : ITooltip
    {
		        public static EncounterSheet TEST_1 = new EncounterSheet
            (
                name: "Brawl",
                icon: "skills/bash",
                tooltip: "LOTS AND LOTS OF FISTS?",
                
				mainObjectives: new string[] 
				{
				
"TEST_2"

				},
                
				bonusObjectives: new string[] 
				{
				
"TEST_1",
"TEST_3",
"TEST_4"

				},
				
				passives: new string[] 
				{
				
				}
            );

        public static EncounterSheet mole_encounter_1 = new EncounterSheet
            (
                name: "Minor Mole Infestation",
                icon: "skills/bash",
                tooltip: "Hole-y Mole-y! That IS A LOT OF MOLES.",
                
				mainObjectives: new string[] 
				{
				
"mole_encounter_1_main_agi_50",
"mole_encounter_1_main_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Mole Infestation! (2)"

				}
            );

        public static EncounterSheet mole_encounter_2 = new EncounterSheet
            (
                name: "Mole Infestation",
                icon: "skills/bash",
                tooltip: "Hole-y Mole-y! That IS A LOT OF MOLES.",
                
				mainObjectives: new string[] 
				{
				
"mole_encounter_1_main_agi_60",
"mole_encounter_1_main_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Mole Infestation! (2)"

				}
            );

        public static EncounterSheet mole_encounter_3 = new EncounterSheet
            (
                name: "Major Mole Infestation!",
                icon: "skills/bash",
                tooltip: "Hole-y Mole-y! That IS A LOT OF MOLES.",
                
				mainObjectives: new string[] 
				{
				
"mole_encounter_1_main_agi_60",
"mole_encounter_1_main_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Mole Infestation! (4)"

				}
            );

        public static EncounterSheet mole_encounter_4 = new EncounterSheet
            (
                name: "Mole Scouting Party",
                icon: "skills/bash",
                tooltip: "Hole-y Mole-y! That IS A LOT OF MOLES.",
                
				mainObjectives: new string[] 
				{
				
"mole_encounter_1_main_agi_70",
"mole_encounter_1_main_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
				},
				
				passives: new string[] 
				{
				
"Mole Infestation! (4)"

				}
            );

        public static EncounterSheet mole_encounter_5 = new EncounterSheet
            (
                name: "Army of Moles",
                icon: "skills/bash",
                tooltip: "Hole-y Mole-y! That IS A LOT OF MOLES.",
                
				mainObjectives: new string[] 
				{
				
"mole_encounter_1_main_agi_70",
"mole_encounter_1_main_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
"mole_encounter_1_bonus"

				},
				
				passives: new string[] 
				{
				
"Mole Infestation! (6)"

				}
            );

        public static EncounterSheet mole_encounter_6 = new EncounterSheet
            (
                name: "City of Moles",
                icon: "skills/bash",
                tooltip: "Hole-y Mole-y! That IS A LOT OF MOLES.",
                
				mainObjectives: new string[] 
				{
				
"mole_encounter_1_main_agi_80",
"mole_encounter_1_main_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
"mole_encounter_1_bonus"

				},
				
				passives: new string[] 
				{
				
"Mole Infestation! (6)"

				}
            );

        public static EncounterSheet mole_encounter_7 = new EncounterSheet
            (
                name: "Cathedrel of the Moles",
                icon: "skills/bash",
                tooltip: "Hole-y Mole-y! That IS A LOT OF MOLES.",
                
				mainObjectives: new string[] 
				{
				
"mole_encounter_1_main_agi_80",
"mole_encounter_1_main_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
"mole_encounter_1_bonus"

				},
				
				passives: new string[] 
				{
				
"Mole Infestation! (6)"

				}
            );

        public static EncounterSheet mole_encounter_8 = new EncounterSheet
            (
                name: "King of the Moles",
                icon: "skills/bash",
                tooltip: "Hole-y Mole-y! That IS A LOT OF MOLES.",
                
				mainObjectives: new string[] 
				{
				
"mole_encounter_1_main_agi_90",
"mole_encounter_1_main_loss"

				},
                
				bonusObjectives: new string[] 
				{
				
"mole_encounter_1_bonus"

				},
				
				passives: new string[] 
				{
				
"Mole Infestation! (6)"

				}
            );


    }
}