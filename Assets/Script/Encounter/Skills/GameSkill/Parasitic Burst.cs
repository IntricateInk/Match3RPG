using Match3.Encounter.Effect.Passive;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill PARASITIC_BURST = new GameSkill
        (
            name: "Parasitic Burst",
            sprite: "icons/portal_green",
            tooltip: "Select a token. Gain 4 Resource of that type tile, then apply a buff that loses 1 Resource of that tile type at the start of each turn.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                encounter.playerState.GainResource(token.type, 4);
                token.ApplyBuff(TargetPassive.PARASITE);
                token.ShowResourceGain(token.type, 4);
            }
        );
    }
}