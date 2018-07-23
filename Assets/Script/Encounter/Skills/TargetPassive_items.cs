using Match3.Encounter.Effect.Skill;
using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        #region TILE

        public static TargetPassive VOID = new TargetPassive
        (
            name: "Void",
            sprite: "skills/bash",
            tooltip: "At the start of each turn, destroy the token on this tile.",

            OnTurnStart: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.DestroySelected(encounter, targets);
            }
        );

        public static TargetPassive RAINBOW = new TargetPassive
        (
            name: "Rainbow",
            sprite: "skills/bash",
            tooltip: "At the start of each turn, transform the token on this tile randomly.",

            OnTurnStart: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.TransformSelectedToRandom(encounter, targets);
            }
        );

        public static TargetPassive NEBULA = new TargetPassive
        (
            name: "Nebula",
            sprite: "skills/bash",
            tooltip: "At the start of each turn, lose 1 Resource of the type of the token on this tile.",

            OnTurnStart: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainSelectedAsResource(encounter, targets, -1);
            }
        );

        public static TargetPassive MINER_DRONE = new TargetPassive
        (
            name: "Miner Drone",
            sprite: "skills/bash",
            tooltip: "At the start of each turn, gain 1 Resource of the type of the token on this tile.",

            OnApplyPassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.AddTileAnimation(encounter, targets, "dust1");
            },

            OnRemovePassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.RemoveTileAnimation(encounter, targets, "dust1");
            },

            OnTurnStart: (EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                GameEffect.BeginAnimationBatch();
                token.PlayAnimation("dust1", 0.1f);
                token.ShowResourceGain(1);
                encounter.playerState.GainResource(token.type, 1);
                GameEffect.EndAnimationBatch();
            }
        );

        #region ENCOUNTER

        public static TargetPassive FLAMETHROWER_TRAP = new TargetPassive
        (
            name: "Flamethrower Trap",
            sprite: "skills/bash",
            tooltip: "If the token is destroyed, destroy all other tokens in the row and column.",

            OnApplyPassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.AttachAnimation("dust3");
            },

            OnRemovePassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.DettachAnimation("dust3");
            },

            OnDestroy: (EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                List<TokenState> row = encounter.boardState.GetRow(token.x);
                List<TokenState> col = encounter.boardState.GetCol(token.y);

                row.AddRange(col);

                GameEffect.BeginAnimationBatch();

                foreach (TokenState other in row)
                {
                    if (other == token) continue;

                    other.PlayAnimation("fire2");
                    other.Destroy();
                }

                GameEffect.EndAnimationBatch();
            }
        );


        public static TargetPassive EXPLOSIVE_TRAP = new TargetPassive
        (
            name: "Explosive Trap",
            sprite: "skills/bash",
            tooltip: "If the token is destroyed, destroy all other tokens in a 3 by 3 grid around it.",

            OnApplyPassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.AttachAnimation("dust2");
            },

            OnRemovePassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].tile.DettachAnimation("dust2");
            },

            OnDestroy: (EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                
                GameEffect.BeginAnimationBatch();
                for (int dx = -1; dx < 1; dx++) {
                    for (int dy = -1; dy < 1; dy++)
                    {
                        TokenState other = token.GetAdjacent(dx, dy);

                        if (other != null && other != token)
                        {
                            other.PlayAnimation("fire2");
                            other.Destroy();
                        }
                    }
                }
                GameEffect.EndAnimationBatch();
            }
        );

        #endregion ENCOUNTER

        #endregion TILE

        // tile that eats certain types of tiles. Penalty every turn while it exists, can be removed by feeding it enough tiles
        // tile that eats certain types of tokens and moves to them
        // tile that moves in a L shape, destroy tiles in its wake
        // tile that destroys 3x3 block when a certain token type enters
        // pheonix tile transform the current tile to the last tile matched
        // infection tile that spreads to an adjacent un-infected tile. tokens on infected tiles do not count for matches
        // dancing tile that switches the tile on the left at the start of each turn

        #region TOKEN

        public static TargetPassive PARASITE = new TargetPassive
        (
            name: "Parasite",
            sprite: "skills/bash",
            tooltip: "At the start of each turn, lose 1 Resource of the type of this token.",

            OnApplyPassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.AddTokenAnimation(encounter, targets, "sewer_splash");
            },

            OnRemovePassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.RemoveTokenAnimation(encounter, targets, "sewer_splash");
            },

            OnTurnStart: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.GainSelectedAsResource(encounter, targets, -1);
            }
        );

        #region ENCOUNTER
        
        public static TargetPassive MONKEY = new TargetPassive
        (
            name: "Monkey",
            sprite: "skills/bash",
            tooltip: "At the end of each turn, transform this token to the type of resource you have the most of.",

            OnApplyPassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].PlayAnimation("fire2");
                targets[0].AttachAnimation("smoke1");
            },

            OnRemovePassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("smoke1");
            },

            OnTurnEnd: (EncounterState encounter, List<TokenState> targets) =>
            {
                int max = Mathf.Max(encounter.playerState.Resources);
                List<TokenType> types = new List<TokenType>
                (
                    Array.FindAll(TokenTypeHelper.AllResource(), (type) => { return encounter.playerState.GetResource(type) == max; })
                );
                
                targets[0].type = types.RandomChoice();
                targets[0].PlayAnimation("fire2", 0f);
            }
        );

        public static TargetPassive WILDFIRE = new TargetPassive
        (
            name: "Wildfire",
            sprite: "skills/bash",
            tooltip: "At the end of each turn, destroy this token and spread to adjacent tokens.",

            OnApplyPassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].AttachAnimation("explosion1");
            },

            OnRemovePassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("explosion1");
            },

            OnTurnEnd: (EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                foreach (TokenState adj in token.GetAllAdjacent())
                {
                    adj.ApplyBuff(TargetPassive.WILDFIRE);
                }

                token.Destroy();
            }
        );

        public static TargetPassive CREW = new TargetPassive
        (
            name: "Crew",
            sprite: "skills/bash",
            tooltip: "If destroyed, lose 25 STR and 25 AGI resources.",

            OnApplyPassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].AttachAnimation("glow_bubble", 3f);
            },

            OnRemovePassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("glow_bubble");
            },

            OnDestroy: (EncounterState encounter, List<TokenState> targets) =>
            {
                encounter.playerState.GainResource(TokenType.STRENGTH, -25);
                targets[0].PlayAnimation("blast2");
                encounter.playerState.GainResource(TokenType.AGILITY, -25);
                UIAnimationManager.AddAnimation(new UIInstruction_OverlayText("A crew member dies!"));
                
                targets[0].ShowResourceGain(TokenType.STRENGTH, -25);
                targets[0].ShowResourceGain(TokenType.AGILITY, -25);
            }
        );

        #endregion ENCOUNTER

        #endregion TOKEN

        //- if token match, then cascade
        //- token that moves 1 tile to similar type
        // token that destroys other adjacent tokens that are not its type
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