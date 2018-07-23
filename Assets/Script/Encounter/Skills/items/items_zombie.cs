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
                sprite: "skills/bash",
                tooltip: string.Format(
                    "The dead rise again. At the start of each turn, spawn {0} Zombies.",
                    zombies_per_turn
                ),
                
                OnTurnStart: (EncounterState encounter, List<TokenState> targets) =>
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

    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive ZOMBIE = new TargetPassive
        (
            name: "Zombie",
            sprite: "skills/bash",
            tooltip: "Ughhh. At the end of your turn, remove a resource of this token type and apply Zombie to one adjacent non-Zombie token.",

            OnApplyPassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                token.AttachAnimation("sewer_splash");
                token.PlayAnimation("dust1", 0.1f);
            },

            OnRemovePassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                token.DettachAnimation("sewer_splash");
            },

            OnTurnEnd: (EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];

                List<TokenState> tokens = token.GetAllAdjacent();
                tokens.RemoveAll((t) => { return t.Passives.Contains(TargetPassive.ZOMBIE); });
                tokens.Shuffle();

                GameEffect.BeginAnimationBatch();

                encounter.playerState.GainResource(token.type, -1);
                token.ShowResourceGain(-1);
                if (tokens.Count != 0) tokens[0].ApplyBuff(TargetPassive.ZOMBIE);

                GameEffect.EndAnimationBatch();
            }
        );
    }
}