using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {

        private static CharacterPassive DrownEncounter(string name, int water_per_turn)
        {
            return new CharacterPassive
            (
                name: name,
                sprite: "tokens/str",
                tooltip: string.Format
                ("You are drowning! At the start of each turn, spawn {0} Water buffs randomly on the board.",
                water_per_turn),

                OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    List<TokenState> tokens = encounter.boardState.GetTokens();
                    tokens.Shuffle();

                    GameEffect.BeginAnimationBatch();
                    foreach (TokenState token in tokens.Take(water_per_turn))
                    {
                        token.ApplyBuff(TargetPassive.WATER);
                    }
                    GameEffect.EndAnimationBatch();
                }
            );
        }

        public static CharacterPassive DROWN_1 = DrownEncounter("Shipwrecked", 3);
        public static CharacterPassive DROWN_2 = DrownEncounter("Whirlpool", 6);
        public static CharacterPassive DROWN_3 = DrownEncounter("Bermuda Triangle?", 9);

    }
}
