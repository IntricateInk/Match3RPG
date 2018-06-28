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
                mainObjectives: new string[] {
"TEST_2"
},
                bonusObjectives: new string[] {
"TEST_1",
"TEST_3",
"TEST_4"
}
            );


    }
}