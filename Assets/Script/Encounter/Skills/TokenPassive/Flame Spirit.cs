    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Passive
{
    public partial class TargetPassive : BasePassive
    {
        public static TargetPassive FLAME_SPIRIT = new TargetPassive
        (
            name: "Flame Spirit",
            sprite: "skills/sleight",
            tooltip: "When applied, blank the token. At the end of each turn, if on a tile with Spirit Catcher, destroy this token and all other tokens in the row and column.",

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
                    token.PlayAnimation("beam1");

                    List<TileState> row = encounter.boardState.GetTileRow(token.y);
                    List<TileState> col = encounter.boardState.GetTileCol(token.x);

                    row.AddRange(col);

                    GameEffect.BeginAnimationBatch();

                    foreach (TileState tile in row)
                    {
                        tile.PlayAnimation("fire2", 0.2f);

                        if (tile.token != null)
                            tile.token.Destroy();
                    }

                    GameEffect.EndAnimationBatch();
                }
            }
        );

    }
}