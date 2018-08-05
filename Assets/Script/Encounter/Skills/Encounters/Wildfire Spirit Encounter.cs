//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace Match3.Encounter.Effect.Passive
//{
//    public partial class CharacterPassive : ITooltip
//    {
//        private static CharacterPassive WaterZombies
//        (
//            string name,
//            string sprite,
//            int zombie_per_turn,
//            int plague_per_turn,
//            int water_per_turn
//        )
//        {
//            return new CharacterPassive
//            (
//                name: name, sprite: sprite,
//                tooltip: string.Format(
//                    "The drowned rise again. At the start of each turn, spawn {0} Zombie, {1} Plague and {2} Water.",
//                    zombie_per_turn, plague_per_turn, water_per_turn),

//                OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
//                {
//                    GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.ZOMBIE, zombie_per_turn);
//                    GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.PLAGUE, plague_per_turn);
//                    GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.WATER, water_per_turn);
//                }
//            );
//        }

//        public static CharacterPassive WATER_ZOMBIE_1 = WaterZombies("Bloated Corpses", "tokens/str", 1, 1, 2);
//        public static CharacterPassive WATER_ZOMBIE_2 = WaterZombies("Drowned Dead", "tokens/str", 1, 3, 4);
//    }
//}