﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive HEROIC_SPIRIT = new TargetPassive
        (
            name: "Heroic Spirit",
            sprite: "skills/sleight",
            tooltip: "When applied, blank the token. At the end of each turn, if on a tile with Spirit Catcher, destroy this token and gain 20 STR and 20 AGI.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].AttachAnimation("plasma");
                targets[0].type = TokenType.BLANK;
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("plasma");
            },

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                if (token.tile.Passives.Contains(TargetPassive.SPIRIT_CATCHER))
                {
                    encounter.playerState.GainResource(TokenType.STRENGTH, 20);
                    encounter.playerState.GainResource(TokenType.AGILITY, 20);
                    targets[0].PlayAnimation("beam1");
                    targets[0].ShowResourceGain(TokenType.STRENGTH, 20);
                    targets[0].ShowResourceGain(TokenType.AGILITY, 20);
                    targets[0].Destroy();
                }
            }
        );

    }
}
