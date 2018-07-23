using Match3.Encounter.Effect.Skill;
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
            return new CharacterPassive
            (
                name: string.Format("Mole Infestation! ({0})", moles),
                sprite: "tokens/luk",
                tooltip: string.Format
                (
                    "Hole-y Mole-y! That is a lot of moles! You start with 15 STR. At the start of each turn, {0} tokens become moles.",
                    moles
                ),

                OnApplyPassive: (EncounterState encounter, List<TokenState> targets) =>
                {
                    GameEffect.GainResource(encounter, targets, TokenType.STRENGTH, 15);
                },

                OnTurnStart: (EncounterState encounter, List<TokenState> targets) =>
                {
                    List<TokenState> top_3_rows = encounter.boardState.GetTokens().FindAll((token) => { return token.y >= 5; });
                    top_3_rows.Shuffle();

                    GameEffect.BeginAnimationBatch();
                    foreach (TokenState token in top_3_rows.Take(moles))
                    {
                        token.ApplyBuff(TargetPassive.MOLE);
                    }
                    GameEffect.EndAnimationBatch();
                }
            );
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
            tooltip: "At the end of each turn, destroy the token below. If this token is at the bottom row at the start of your turn, lose 5 STR Resource.",

            OnApplyPassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].PlayAnimation("dust1");
                GameEffect.AddTokenAnimation(encounter, targets, "smoke3");
            },

            OnRemovePassive: (EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.RemoveTokenAnimation(encounter, targets, "smoke3");
            },

            OnTurnEnd: (EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                if (token.y == 0)
                {
                    GameEffect.BeginAnimationBatch();
                    encounter.playerState.GainResource(TokenType.STRENGTH, -5);
                    token.PlayAnimation("dust1", 0f);
                    token.ShowResourceGain(TokenType.STRENGTH, -5);
                    GameEffect.EndAnimationBatch();
                }
                else
                {
                    token = token.GetAdjacent(0, -1);
                    GameEffect.BeginAnimationBatch();
                    token.PlayAnimation("dust1", 0f);
                    token.Destroy();
                    GameEffect.EndAnimationBatch();
                }
            }
        );
        
    }
}