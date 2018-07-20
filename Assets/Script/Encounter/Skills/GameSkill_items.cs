﻿using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

            energyCost: 2,

            strCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                GameEffect.SelectSurrounding(encounter, targets);
                GameEffect.PlayAnimation(encounter, targets, "spark1");
                GameEffect.DestroySelected(encounter, targets);
                GameEffect.EndAnimationBatch();
            }
        );

        public static GameSkill CHOP = new GameSkill
        (
            name: "Chop!",
            sprite: "skills/bash",
            tooltip: "Destroy a column of tokens.",

            energyCost: 1,

            strCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                int x = targets[0].x;
                for (int y = 0; y < encounter.boardState.sizeY; y++)
                {
                    TokenState token = encounter.boardState.GetToken(x, y);
                    token.PlayAnimation("spark1");
                    token.Destroy();
                }
                GameEffect.EndAnimationBatch();
            }
        );

        public static GameSkill SLICE = new GameSkill
        (
            name: "Slice!",
            sprite: "skills/bash",
            tooltip: "Destroy a row of tokens.",

            energyCost: 1,

            strCost: 2,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                int y = targets[0].y;
                for (int x = 0; x < encounter.boardState.sizeY; x++)
                {
                    TokenState token = encounter.boardState.GetToken(x, y);
                    token.PlayAnimation("spark1");
                    token.Destroy();
                }
                GameEffect.EndAnimationBatch();
            }
        );

        public static GameSkill SLEIGHT = new GameSkill
        (
            name: "Sleight",
            sprite: "skills/sleight",
            tooltip: "Select two adjacent tiles and swap their positions.",

            energyCost: 1,

            agiCost: 1,

            selectBehavior: SelectBehavior.TwoAdjacent,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                GameEffect.PlayAnimation(encounter, targets, "stargate", normalized_size: 3f);
                GameEffect.SwapFirstTwoSelected(encounter, targets);
                GameEffect.EndAnimationBatch();
            }
        );

        public static GameSkill MASS_INFLUENCE = new GameSkill
        (
            name: "Mass Influence",
            sprite: "skills/sleight",
            tooltip: "Select a tile. Chain. Transform all Selected Tiles into Charisma Tiles.",

            energyCost: 1,

            agiCost: 1,
            chaCost: 3,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.ChainFromFirst(encounter, targets);
                GameEffect.BeginAnimationBatch();
                GameEffect.PlayAnimation(encounter, targets, "glow_bubble", normalized_size: 3f);
                GameEffect.TransformSelectedToType(encounter, targets, TokenType.CHARISMA);
                GameEffect.EndAnimationBatch();
            }
        );

        public static GameSkill INFLUENCE = new GameSkill
        (
            name: "Influence",
            sprite: "skills/sleight",
            tooltip: "Select a tile. Transform it into a Charisma Tile.",

            energyCost: 1,

            chaCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.PlayAnimation(encounter, targets, "glow_bubble", normalized_size: 3f);
                GameEffect.TransformSelectedToType(encounter, targets, TokenType.CHARISMA);
            }
        );

        public static GameSkill SOCIALIZE = new GameSkill
        (
            name: "Socialize",
            sprite: "skills/sleight",
            tooltip: "Select a tile. Gain a Resource of that type.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainSelectedAsResource(encounter, targets);
            }
        );

        public static GameSkill STRATEGIZE = new GameSkill
        (
            name: "Strategize",
            sprite: "skills/sleight",
            tooltip: "Select a tile. Destroy it and gain a Resource of that type.",

            energyCost: 1,

            intCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainSelectedAsResource(encounter, targets);
                GameEffect.DestroySelected(encounter, targets);
            }
        );

        public static GameSkill MINE = new GameSkill
        (
            name: "Mine",
            sprite: "skills/sleight",
            tooltip: "Select a tile. Apply a buff that gains 1 Resource of that tile type at the start of each turn.",

            energyCost: 1,

            intCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.ApplyTileBuff(encounter, targets, TargetPassive.MINER_DRONE);
            }
        );

        public static GameSkill PARASITIC_BURST = new GameSkill
        (
            name: "Parasitic Burst",
            sprite: "skills/sleight",
            tooltip: "Select a token. Gain 4 Resource of that type tile, then apply a buff that loses 1 Resource of that tile type at the start of each turn.",

            energyCost: 1,

            intCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                encounter.playerState.GainResource(token.type, 4);
                token.ApplyBuff(TargetPassive.PARASITE);
                token.ShowResourceGain(token.type, 4);
            }
        );

        public static GameSkill RAINBOW = new GameSkill
        (
            name: "Rainbow",
            sprite: "skills/sleight",
            tooltip: "Select a tile and apply a buff that randomly transforms it at the start of each turn. Gain 3 LUK Resource.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainResource(encounter, targets, TokenType.LUCK, 3);
                GameEffect.ApplyTokenBuff(encounter, targets, TargetPassive.RAINBOW);
            }
        );

        public static GameSkill RICOCHET = new GameSkill
        (
            name: "Ricochet",
            sprite: "skills/sleight",
            tooltip: "Select a token. Chain. Destroy all selected tokens.",

            energyCost: 1,

            agiCost: 1,
            intCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.ChainFromFirst(encounter, targets);
                GameEffect.DestroySelected(encounter, targets);
            }
        );

        public static GameSkill LUCKY_FIND = new GameSkill
        (
            name: "Lucky Find",
            sprite: "skills/sleight",
            tooltip: "Gain a random Resource.",

            energyCost: 1,

            selectBehavior: SelectBehavior.None,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainRandomResource(encounter, targets, 1);
            }
        );

        // to be added to spreadsheet

        public static GameSkill FAST_TALK = new GameSkill
        (
            name: "Fast Talk",
            sprite: "skills/sleight",
            tooltip: "Select a tile. Chain. Transform into a random type.",

            energyCost: 1,

            chaCost: 1,
            lukCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                GameEffect.ChainFromFirst(encounter, targets);
                GameEffect.PlayAnimation(encounter, targets, "glow_bubble", normalized_size: 3f);
                GameEffect.TransformSelectedToRandom(encounter, targets);
                GameEffect.EndAnimationBatch();
            }
        );

        public static GameSkill REPEL = new GameSkill
        (
            name: "Repel",
            sprite: "skills/sleight",
            tooltip: "Select a tile. Swap all adjacent tiles away from it.",

            energyCost: 1,

            strCost: 1,
            agiCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                GameEffect.BeginAnimationBatch();
                foreach (TokenState adj in token.GetAllAdjacent())
                {
                    int dx = adj.x - token.x;
                    int dy = adj.y - token.y;

                    adj.Swap(dx, dy);
                    adj.PlayAnimation("blast2");
                }
                GameEffect.EndAnimationBatch();
            }
        );

        public static GameSkill CROSS_SECTION = new GameSkill
        (
            name: "Cross Section",
            sprite: "skills/bash",
            tooltip: "Select a tile. Destroy it and all adjacent tokens.",

            energyCost: 1,

            strCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                GameEffect.BeginAnimationBatch();
                foreach (TokenState adj in token.GetAllAdjacent())
                {
                    adj.Destroy();
                    adj.PlayAnimation("blast2");
                }
                token.Destroy();
                token.PlayAnimation("blast2");
                GameEffect.EndAnimationBatch();
            }
        );

        public static GameSkill SHOVE = new GameSkill
        (
            name: "Shove",
            sprite: "skills/bash",
            tooltip: "Select two adjacent tokens. Swap them, then destroy the second.",

            energyCost: 1,

            agiCost: 1,

            selectBehavior: SelectBehavior.TwoAdjacent,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState first = targets[0];
                TokenState second = targets[1];

                GameEffect.BeginAnimationBatch();
                first.PlayAnimation("stargate", 3f);
                first.Swap(second);
                second.PlayAnimation("explosion1");
                second.Destroy();
                GameEffect.EndAnimationBatch();
            }
        );

        public static GameSkill BRIBE = new GameSkill
        (
            name: "Bribe",
            sprite: "tokens/cha",
            tooltip: "Select a token. Pay a resource of that type to destroy it.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                if (encounter.playerState.GetResource(token.type) >= 1)
                {
                    encounter.playerState.GainResource(token.type, -1);
                    GameEffect.BeginAnimationBatch();
                    token.PlayAnimation("flux1");
                    token.Destroy();
                    GameEffect.EndAnimationBatch();
                }
            }
        );

        public static GameSkill DESPERATE_STRIKE = new GameSkill
        (
            name: "Desperate Strike",
            sprite: "skills/bash",
            tooltip: "Select a token. Lose all resources of that type to destroy a random token of that type.",

            energyCost: 1,

            strCost: 1,
            agiCost: 1,
            intCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                int amt = encounter.playerState.GetResource(token.type);

                encounter.playerState.GainResource(token.type, -amt);

                List<TokenState> tokens = encounter.boardState.GetTokens(token.type);
                tokens.Shuffle();

                GameEffect.BeginAnimationBatch();
                foreach (TokenState rand_token in tokens.Take(amt))
                {
                    rand_token.PlayAnimation("flux1");
                    rand_token.ShowResourceGain(token.type, -1);
                    rand_token.Destroy();
                }
                GameEffect.EndAnimationBatch();
            }
        );

        public static GameSkill CHEAP_SHOT = new GameSkill
        (
            name: "Cheap Shot",
            sprite: "skills/bash",
            tooltip: "Lose all STR. For each STR lost, destroy a random token.",

            energyCost: 1,

            agiCost: 1,
            lukCost: 1,

            selectBehavior: SelectBehavior.None,

            runEffects: (EncounterState encounter, List<TokenState> targets) =>
            {
                int amt = encounter.playerState.GetResource(TokenType.STRENGTH);

                encounter.playerState.GainResource(TokenType.STRENGTH, -amt);

                List<TokenState> tokens = encounter.boardState.GetTokens();
                tokens.Shuffle();

                GameEffect.BeginAnimationBatch();
                foreach (TokenState rand_token in tokens.Take(amt))
                {
                    rand_token.PlayAnimation("flux1");
                    rand_token.ShowResourceGain(TokenType.STRENGTH, -1);
                    rand_token.Destroy();
                }
                GameEffect.EndAnimationBatch();
            }
        );

        // TODO:

        //- select two tiles, destroy anything between
        //- apply aoe buff that causes tiles to move randomly
        //- destroy a diagonal \ and /
        //- transform adjacent diagonals to this type
        //- transform 3x3 to their most common neighbours
        //- if all types of tiles are in 3x3, transform to this tile
        //- apply copy neighbour buff
        //- apply aoe buff that floats to top
        //- select 4 adjacent and destroy
        //- delete selected type in 5x5
        //- slide path
        //- select row, odd tile moves up, even tile moves down
        //- INVERT all AGI to STR and STR to AGI

        //public static GameSkill BURST = new GameSkill
        //(
        //    name: "Burst",
        //    sprite: "skills/sleight",
        //    tooltip: "Select any two tiles and swap their positions.",

        //    agiCost: 3,

        //    selectBehavior: SelectBehavior.Two,

        //    runEffects: new GameEffect.Action[]
        //    {
        //        GameEffect.BeginAnimationBatch,
        //        GameEffect.PlayAnimation("stargate", normalized_size: 3f),
        //        GameEffect.SwapFirstTwoSelected,
        //        GameEffect.EndAnimationBatch,
        //    }
        //);

        //public static GameSkill ROTATE = new GameSkill
        //(
        //    name: "Rotate",
        //    sprite: "skills/bash",
        //    tooltip: "Select a 2x2 grid and rotate.",

        //    strCost: 1,

        //    selectBehavior: SelectBehavior.Single,

        //    runEffects: new GameEffect.Action[]
        //    {
        //        GameEffect.DestroySelected,
        //    }
        //);

        //public static GameSkill SHIFT = new GameSkill
        //(
        //    name: "Shift",
        //    sprite: "skills/bash",
        //    tooltip: "Select a tile. Move all tiles on its left to the end of this row.",

        //    strCost: 1,

        //    selectBehavior: SelectBehavior.Single,

        //    runEffects: new GameEffect.Action[]
        //    {
        //        GameEffect.DestroySelected,
        //    }
        //);


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