using Match3.Encounter.Effect.Skill;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        private static CharacterPassive Zombie(string name, int zombies_per_turn)
        {
            return new CharacterPassive
            (
                name: name,
                sprite: "sprites/zombie_hand",
                tooltip: string.Format(
                    "The dead rise again. At the start of each turn, spawn {0} Zombies.",
                    zombies_per_turn
                ),
                
                OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    List<TokenState> tokens = encounter.boardState.GetTokens();
                    tokens.RemoveAll((t) => { return t.Passives.Contains(TargetPassive.ZOMBIE); });
                    tokens.Shuffle();

                    GameEffect.BeginAnimationBatch();

                    foreach (TokenState token in tokens.Take(zombies_per_turn))
                    {
                        token.ApplyBuff(TargetPassive.ZOMBIE);
                    }
                    GameEffect.EndAnimationBatch();
                }
            );
        }

        public static CharacterPassive ZOMBIE_1 = Zombie("Unearthed Graveyard", 2);
        public static CharacterPassive ZOMBIE_2 = Zombie("Desecrated Ground"  , 4);
        public static CharacterPassive ZOMBIE_3 = Zombie("Necropolis"         , 6);
    }
}