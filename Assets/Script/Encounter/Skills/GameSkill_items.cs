using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill BASH = new GameSkill
        (
            name: "Bash",
            sprite: "skills/bash",
            tooltip: "Destroy a 3x3 block of cells.",

            strCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: new GameEffect.Action[]
            {
                GameEffect.BeginAnimationBatch,
                GameEffect.SelectSurrounding,
                GameEffect.PlayAnimation("spark1"),
                GameEffect.DestroySelected,
                GameEffect.EndAnimationBatch,
            }
        );

        //public static GameSkill SHOVE = new GameSkill
        //(
        //    name: "Shove",
        //    sprite: "skills/bash",
        //    tooltip: "Select a Tile. Destroy the token on the left, then move the selected token to the left.",

        //    strCost: 1,

        //    selectBehavior: SelectBehavior.Single,

        //    runEffects: new GameEffect.Action[]
        //    {
        //        GameEffect.DestroySelected,
        //    }
        //);

        public static GameSkill SLEIGHT = new GameSkill
        (
            name: "Sleight",
            sprite: "skills/sleight",
            tooltip: "Select two adjacent tiles and swap their positions.",

            agiCost: 1,

            selectBehavior: SelectBehavior.TwoAdjacent,

            runEffects: new GameEffect.Action[]
            {
                GameEffect.BeginAnimationBatch,
                GameEffect.PlayAnimation("stargate", normalized_size: 3f),
                GameEffect.SwapFirstTwoSelected,
                GameEffect.EndAnimationBatch,
            }
        );
        
        public static GameSkill MASS_INFLUENCE = new GameSkill
        (
            name: "Mass Influence",
            sprite: "skills/sleight",
            tooltip: "Select a tile. Chain. Transform all Selected Tiles into Charisma Tiles.",

            agiCost: 1,
            chaCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: new GameEffect.Action[]
            {
                GameEffect.ChainFromFirst,
                GameEffect.BeginAnimationBatch,
                GameEffect.PlayAnimation("glow_bubble", normalized_size: 3f),
                GameEffect.TransformSelectedToType(TokenType.CHARISMA),
                GameEffect.EndAnimationBatch,
            }
        );

        public static GameSkill INFLUENCE = new GameSkill
        (
            name: "Influence",
            sprite: "skills/sleight",
            tooltip: "Select a tile. Transform it into a Charisma Tile.",

            chaCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: new GameEffect.Action[]
            {
                GameEffect.PlayAnimation("glow_bubble"),
                GameEffect.TransformSelectedToType(TokenType.CHARISMA)
            }
        );

        public static GameSkill SOCIALIZE = new GameSkill
        (
            name: "Socialize",
            sprite: "skills/sleight",
            tooltip: "Select a tile. Gain a Resource of that type.",
            
            selectBehavior: SelectBehavior.Single,

            runEffects: new GameEffect.Action[]
            {
                GameEffect.GainSelectedAsResource
            }
        );

        public static GameSkill STRATEGIZE = new GameSkill
        (
            name: "Strategize",
            sprite: "skills/sleight",
            tooltip: "Select a tile. Destroy it and gain a Resource of that type.",

            intCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: new GameEffect.Action[]
            {
                GameEffect.GainSelectedAsResource,
                GameEffect.DestroySelected
            }
        );

        public static GameSkill MINE = new GameSkill
        (
            name: "Mine",
            sprite: "skills/sleight",
            tooltip: "Select a tile. Apply a buff that gains 1 Resource of that tile type at the start of each turn.",

            intCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: new GameEffect.Action[]
            {
                GameEffect.ApplyTileBuff(TargetPassive.MINER_DRONE)
            }
        );

        public static GameSkill PARASITIC_BURST = new GameSkill
        (
            name: "Parasitic Burst",
            sprite: "skills/sleight",
            tooltip: "Select a token. Gain 4 Resource of that type tile, then apply a buff that loses 1 Resource of that tile type at the start of each turn.",
            
            intCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: new GameEffect.Action[]
            {
                GameEffect.GainSelectedAsResource(4),
                GameEffect.ApplyTokenBuff(TargetPassive.PARASITE)
            }
        );

        public static GameSkill RAINBOW = new GameSkill
        (
            name: "Rainbow",
            sprite: "skills/sleight",
            tooltip: "Select a tile and apply a buff that randomly transforms it at the start of each turn. Gain 3 LUK Resource.",
            
            selectBehavior: SelectBehavior.Single,

            runEffects: new GameEffect.Action[]
            {
                GameEffect.GainResource(TokenType.LUCK, 3),
                GameEffect.ApplyTokenBuff(TargetPassive.RAINBOW)
            }
        );

        public static GameSkill RICOCHET = new GameSkill
        (
            name: "Ricochet",
            sprite: "skills/sleight",
            tooltip: "Select a token. Chain. Destroy all selected tokens.",

            agiCost: 1,
            intCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: new GameEffect.Action[]
            {
                GameEffect.ChainFromFirst,
                GameEffect.DestroySelected,
            }
        );
        
        public static GameSkill LUCKY_FIND = new GameSkill
        (
            name: "Lucky Find",
            sprite: "skills/sleight",
            tooltip: "Gain a random Resource.",

            selectBehavior: SelectBehavior.None,

            runEffects: new GameEffect.Action[]
            {
                GameEffect.GainRandomResource(1)
            }
        );

        // TODO:

        //public static GameSkill HEAVE = new GameSkill
        //(
        //    name: "Heave",
        //    sprite: "skills/sleight",
        //    tooltip: "Select two adjacent rows and swap their positions.",

        //    strCost: 1,
        //    agiCost: 1,

        //    selectBehavior: SelectBehavior.AdjacentRows,

        //    runEffects: new GameEffect.Action[]
        //    {
        //        GameEffect.SwapFirstTwoSelected
        //    }
        //);

        //public static GameSkill SHIFT = new GameSkill
        //(
        //    name: "Shift",
        //    sprite: "skills/sleight",
        //    tooltip: "Select two adjacent columns and swap their positions.",

        //    strCost: 1,
        //    agiCost: 1,

        //    selectBehavior: SelectBehavior.AdjacentCols,

        //    runEffects: new GameEffect.Action[]
        //    {
        //        GameEffect.SwapFirstTwoSelected
        //    }
        //);
    }
}