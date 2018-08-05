using Match3.UI.Animation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive
    {
        public static CharacterPassive PURITY = new CharacterPassive
        (
            name: "Purity",
            sprite: "icons/gesture",
            tooltip: "At the start of every turn, gain 3 AGI and spawn 2 Water.",

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.LerpAnimation(TokenType.AGILITY.GetSpritePath(), 800f, self.AsIPosition(), TokenType.AGILITY.AsIPosition());
                encounter.playerState.GainResource(TokenType.AGILITY, 3);

                GameEffect.SpawnTokenBuff(encounter.boardState.GetTokens(), TargetPassive.WATER, 2);
            }
        );
    }
}