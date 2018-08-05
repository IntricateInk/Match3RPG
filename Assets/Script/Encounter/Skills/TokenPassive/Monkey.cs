using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive MONKEY = new TargetPassive
        (
            name: "Monkey",
            sprite: "sprites/monkey",
            tooltip: "At the end of each turn, transform this token to the type of resource you have the most of. Then, move to another token in a 5x5 area around it.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].AttachAnimation("monkey");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("monkey");
            },

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                int max = Mathf.Max(encounter.playerState.Resources);
                List<TokenType> types = new List<TokenType>
                (
                    Array.FindAll(TokenTypeHelper.AllResource(), (type) => { return encounter.playerState.GetResource(type) == max; })
                );

                targets[0].type = types.RandomChoice();

                List<TokenState> adjs = token.GetSurrounding(-2, -2, 2, 2);
                adjs.RemoveAll((t) => { return t.Passives.Contains(TargetPassive.MONKEY); });

                if (adjs.Count != 0)
                {
                    TokenState adj = adjs.RandomChoice();

                    GameEffect.LerpAnimation("sprites/monkey", 800f, token.AsIPosition(), adj.AsIPosition());

                    token.RemoveBuff(TargetPassive.MONKEY);
                    adj.ApplyBuff(TargetPassive.MONKEY);
                }
            }
        );

    }
}