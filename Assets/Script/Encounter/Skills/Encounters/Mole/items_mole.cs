using Match3.Encounter.Effect.Skill;
using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        private static CharacterPassive MoleInfestation(int moles)
        {
            CharacterPassive passive = new CharacterPassive
            (
                name: string.Format("Mole Infestation! ({0})", moles),
                sprite: "tokens/luk",
                tooltip: string.Format
                (
                    "Hole-y Mole-y! That is a lot of moles! You start with 15 STR. At the start of each turn, {0} tokens become moles.",
                    moles
                ),

                OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    GameEffect.GainResource(encounter, targets, TokenType.STRENGTH, 15);
                },

                OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    List<TokenState> top_3_rows = encounter.boardState.GetTokens().FindAll((token) => { return token.y >= 5; });
                    top_3_rows.Shuffle();

                    GameEffect.BeginAnimationBatch();
                    foreach (TokenState token in top_3_rows.Take(moles))
                    {
                        GameEffect.BeginSequence();
                        GameEffect.LerpAnimation("sprites/mole", 400f, self.AsIPosition(), token.AsIPosition());
                        token.ApplyBuff(TargetPassive.MOLE);
                        GameEffect.EndSequence();
                    }
                    GameEffect.EndAnimationBatch();
                }
            );

            return passive;
        }

        public static CharacterPassive MOLE_INFESTATION_2 = MoleInfestation(2);
        public static CharacterPassive MOLE_INFESTATION_3 = MoleInfestation(3);
        public static CharacterPassive MOLE_INFESTATION_4 = MoleInfestation(4);
    }

    public partial class TargetPassive
    {
        public static TargetPassive MOLE = new TargetPassive
        (
            name: "Mole",
            sprite: "skills/bash",
            tooltip: "At the end of each turn, destroy three tokens below. If this token is at the bottom row at the start of your turn, lose 5 STR Resource.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].PlayAnimation("dust1");
                targets[0].AttachAnimation("mole");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("mole");
            },

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                if (token.y == 0)
                {
                    GameEffect.BeginAnimationBatch();
                    encounter.playerState.GainResource(TokenType.STRENGTH, -5);
                    token.PlayAnimation("dust1", 0.3f);
                    token.ShowResourceGain(TokenType.STRENGTH, -5);
                    GameEffect.EndAnimationBatch();
                }
                else
                {
                    GameEffect.BeginAnimationBatch();
                    for (int i = 0; i < 3; i++)
                    {
                        token = token.GetAdjacent(0, -1);
                        if (token == null) break;
                        token.PlayAnimation("dust1", 0f);
                        token.Destroy();
                    }
                    GameEffect.EndAnimationBatch();
                }
            }
        );
        
    }
}