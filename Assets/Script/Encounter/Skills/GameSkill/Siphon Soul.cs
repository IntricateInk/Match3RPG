using Match3.Encounter.Effect.Passive;
using Match3.UI.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill SIPHON_SOUL = new GameSkill
        (
            name: "Siphon Soul",
            sprite: "icons/undead_power",
            tooltip: "Destroy all Zombie tokens and gain them as Resource.",

            energyCost: 1,

            selectBehavior: SelectBehavior.None,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in encounter.boardState.GetTokens())
                {
                    if (token.Passives.Contains(TargetPassive.ZOMBIE))
                    {
                        if (token.type != TokenType.BLANK)
                            GameEffect.LineAnimation("line_white", token.AsIPosition(), token.type.AsIPosition(), 0f);
                        token.PlayAnimation("beam1", 0f);
                        GameEffect.BeginSequence();
                        token.ShowResourceGain(1);
                        encounter.playerState.GainResource(token.type, 1);
                        token.Destroy();
                        GameEffect.EndSequence();
                    }
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}