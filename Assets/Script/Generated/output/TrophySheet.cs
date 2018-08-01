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
"Cross Section"
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
"Shove",
"Strategize"
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
"Socialize",
"Bribe",
"Fast Talk"
},

			passives: new string[] { 
"Charismatic"
 }

		);

		public static TrophySheet START_NAVIGATOR = new TrophySheet(
			name: "Navigator's Quill",
			sprite: "tokens/int",
			tooltip: "To know where to go, you must first record where you are",

			skills: new string[] {
"Inspect",
"Sleight"
},

			passives: new string[] { 
"Intelligent"
 }

		);

		public static TrophySheet START_JESTER = new TrophySheet(
			name: "Lucky Die",
			sprite: "tokens/luk",
			tooltip: "Fortune favors the fool.",

			skills: new string[] {
"Chain Reaction",
"Ricochet",
"Lucky Find"
},

			passives: new string[] { 
"Lucky"
 }

		);

		public static TrophySheet CITY_KEY = new TrophySheet(
			name: "Key to the City",
			sprite: "tokens/cha",
			tooltip: "You are the major!?",

			skills: new string[] {
"Influence",
"Mass Influence"
},

			passives: new string[] {  }

		);

		public static TrophySheet MASTER_PLANS = new TrophySheet(
			name: "Master Plans",
			sprite: "tokens/int",
			tooltip: "Super secret specific plans that somehow apply to every situation?",

			skills: new string[] {
"Part of the Plan"
},

			passives: new string[] {  }

		);

		public static TrophySheet MOLE_REWARD_1 = new TrophySheet(
			name: "Tamed Mole?",
			sprite: "tokens/int",
			tooltip: "Can you REALLY tame a mole?",

			skills: new string[] {
"Mine"
},

			passives: new string[] {  }

		);

		public static TrophySheet GOLDEN_COIN = new TrophySheet(
			name: "Golden Coin",
			sprite: "tokens/luk",
			tooltip: "It's your lucky day!",

			skills: new string[] {
"Lucky Find"
},

			passives: new string[] {  }

		);

		public static TrophySheet PLYWOOD_BOW = new TrophySheet(
			name: "Plywood Bow",
			sprite: "tokens/agi",
			tooltip: "It is said that this bow is so flexible, it shoots arrows that bend…… are you really that guillble?",

			skills: new string[] {
"Ricochet"
},

			passives: new string[] {  }

		);

		public static TrophySheet PARASITE = new TrophySheet(
			name: "Parasite",
			sprite: "tokens/agi",
			tooltip: "Symbiosis is a thing? Is that you or the parasite speaking anyway.",

			skills: new string[] {
"Parasitic Burst"
},

			passives: new string[] {  }

		);

		public static TrophySheet HEAVY_AXE = new TrophySheet(
			name: "Heavy Axe",
			sprite: "tokens/str",
			tooltip: "Great for chopping AND slicing!",

			skills: new string[] {
"Chop!",
"Slice!"
},

			passives: new string[] {  }

		);

		public static TrophySheet EMBERSTONE = new TrophySheet(
			name: "Emberstone",
			sprite: "tokens/int",
			tooltip: "It glows with power",

			skills: new string[] {
"Ignite"
},

			passives: new string[] {  }

		);

		public static TrophySheet GOLDEN_TONGUE = new TrophySheet(
			name: "Golden Tongue",
			sprite: "tokens/cha",
			tooltip: "A gilb tongue speaks fast",

			skills: new string[] {
"Threaten",
"Guile",
"Wit",
"Affluence"
},

			passives: new string[] {  }

		);

		public static TrophySheet NECRONOMICON = new TrophySheet(
			name: "Necronomicon",
			sprite: "tokens/int",
			tooltip: "A dark book of necromancy",

			skills: new string[] {
"Raise Dead",
"Siphon Soul"
},

			passives: new string[] {  }

		);

		public static TrophySheet SMART_MANTLE = new TrophySheet(
			name: "Smart Mantle",
			sprite: "tokens/int",
			tooltip: "This shows that you are really smart?",

			skills: new string[] {
"Study",
"Profile"
},

			passives: new string[] {  }

		);

		public static TrophySheet TRAP_TOOLS = new TrophySheet(
			name: "Trapmaker's Tools",
			sprite: "tokens/int",
			tooltip: "Set a trap",

			skills: new string[] {
"Set Flamethrower Trap",
"Set Explosive Trap"
},

			passives: new string[] {  }

		);

		public static TrophySheet BANDIT_BANDANA = new TrophySheet(
			name: "Bandit's Bandana",
			sprite: "skills/bash",
			tooltip: "When your live tethers on the edge, anything goes.",

			skills: new string[] {
"Cheap Shot",
"Desperate Strike"
},

			passives: new string[] { 
"Sprinter"
 }

		);

		public static TrophySheet MERCHANT_FLAIR = new TrophySheet(
			name: "Merchant's Flair",
			sprite: "skills/sleight",
			tooltip: "Merchants speak a lot",

			skills: new string[] {
"Fast Talk"
},

			passives: new string[] { 
"Quick Witted"
 }

		);

		public static TrophySheet STRANGE_MAGNET = new TrophySheet(
			name: "Strange Magnet",
			sprite: "skills/sleight",
			tooltip: "It repels only, but why?",

			skills: new string[] {
"Repel"
},

			passives: new string[] {  }

		);

		public static TrophySheet LEADER_OF_MEN = new TrophySheet(
			name: "Leader of Men",
			sprite: "skills/bash",
			tooltip: "You lead men",

			skills: new string[] {},

			passives: new string[] { 
"Commander"
 }

		);

		public static TrophySheet BLACK_MARK = new TrophySheet(
			name: "Black Mark",
			sprite: "tokens/int",
			tooltip: "The black mark of undeath",

			skills: new string[] {},

			passives: new string[] { 
"Cursed"
 }

		);

		public static TrophySheet SPIRIT_WELL = new TrophySheet(
			name: "Well of the Spirits",
			sprite: "tokens/int",
			tooltip: "The spirits gather around this well",

			skills: new string[] {
"Ritual"
},

			passives: new string[] { 
"Awakening"
 }

		);

		public static TrophySheet CLEAR_MIND = new TrophySheet(
			name: "Clear Mind",
			sprite: "tokens/int",
			tooltip: "Breathe.",

			skills: new string[] {
"Absolution",
"Infusion"
},

			passives: new string[] {  }

		);

		public static TrophySheet FLEXIBLE = new TrophySheet(
			name: "Flexible",
			sprite: "tokens/agi",
			tooltip: "Bend into the situation demands",

			skills: new string[] {
"Backflip",
"Switcharoo"
},

			passives: new string[] {  }

		);

		public static TrophySheet BARBARISM = new TrophySheet(
			name: "Barbarism",
			sprite: "tokens/str",
			tooltip: "WRAGGGH",

			skills: new string[] {
"Leap",
"Slam"
},

			passives: new string[] {  }

		);

		public static TrophySheet POWERFUL = new TrophySheet(
			name: "Powerful",
			sprite: "tokens/str",
			tooltip: "Heave with power",

			skills: new string[] {
"Lift",
"Uppercut"
},

			passives: new string[] {  }

		);

		public static TrophySheet CLASS_BEASTMASTER = new TrophySheet(
			name: "Beastmaster",
			sprite: "tokens/str",
			tooltip: "The beastmaster commands beasts to move things",

			skills: new string[] {},

			passives: new string[] {  }

		);

		public static TrophySheet CLASS_PYRO = new TrophySheet(
			name: "Pyromanic",
			sprite: "tokens/str",
			tooltip: "The pyromanic loves destroying tokens",

			skills: new string[] {
"Ignite"
},

			passives: new string[] {  }

		);

		public static TrophySheet CLASS_BERSERKER = new TrophySheet(
			name: "Berserker",
			sprite: "tokens/str",
			tooltip: "The berserker has many ways to gain energy",

			skills: new string[] {
"Shove"
},

			passives: new string[] {  }

		);

		public static TrophySheet CLASS_JESTER = new TrophySheet(
			name: "Jester",
			sprite: "tokens/str",
			tooltip: "The jester is great at moving tokens",

			skills: new string[] {
"Sleight"
},

			passives: new string[] {  }

		);

		public static TrophySheet CLASS_NECROMANCER = new TrophySheet(
			name: "Necromancer",
			sprite: "tokens/str",
			tooltip: "The necromancer uses zombies.",

			skills: new string[] {
"Raise Dead"
},

			passives: new string[] {  }

		);

		public static TrophySheet CLASS_WARRIOR = new TrophySheet(
			name: "Warrior",
			sprite: "tokens/str",
			tooltip: "The warrior is great at destroying tokens",

			skills: new string[] {
"Bash"
},

			passives: new string[] {  }

		);

		public static TrophySheet CLASS_SCHOLAR = new TrophySheet(
			name: "Scholar",
			sprite: "tokens/str",
			tooltip: "The scholar has many ways to gain resources",

			skills: new string[] {
"Study"
},

			passives: new string[] {  }

		);

		public static TrophySheet CLASS_CAPTAIN = new TrophySheet(
			name: "Captain",
			sprite: "tokens/str",
			tooltip: "The commander manipulates crew",

			skills: new string[] {},

			passives: new string[] {  }

		);

		public static TrophySheet CLASS_SHAMAN = new TrophySheet(
			name: "Shaman",
			sprite: "tokens/str",
			tooltip: "The shaman manipulates spirits",

			skills: new string[] {
"Ritual"
},

			passives: new string[] {  }

		);

		public static TrophySheet CLASS_NOBLEMAN = new TrophySheet(
			name: "Nobleman",
			sprite: "tokens/str",
			tooltip: "The nobleman can transform tokens",

			skills: new string[] {
"Influence"
},

			passives: new string[] {  }

		);


    }
}