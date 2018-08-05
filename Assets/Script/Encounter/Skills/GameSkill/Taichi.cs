using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect.Skill
{
    public sealed partial class GameSkill : ITooltip
    {
        public static GameSkill TAICHI = new GameSkill
        (
            name: "Taichi",
            sprite: "icons/focus_3",
            tooltip: "Select a tile. Swap all closest Blank tokens at the top, bottom, left and right to it.",

            energyCost: 1,

            selectBehavior: SelectBehavior.Single,

            runEffects: (GameSkill self, EncounterState encounter, List<TokenState> targets) =>
            {
                TokenState token = targets[0];
                BoardState board = encounter.boardState;
                int x, y;

                GameEffect.BeginAnimationBatch();

                x = token.x - 2;
                y = token.y;
                while (x >= 0)
                {
                    TokenState other = board.GetToken(x, y);
                    if (other != null && other.type == TokenType.BLANK)
                    {
                        if (token.GetAdjacent(-1, 0) != null)
                            token.GetAdjacent(-1, 0).Swap(other);
                        else
                            other.SetPosition(token.x - 1, token.y);
                        break;
                    }
                }

                x = token.x + 2;
                y = token.y;
                while (x < board.sizeX)
                {
                    TokenState other = board.GetToken(x, y);
                    if (other != null && other.type == TokenType.BLANK)
                    {
                        if (token.GetAdjacent(1, 0) != null)
                            token.GetAdjacent(1, 0).Swap(other);
                        else
                            other.SetPosition(token.x + 1, token.y);
                        break;
                    }
                }

                x = token.x;
                y = token.y - 2;
                while (y >= 0)
                {
                    TokenState other = board.GetToken(x, y);
                    if (other != null && other.type == TokenType.BLANK)
                    {
                        if (token.GetAdjacent(0, -1) != null)
                            token.GetAdjacent(0, -1).Swap(other);
                        else
                            other.SetPosition(token.x, token.y - 1);
                        break;
                    }
                }

                x = token.x;
                y = token.y + 2;
                while (y < board.sizeY)
                {
                    TokenState other = board.GetToken(x, y);
                    if (other != null && other.type == TokenType.BLANK)
                    {
                        if (token.GetAdjacent(0, 1) != null)
                            token.GetAdjacent(0, 1).Swap(other);
                        else
                            other.SetPosition(token.x, token.y + 1);
                        break;
                    }
                }

                GameEffect.EndAnimationBatch();
            }
        );
    }
}