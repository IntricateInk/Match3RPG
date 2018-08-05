using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive SIREN = new TargetPassive
        (
            name: "Siren",
            sprite: "icons/charm",
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
                adjs.RemoveAll((token) => { return token.tile.Passives.Contains(TargetPassive.SIREN); });

                if (adjs.Count != 0)
                {
                    TileState adj = adjs.RandomChoice().tile;

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