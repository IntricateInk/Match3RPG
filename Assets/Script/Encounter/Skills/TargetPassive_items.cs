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

            OnTurnStart: new GameEffect.Action[]
            {
                GameEffect.GainSelectedAsResource(1),
            }
        );

        // Token Passives

        public static TargetPassive PARASITE = new TargetPassive
        (
            name: "Parasite",
            sprite: "skills/bash",
            tooltip: "At the start of each turn, lose 1 Resource of the type of this token.",

            OnTurnStart: new GameEffect.Action[]
            {
                GameEffect.GainSelectedAsResource(-1),
            }
        );
    }
}