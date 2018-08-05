using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive DEMON_SOUL = new TargetPassive
        (
            name: "Demon Soul",
            sprite: "icons/unholy_power",
            tooltip: "When applied, blank the token. At the start of each turn, lose 5 of all Resources. At the end of each turn, if on a tile with Spirit Catcher, destroy this token and gain 15 of all Resources.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].AttachAnimation("plasma");
                targets[0].type = TokenType.BLANK;
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                targets[0].DettachAnimation("plasma");
            },

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                encounter.playerState.GainResource(TokenType.STRENGTH, -5);
                encounter.playerState.GainResource(TokenType.AGILITY, -5);
                encounter.playerState.GainResource(TokenType.LUCK, -5);
                encounter.playerState.GainResource(TokenType.INTELLIGENCE, -5);
                encounter.playerState.GainResource(TokenType.CHARISMA, -5);
                targets[0].PlayAnimation("beam1");
                targets[0].ShowResourceGain(TokenType.STRENGTH, -5);
                targets[0].ShowResourceGain(TokenType.AGILITY, -5);
                targets[0].ShowResourceGain(TokenType.LUCK, -5);
                targets[0].ShowResourceGain(TokenType.INTELLIGENCE, -5);
                targets[0].ShowResourceGain(TokenType.CHARISMA, -5);
            },

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                if (token.tile.Passives.Contains(TargetPassive.SPIRIT_CATCHER))
                {
                    encounter.playerState.GainResource(TokenType.STRENGTH, 15);
                    encounter.playerState.GainResource(TokenType.AGILITY, 15);
                    encounter.playerState.GainResource(TokenType.LUCK, 15);
                    encounter.playerState.GainResource(TokenType.INTELLIGENCE, 15);
                    encounter.playerState.GainResource(TokenType.CHARISMA, 15);
                    targets[0].PlayAnimation("beam1");
                    targets[0].ShowResourceGain(TokenType.STRENGTH, 15);
                    targets[0].ShowResourceGain(TokenType.AGILITY, 15);
                    targets[0].ShowResourceGain(TokenType.LUCK, 15);
                    targets[0].ShowResourceGain(TokenType.INTELLIGENCE, 15);
                    targets[0].ShowResourceGain(TokenType.CHARISMA, 15);
                    targets[0].Destroy();
                }
            }
        );

    }
}