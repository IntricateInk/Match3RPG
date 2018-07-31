using Match3.Encounter.Effect.Skill;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class CharacterPassive : ITooltip
    {
        private static CharacterPassive Sirens(string name, int crew, int siren)
        {
            return new CharacterPassive
            (
                name: name,
                sprite: "tokens/cha",
                tooltip: string.Format
                (
                    "A beautiful song washes over your ears... At the start of the encounter, gain 20 AGI and spawn {0} Crew and {1} Sirens.",
                    crew, siren
                ),

                OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
                {
                    encounter.playerState.GainResource(TokenType.AGILITY, 20);

                    List<TokenState> tokens = encounter.boardState.GetTokens();
                    tokens.Shuffle();

                    GameEffect.BeginAnimationBatch();

                    foreach (TokenState token in tokens.Take(crew))
                    {
                        token.ApplyBuff(TargetPassive.CREW);
                    }

                    tokens.RemoveRange(0, crew);

                    foreach (TokenState token in tokens.Take(siren))
                    {
                        token.tile.ApplyBuff(TargetPassive.SIREN);
                    }

                    GameEffect.EndAnimationBatch();
                }
            );
        }

        public static CharacterPassive SIREN_1 = Sirens("Ship Graveyard"  , 2, 2);
        public static CharacterPassive SIREN_2 = Sirens("Cape of the Lost", 2, 4);
        public static CharacterPassive SIREN_3 = Sirens("Basin of Sorrow" , 2, 6);
    }

    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive SIREN = new TargetPassive
        (
            name: "Siren",
            sprite: "tokens/cha",
            tooltip: "At the start of your turn, move to an adjacent non-Siren tile. At the end of your turn, transform this and adjacent tokens into CHA tokens.",

            OnApplyPassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TileState tile = targets[0].tile;
                tile.AttachAnimation("wave2");
            },

            OnRemovePassive: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TileState tile = targets[0].tile;
                tile.DettachAnimation("wave2");
            },

            OnTurnStart: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                TileState tile = targets[0].tile;
                List<TokenState> adjs = tile.token.GetAllAdjacent();
                adjs.RemoveAll((token) => { return !token.Passives.Contains(TargetPassive.SIREN); });

                if (adjs.Count != 0)
                {
                    adjs.Shuffle();
                    TileState adj = adjs[0].tile;

                    tile.RemoveBuff(TargetPassive.SIREN);
                    adj.ApplyBuff(TargetPassive.SIREN);
                }
            },

            OnTurnEnd: (BasePassive self, EncounterState encounter, List<TokenState> targets) =>
            {
                GameEffect.BeginAnimationBatch();

                TokenState token = targets[0];
                List<TokenState> tokens = token.GetAllAdjacent();
                tokens.Add(token);

                foreach (TokenState t in tokens)
                {
                    t.PlayAnimation("wave1", 0.1f);
                    t.type = TokenType.CHARISMA;
                }

                GameEffect.EndAnimationBatch();
            }
        );
    }
}