using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : BasePassive
    {
        private static CharacterPassive SpiritEncounter(string name, int spirits, int spirit_catchers)
        {
            return new CharacterPassive
            (
                name: name,
                sprite: "tokens/int",
                tooltip: string.Format
                ("Spirits wander freely. At the start of the encounter, spawn {0} Spirits and {1} Spirit Catchers.",
                spirits, spirit_catchers),

                OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    List<TokenState> tokens = encounter.boardState.GetTokens();
                    tokens.Shuffle();

                    foreach (TokenState token in tokens.Take(spirits))
                    {
                        token.ApplyBuff(TargetPassive.SPIRIT);
                    }

                    tokens.RemoveRange(0, spirits);

                    foreach (TokenState token in tokens.Take(spirit_catchers))
                    {
                        token.tile.ApplyBuff(TargetPassive.SPIRIT_CATCHER);
                    }
                }
            );
        }

        public static CharacterPassive SPIRIT_1 = SpiritEncounter("Whispering Forest", 6, 2);
        public static CharacterPassive SPIRIT_2 = SpiritEncounter("Verdent Forest", 5, 2);
        public static CharacterPassive SPIRIT_3 = SpiritEncounter("Heart of the Forest", 4, 1);

    }
}