using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive RAVEN = new TargetPassive
        (
            name: "Raven",
            sprite: "icons/raven",
            tooltip: "At the end of the turn, swap to the top, then move to another random token.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].AttachAnimation("explosion5");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("explosion5");
            },

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                int top = encounter.boardState.sizeY - 1;

                if (token.y != top)
                {
                    token.Swap(encounter.boardState.GetToken(token.x, top));
                }

                token.RemoveBuff(TargetPassive.RAVEN);
                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.RAVEN, 1);
            }
        );
    }
}
