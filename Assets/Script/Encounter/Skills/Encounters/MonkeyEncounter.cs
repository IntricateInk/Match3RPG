using Match3.UI.Animation;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        public static CharacterPassive MONKEY_JUNGLE = new CharacterPassive
        (
            name: "Monkey Jungle",
            sprite: "icons/forest_1",
            tooltip: "Many, many monkeys. At the start of your turn, apply the Monkey buff to five random tokens.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                List<TokenState> tokens = encounter.boardState.GetTokens();
                tokens.Shuffle();

                GameEffect.BeginAnimationBatch();
                foreach (TokenState token in tokens.Take(6))
                {
                    GameEffect.LerpAnimation("sprites/monkey", 800f, self.AsIPosition(), token.AsIPosition());
                    token.ApplyBuff(TargetPassive.MONKEY);
                }
                GameEffect.EndAnimationBatch();
            }
        );
    }
}