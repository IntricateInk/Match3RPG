using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Character
{
    public sealed partial class TrophySheet
    {
        // Auto Generated

		public static TrophySheet START_WARRIOR = new TrophySheet(
			name: "Warrior's Blood",
			sprite: "tokens/str",
			tooltip: "A warrior's blood",

			skills: new string[] {
"Bash",
"Sleight"
},

			passives: new string[] { 
"Strong"
 }

		);

		public static TrophySheet START_THIEF = new TrophySheet(
			name: "Mark of the Thief",
			sprite: "tokens/agi",
			tooltip: "The mark of a thief",

			skills: new string[] {
"Sleight"
},

			passives: new string[] { 
"Agile"
 }

		);

		public static TrophySheet START_MERCHANT = new TrophySheet(
			name: "Full Pouch",
			sprite: "tokens/cha",
			tooltip: "Merchants ALWAYS have gold",

			skills: new string[] {
"Sleight"
},

			passives: new string[] {  }

		);

		public static TrophySheet START_NAVIGATOR = new TrophySheet(
			name: "Navigator's Quill",
			sprite: "tokens/int",
			tooltip: "To know where to go, you must first record where you are",

			skills: new string[] {
"Sleight"
},

			passives: new string[] {  }

		);

		public static TrophySheet START_JESTER = new TrophySheet(
			name: "Lucky Die",
			sprite: "tokens/luk",
			tooltip: "Fortune favors the fool.",

			skills: new string[] {
"Sleight"
},

			passives: new string[] {  }

		);


    }
}