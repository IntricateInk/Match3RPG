using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive
    {
        public static TargetPassive MOLE = new TargetPassive
        (
            name: "Mole",
            sprite: "sprites/mole",
            tooltip: "At the end of each turn, destroy three tokens below. If this token is at the bottom row at the start of your turn, lose 5 STR Resource.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].PlayAnimation("dust1", 0f);
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