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
            tooltip: "At the end of each turn, transform this token to the type of resource you have the most of.",

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
                int max = Mathf.Max(encounter.playerState.Resources);
                List<TokenType> types = new List<TokenType>
                (
                    Array.FindAll(TokenTypeHelper.AllResource(), (type) => { return encounter.playerState.GetResource(type) == max; })
                );

                targets[0].type = types.RandomChoice();
                targets[0].PlayAnimation("fire2", 0f);
            }
        );

    }
}