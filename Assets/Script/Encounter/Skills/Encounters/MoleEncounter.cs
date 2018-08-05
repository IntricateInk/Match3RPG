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
                sprite: "icons/burrow",
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
}