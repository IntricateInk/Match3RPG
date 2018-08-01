using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive ZOMBIE = new TargetPassive
        (
            name: "Zombie",
            sprite: "sprites/zombie_hand",
            tooltip: "Ughhh. At the end of your turn, remove a resource of this token type and apply Zombie to one adjacent non-Zombie token.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                token.AttachAnimation("zombie");
                token.PlayAnimation("beam1", 0.1f);
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                token.DettachAnimation("zombie");
            },

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
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