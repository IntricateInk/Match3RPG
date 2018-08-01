using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.UI.Animation;

namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive CREW = new TargetPassive
        (
            name: "Crew",
            sprite: "skills/bash",
            tooltip: "When applied, blank the token. If destroyed, lose 25 STR and 25 AGI resources.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].type = TokenType.BLANK;
                targets[0].AttachAnimation("heartbeat");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("heartbeat");
            },

            OnDestroy: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                encounter.playerState.GainResource(TokenType.STRENGTH, -25);
                encounter.playerState.GainResource(TokenType.AGILITY, -25);

                UIAnimationManager.AddAnimation(new UIInstruction_OverlayText(
                    "Crew", "skills/bash",
                    "A crew member dies! You lose 25 STR and AGI.", true));
            }
        );
    }
}