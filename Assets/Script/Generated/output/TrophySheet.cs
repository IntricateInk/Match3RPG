using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Character
{
    public sealed partial class TrophySheet
    {
        // Auto Generated

		public static TrophySheet CLASS_PYROMANIC = new TrophySheet(
			name: "Pyromanic",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 70,
			
			skills: new string[]
			{
			
"Ignite",
"Set Flamethrower Trap",
"Rig",
"Flame Shaping"

			},

			passives: new string[] 
			{ 
			
"Hotheaded"
 
			},
			
			upgrades: new string[] 
			{
			
"Trapper's Tools",
"Fast Hands"

			}

		);

		public static TrophySheet ITEM_PYROMANIC_1 = new TrophySheet(
			name: "Trapper's Tools",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 35,
			
			skills: new string[]
			{
			
"Set Explosive Trap",
"Nitro",
"Pillar of Fire",
"Fire Wall"

			},

			passives: new string[] 
			{ 
			
"Hot Tempered"
 
			},
			
			upgrades: new string[] 
			{
			
"Pyromanic"

			}

		);

		public static TrophySheet CLASS_CAPTAIN = new TrophySheet(
			name: "Captain",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 100,
			
			skills: new string[]
			{
			
"Pile On",
"Advance",
"Retreat",
"Flank",
"March"

			},

			passives: new string[] 
			{ 
			
"Commander"
 
			},
			
			upgrades: new string[] 
			{
			
"Banner",
"Emblem",
"Combat Training"

			}

		);

		public static TrophySheet ITEM_CAPTAIN_1 = new TrophySheet(
			name: "Banner",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 35,
			
			skills: new string[]
			{
			
"Kill Command",
"To Arms"

			},

			passives: new string[] 
			{ 
			
"Leader"
 
			},
			
			upgrades: new string[] 
			{
			
"Captain"

			}

		);

		public static TrophySheet CLASS_TAMER = new TrophySheet(
			name: "Animal Tamer",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 70,
			
			skills: new string[]
			{
			
"Command Monkeys",
"Trained Raven",
"Moth Speak"

			},

			passives: new string[] 
			{ 
			 
			},
			
			upgrades: new string[] 
			{
			
"Beastmaster",
"Combat Training"

			}

		);

		public static TrophySheet ITEM_TAMER_1 = new TrophySheet(
			name: "Beastmaster",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 35,
			
			skills: new string[]
			{
			
"Mine",
"Mole Speak",
"Crab Speak",
"Croak"

			},

			passives: new string[] 
			{ 
			 
			},
			
			upgrades: new string[] 
			{
			
"Animal Tamer"

			}

		);

		public static TrophySheet CLASS_NECROMANCER = new TrophySheet(
			name: "Unholy Knowledge",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 70,
			
			skills: new string[]
			{
			
"Raise Dead",
"Siphon Soul",
"Dead Man's Hand"

			},

			passives: new string[] 
			{ 
			
"Commander of Darkness"
 
			},
			
			upgrades: new string[] 
			{
			
"Unholy Mace",
"Keen Mind"

			}

		);

		public static TrophySheet ITEM_NECROMANCER_2 = new TrophySheet(
			name: "Unholy Mace",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 35,
			
			skills: new string[]
			{
			
"Unholy Bash",
"Dead Man's Knee",
"Lifelink",
"Death Pulse"

			},

			passives: new string[] 
			{ 
			 
			},
			
			upgrades: new string[] 
			{
			
"Unholy Knowledge"

			}

		);

		public static TrophySheet CLASS_SHAMAN = new TrophySheet(
			name: "Totem",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 100,
			
			skills: new string[]
			{
			
"Ritual",
"War Chant",
"Bless"

			},

			passives: new string[] 
			{ 
			
"Awakening"
 
			},
			
			upgrades: new string[] 
			{
			
"Emberstaff",
"Keen Mind",
"Emblem"

			}

		);

		public static TrophySheet ITEM_SHAMAN_1 = new TrophySheet(
			name: "Emberstaff",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 35,
			
			skills: new string[]
			{
			
"Kindling",
"Pact",
"Offering"

			},

			passives: new string[] 
			{ 
			 
			},
			
			upgrades: new string[] 
			{
			
"Totem"

			}

		);

		public static TrophySheet CLASS_MONK = new TrophySheet(
			name: "Mediator",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 100,
			
			skills: new string[]
			{
			
"Absolution",
"Taichi"

			},

			passives: new string[] 
			{ 
			
"Empty Mind"
 
			},
			
			upgrades: new string[] 
			{
			
"Prayer Beads",
"Keen Mind",
"Combat Training"

			}

		);

		public static TrophySheet ITEM_MONK_2 = new TrophySheet(
			name: "Prayer Beads",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 35,
			
			skills: new string[]
			{
			
"Pray",
"Crane Fist",
"Zen"

			},

			passives: new string[] 
			{ 
			
"Purity"
 
			},
			
			upgrades: new string[] 
			{
			
"Mediator"

			}

		);

		public static TrophySheet CLASS_WARRIOR = new TrophySheet(
			name: "Combat Training",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 100,
			
			skills: new string[]
			{
			
"Cross Section",
"Swing",
"Uppercut"

			},

			passives: new string[] 
			{ 
			
"Strong"
 
			},
			
			upgrades: new string[] 
			{
			
"Weapon Mastery",
"Bandana",
"Mediator",
"Animal Tamer",
"Captain"

			}

		);

		public static TrophySheet ITEM_WARRIOR_1 = new TrophySheet(
			name: "Weapon Mastery",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 35,
			
			skills: new string[]
			{
			
"Slice!",
"Chop!"

			},

			passives: new string[] 
			{ 
			 
			},
			
			upgrades: new string[] 
			{
			
"Combat Training"

			}

		);

		public static TrophySheet CLASS_THIEF = new TrophySheet(
			name: "Fast Hands",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 100,
			
			skills: new string[]
			{
			
"Sleight",
"Mark"

			},

			passives: new string[] 
			{ 
			
"Agile"
 
			},
			
			upgrades: new string[] 
			{
			
"Escape Artist",
"Pyromanic",
"Strategist",
"Lucky Die",
"Bandana"

			}

		);

		public static TrophySheet ITEM_THIEF_1 = new TrophySheet(
			name: "Escape Artist",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 35,
			
			skills: new string[]
			{
			
"Escape"

			},

			passives: new string[] 
			{ 
			 
			},
			
			upgrades: new string[] 
			{
			
"Fast Hands"

			}

		);

		public static TrophySheet CLASS_SCHOLAR = new TrophySheet(
			name: "Keen Mind",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 100,
			
			skills: new string[]
			{
			
"Strategize",
"Inspect"

			},

			passives: new string[] 
			{ 
			 
			},
			
			upgrades: new string[] 
			{
			
"Curious",
"Unholy Knowledge",
"Totem",
"Mediator",
"Strategist"

			}

		);

		public static TrophySheet ITEM_SCHOLAR_1 = new TrophySheet(
			name: "Curious",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 35,
			
			skills: new string[]
			{
			
"Study",
"Profile"

			},

			passives: new string[] 
			{ 
			 
			},
			
			upgrades: new string[] 
			{
			
"Keen Mind"

			}

		);

		public static TrophySheet CLASS_NOBLE = new TrophySheet(
			name: "Emblem",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 100,
			
			skills: new string[]
			{
			
"Bribe",
"Gesture",
"Articulate"

			},

			passives: new string[] 
			{ 
			
"Charismatic"
 
			},
			
			upgrades: new string[] 
			{
			
"Golden Tongue",
"Totem",
"Lucky Die",
"Captain",
"Funny Hat"

			}

		);

		public static TrophySheet ITEM_NOBLE_1 = new TrophySheet(
			name: "Golden Tongue",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 35,
			
			skills: new string[]
			{
			
"Persuade",
"Sympathise"

			},

			passives: new string[] 
			{ 
			 
			},
			
			upgrades: new string[] 
			{
			
"Emblem"

			}

		);

		public static TrophySheet CLASS_SWINDLER = new TrophySheet(
			name: "Lucky Die",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 100,
			
			skills: new string[]
			{
			
"Switcharoo",
"Alternative Perspective"

			},

			passives: new string[] 
			{ 
			
"Gambler's Gait"
 
			},
			
			upgrades: new string[] 
			{
			
"Incense",
"Fast Hands",
"Emblem"

			}

		);

		public static TrophySheet ITEM_SWINDLER_1 = new TrophySheet(
			name: "Incense",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 35,
			
			skills: new string[]
			{
			
"Heady Fumes",
"Divine"

			},

			passives: new string[] 
			{ 
			 
			},
			
			upgrades: new string[] 
			{
			
"Lucky Die"

			}

		);

		public static TrophySheet CLASS_BERSERKER = new TrophySheet(
			name: "Bandana",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 100,
			
			skills: new string[]
			{
			
"Shove",
"Enrage",
"Smash"

			},

			passives: new string[] 
			{ 
			
"Berserking"
 
			},
			
			upgrades: new string[] 
			{
			
"Raw Power",
"Fast Hands",
"Combat Training"

			}

		);

		public static TrophySheet ITEM_BERSERKER_1 = new TrophySheet(
			name: "Raw Power",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 35,
			
			skills: new string[]
			{
			
"Slam"

			},

			passives: new string[] 
			{ 
			
"Sprinter"
 
			},
			
			upgrades: new string[] 
			{
			
"Bandana"

			}

		);

		public static TrophySheet CLASS_STRATEGIST = new TrophySheet(
			name: "Strategist",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 100,
			
			skills: new string[]
			{
			
"Part of the Plan"

			},

			passives: new string[] 
			{ 
			
"Planned"
 
			},
			
			upgrades: new string[] 
			{
			
"Fast Hands",
"Keen Mind"

			}

		);

		public static TrophySheet CLASS_JESTER = new TrophySheet(
			name: "Funny Hat",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 70,
			
			skills: new string[]
			{
			
"Tumble"

			},

			passives: new string[] 
			{ 
			
"Irregular"
 
			},
			
			upgrades: new string[] 
			{
			
"Jester's Overalls",
"Emblem"

			}

		);

		public static TrophySheet ITEM_JESTER_1 = new TrophySheet(
			name: "Jester's Overalls",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 35,
			
			skills: new string[]
			{
			
"Backflip"

			},

			passives: new string[] 
			{ 
			
"Lithe"
 
			},
			
			upgrades: new string[] 
			{
			
"Funny Hat"

			}

		);

		public static TrophySheet SHOP_ITEM_1 = new TrophySheet(
			name: "Sharp Weapon",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Sharp Weapon"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet SHOP_ITEM_2 = new TrophySheet(
			name: "Flexible",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Flexible"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet SHOP_ITEM_3 = new TrophySheet(
			name: "Shiny Armor",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Shiny Armor"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet SHOP_ITEM_4 = new TrophySheet(
			name: "Shiny Shoes",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Shiny Shoes"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet SHOP_ITEM_5 = new TrophySheet(
			name: "Shiny Cap",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Shiny Cap"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_1 = new TrophySheet(
			name: "Hubris",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Hubris"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_2 = new TrophySheet(
			name: "Arrogant",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Arrogant"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_3 = new TrophySheet(
			name: "Dull",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Dull"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_4 = new TrophySheet(
			name: "Brutish",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Brutish"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_5 = new TrophySheet(
			name: "Lethargic",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Lethargic"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_6 = new TrophySheet(
			name: "Drained",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Drained"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_7 = new TrophySheet(
			name: "Weak",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Weak"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_8 = new TrophySheet(
			name: "Unlucky",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Unlucky"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_9 = new TrophySheet(
			name: "Disfigured",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Disfigured"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_10 = new TrophySheet(
			name: "Wound",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Wound"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_11 = new TrophySheet(
			name: "Lackey",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Lackey"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_12 = new TrophySheet(
			name: "Mired Mind",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Mired Mind"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_13 = new TrophySheet(
			name: "Distracted",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Distracted"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_14 = new TrophySheet(
			name: "Careless",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Careless"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_15 = new TrophySheet(
			name: "Hydrophobia",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Hydrophobia"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_16 = new TrophySheet(
			name: "Sweaty",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Sweaty"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_17 = new TrophySheet(
			name: "Unstable",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Unstable"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_18 = new TrophySheet(
			name: "Cursed",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Cursed"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_19 = new TrophySheet(
			name: "Enemy of the Moles",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Enemy of the Moles"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_20 = new TrophySheet(
			name: "Forgetful",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Forgetful"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_21 = new TrophySheet(
			name: "Weak Willed",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Weak Willed"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_22 = new TrophySheet(
			name: "Slow",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Slow"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_23 = new TrophySheet(
			name: "Feeble",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Feeble"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_24 = new TrophySheet(
			name: "Repulsive",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Repulsive"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_25 = new TrophySheet(
			name: "Unfortunate",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Unfortunate"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);

		public static TrophySheet BAD_26 = new TrophySheet(
			name: "Compulsive",
			sprite: "tokens/agi",
			tooltip: @"",
			
			expCost: 0,
			
			skills: new string[]
			{
			
			},

			passives: new string[] 
			{ 
			
"Compulsive"
 
			},
			
			upgrades: new string[] 
			{
			
			}

		);


    }
}