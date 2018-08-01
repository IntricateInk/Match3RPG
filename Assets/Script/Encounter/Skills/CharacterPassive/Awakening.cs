﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        public static CharacterPassive AWAKENING = new CharacterPassive
        (
            name: "Awakening",
            sprite: "tokens/int",
            tooltip: "At the start of the encounter, spawn 2 Spirit and 1 Spirit Catcher.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                List<TokenState> tokens = encounter.boardState.GetTokens();
                tokens.Shuffle();

                tokens[0].ApplyBuff(TargetPassive.SPIRIT);
                tokens[1].ApplyBuff(TargetPassive.SPIRIT);
                tokens[2].tile.ApplyBuff(TargetPassive.SPIRIT_CATCHER);
            }
        );
    }
}