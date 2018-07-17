using Match3.Encounter.Effect.Skill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        // Tile Passives

        public static TargetPassive VOID = new TargetPassive
        (
            name: "Void",
            sprite: "skills/bash",
            tooltip: "At the start of each turn, destroy the token on this tile.",
            
            OnTurnStart: new GameEffect.Action[]
            {
                GameEffect.DestroySelected,
            }
        );

        public static TargetPassive RAINBOW = new TargetPassive
        (
            name: "Rainbow",
            sprite: "skills/bash",
            tooltip: "At the start of each turn, transform the token on this tile randomly.",

            OnTurnStart: new GameEffect.Action[]
            {
                GameEffect.TransformSelectedToRandom,
            }
        );
        
        public static TargetPassive NEBULA = new TargetPassive
        (
            name: "Nebula",
            sprite: "skills/bash",
            tooltip: "At the start of each turn, lose 1 Resource of the type of the token on this tile.",

            OnTurnStart: new GameEffect.Action[]
            {
                GameEffect.GainSelectedAsResource(-1),
            }
        );

        public static TargetPassive MINER_DRONE = new TargetPassive
        (
            name: "Miner Drone",
            sprite: "skills/bash",
            tooltip: "At the start of each turn, gain 1 Resource of the type of the token on this tile.",

            OnApplyPassive: new GameEffect.Action[]
            {
                GameEffect.AddTokenAnimation("dust1"),
            },

            OnRemovePassive: new GameEffect.Action[]
            {
                GameEffect.RemoveTokenAnimation("dust1"),
            },

            OnTurnStart: new GameEffect.Action[]
            {
                GameEffect.GainSelectedAsResource(1),
            }
        );

        // tile that eats certain types of tiles. Penalty every turn while it exists, can be removed by feeding it enough tiles

        // tile that eats certain types of tokens and moves to them

        // tile that moves in a L shape, destroy tiles in its wake

        // tile that destroys 3x3 block when a certain token type enters
        
        // pheonix tile transform the current tile to the last tile matched

        // infection tile that spreads to an adjacent un-infected tile. tokens on infected tiles do not count for matches

        // dancing tile that switches the tile on the left at the start of each turn

        // Token Passives

        public static TargetPassive PARASITE = new TargetPassive
        (
            name: "Parasite",
            sprite: "skills/bash",
            tooltip: "At the start of each turn, lose 1 Resource of the type of this token.",

            OnApplyPassive: new GameEffect.Action[]
            {
                GameEffect.AddTokenAnimation("sewer_splash"),
            },

            OnRemovePassive: new GameEffect.Action[]
            {
                GameEffect.RemoveTokenAnimation("sewer_splash"),
            },

            OnTurnStart: new GameEffect.Action[]
            {
                GameEffect.GainSelectedAsResource(-1),
            }
        );

        public static TargetPassive MOLE = new TargetPassive
        (
            name: "Mole",
            sprite: "skills/bash",
            tooltip: "At the start of each turn, destroy the token below. If this token is at the bottom row at the start of your turn, lose 2 Agility Resource.",

            OnApplyPassive: new GameEffect.Action[]
            {
                GameEffect.AddTokenAnimation("smoke3"),
            },

            OnRemovePassive: new GameEffect.Action[]
            {
                GameEffect.RemoveTokenAnimation("smoke3"),
            },

            OnTurnStart: new GameEffect.Action[]
            {
                GameEffect.SelectOffset(0, -1),
                GameEffect.BeginAnimationBatch,
                GameEffect.PlayAnimation("dust1"),
                GameEffect.DestroySelected,
                GameEffect.EndAnimationBatch,
                // if at bottom, eat resource
            }
        );

        // mimic token that transforms to your current most abundant resource at the start of each turn

        // savage token that drains 1 of your lowest resource each turn

        // bomb token that ticks down every turn and explodes and deletes part of the board or remove some buffs / remove resources
        
        // zombie token. zombies another tile once per turn. matching them will not grant resources

        // frog token, jumps to the top of the column if at the bottom

        // voodoo token, grants -1 resource of its type for matching for each turn it exists

        // terror token, causes adjacent tokens of the same type to swap away from it at the start of the turn

        // spiked token. when token is destroyed, lose resource of that type

        // sapping token, drain 1 resource of its type for each adjacent token of the same type

        // chain reaction token. when a tile with chain reaction matches, all tiles with chain reaction match as well
    }
}