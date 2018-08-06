using Match3.Encounter.Effect.Passive;
using Match3.Encounter.Effect.Skill;
using Match3.UI.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Match3.Encounter.Effect
{
    internal class GameEffect
    {
        // System Calls

        public delegate void SkillAction(GameSkill self, EncounterState encounter, List<TokenState> selectedTokens);
        public delegate void PassiveAction(BasePassive self, EncounterState encounter, List<TokenState> selectedTokens);
        
        // encounter specific effects

        internal static void BeginAnimationBatch()
        {
            UIAnimationManager.AddAnimation(new UIAnimation_BeginBatch());
        }
        
        internal static void EndAnimationBatch()
        {
            UIAnimationManager.AddAnimation(new UIAnimation_EndBatch());
        }
        
        internal static void BeginSequence()
        {
            UIAnimationManager.AddAnimation(new UIAnimation_BeginSequence());
        }
        
        internal static void EndSequence()
        {
            UIAnimationManager.AddAnimation(new UIAnimation_EndSequence());
        }

        internal static void RotateArea(BoardState board, int x_min, int y_min, int x_max, int y_max)
        {
            int size_x = x_max - x_min + 1;
            int size_y = y_max - y_min + 1;

            int r_x_min = size_x / 2 - 1;
            int r_y_min = size_y / 2 - 1;
            int r_x_max = size_x / 2 - 1;
            int r_y_max = size_y / 2 - 1;

            if (size_x % 2 == 0) r_x_max++;
            if (size_y % 2 == 0) r_y_max++;

            GameEffect.BeginAnimationBatch();
            while (r_x_min >= 0 && r_y_min >= 0 && r_x_max >= 0 && r_y_max >= 0)
            {
                GameEffect.LoopSwap(board.GetTileBox(r_x_min, r_y_min, r_x_max, r_y_max), r_x_max - r_x_min);
                r_x_min--;
                r_y_min--;
                r_x_max++;
                r_y_max++;
            }
            GameEffect.EndAnimationBatch();
        }

        internal static void LerpAnimation(string sprite, float speed, IPosition p0, IPosition p1, float play_time)
        {
            UIAnimationManager.AddAnimation(
                new UIAnimation_LerpIcon(sprite, speed, p0, p1), play_time);
        }

        internal static void LerpAnimation(string sprite, float speed, IPosition p0, IPosition p1)
        {
            UIAnimationManager.AddAnimation(
                new UIAnimation_LerpIcon(sprite, speed, p0, p1));
        }

        internal static void LineAnimation(string name, IPosition target1, IPosition target2, float play_time)
        {
            UIAnimationManager.AddAnimation(new UIAnimation_LineAnimation(name, target1, target2), play_time);
        }

        internal static void LineAnimation(string name, CharacterPassive target1, TokenState target2, float play_time)
        {
            UIAnimationManager.AddAnimation(new UIAnimation_LineAnimation(name, target1, target2), play_time);
        }

        internal static void LineAnimation(string name, TokenState target1, TokenState target2, float play_time)
        {
            UIAnimationManager.AddAnimation(new UIAnimation_LineAnimation(name, target1, target2), play_time);
        }

        internal static void LineAnimation(string name, TokenState target1, TokenState target2)
        {
            UIAnimationManager.AddAnimation(new UIAnimation_LineAnimation(name, target1, target2));
        }

        internal static void LineAnimation(string name, CharacterPassive target1, TokenState target2)
        {
            UIAnimationManager.AddAnimation(new UIAnimation_LineAnimation(name, target1, target2));
        }

        internal static void LineAnimation(string name, TokenState target1, CharacterPassive target2)
        {
            UIAnimationManager.AddAnimation(new UIAnimation_LineAnimation(name, target1, target2));
        }

        internal static void SpawnTileBuff(IEnumerable<TileState> tiles, TargetPassive buff, int amt)
        {
            SpawnTileBuff(new List<TileState>(tiles), buff, amt);
        }

        internal static void SpawnTileBuff(List<TileState> tiles, TargetPassive buff, int amt)
        {
            foreach (TileState tile in tiles.RandomChoice(amt))
            {
                tile.ApplyBuff(buff);
            }
        }

        internal static void SpawnTokenBuff(List<TokenState> tokens, TargetPassive buff, int amt)
        {
            foreach (TokenState token in tokens.RandomChoice(amt))
            {
                token.ApplyBuff(buff);
            }
        }

        internal static void Cascade(EncounterState encounter)
        {
            encounter.boardState.DoTokenFall();
            encounter.boardState.DoMatch();
        }

        internal static void LoopSwap(IEnumerable<TileState> tiles, int displace = 1)
        {
            TileState[] tiles_arr = tiles.ToArray();
            TokenState[] tokens = new TokenState[tiles_arr.Length];

            for (int i = 0; i < tiles_arr.Length; i++)
            {
                tokens[(i + displace) % tiles_arr.Length] = tiles_arr[i].token;
            }

            GameEffect.BeginAnimationBatch();
            for (int j = 0; j < tiles_arr.Length; j++)
            {
                TileState tile = tiles_arr[j];
                tokens[j].SetPosition(tile.x, tile.y);
            }
            GameEffect.EndAnimationBatch();
        }

        internal static List<TokenState> Chain(TokenState token, TargetPassive buff)
        {
            TokenState current = token;
            List<TokenState> selected = new List<TokenState>();
            selected.Add(token);

            while (true)
            {
                List<TokenState> adj_tokens = current.GetAllAdjacent();
                adj_tokens.RemoveAll((t) => { return selected.Contains(t); });
                adj_tokens.RemoveAll((t) => { return !t.Passives.Contains(buff); });

                // no more tokens to chain to
                if (adj_tokens.Count == 0) break;

                current = adj_tokens.RandomChoice();
                selected.Add(current);
            }

            return selected;
        }

        public static List<TokenState> ChainFromFirst(TokenState token, EncounterState encounter)
        {
            TokenState current = token;
            List<TokenState> selected = new List<TokenState>();
            selected.Add(token);

            while (true)
            {
                List<TokenState> adj_tokens = current.GetAllAdjacent();
                adj_tokens.RemoveAll((t) => { return selected.Contains(t); });
                adj_tokens.RemoveAll((t) => { return t.type != token.type; });

                // no more tokens to chain to
                if (adj_tokens.Count == 0) break;

                current = adj_tokens.RandomChoice();
                selected.Add(current);
            }

            return selected;
        }
        
        internal static void SelectRandom(EncounterState encounter, List<TokenState> selectedTokens, int n)
        {
            int size_x = encounter.boardState.sizeX;
            int size_y = encounter.boardState.sizeY;
            
            List<int> rand = RandomUtil.TakeRandomN(0, size_x * size_y, n);

            selectedTokens.Clear();

            foreach (int i in rand)
            {
                int x = i % size_x;
                int y = i / size_y;
                selectedTokens.Add(encounter.boardState.tiles[x, y].token);
            }
        }

        internal static void SelectOffset(EncounterState encounter, List<TokenState> selectedTokens, int x, int y)
        {
            
            {
                List<TokenState> new_selected = new List<TokenState>();

                foreach (TokenState token in selectedTokens)
                {
                    TokenState adj = token.GetAdjacent(x, y);
                    if (adj != null) new_selected.Add(adj);
                }

                selectedTokens.Clear();
                selectedTokens.AddRange(new_selected);
            };
        }
        
        internal static void TransformSelectedToType(EncounterState encounter, List<TokenState> selectedTokens, TokenType type)
        {
            foreach (TokenState token in selectedTokens)
            {
                token.type = type;
            }
        }

        public static void GainSelectedAsResource(EncounterState encounter, List<TokenState> selectedTokens, int amount)
        {
            foreach (TokenState token in selectedTokens)
            {
                encounter.playerState.GainResource(token.type, amount);
            }
        }

        internal static void GainRandomResource(EncounterState encounter, List<TokenState> selectedTokens, int amount)
        {
            encounter.playerState.GainResource(TokenTypeHelper.RandomResource(), amount);
        }

        public static void GainResource(EncounterState encounter, List<TokenState> selectedTokens, TokenType type, int amount)
        {
            encounter.playerState.GainResource(type, amount);
        }
        
        public static void ApplyTileBuff(EncounterState encounter, List<TokenState> selectedTokens, string buff_name)
        {
            ApplyTileBuff(encounter, selectedTokens, TargetPassive.GetPassive(buff_name));
        }

        public static void ApplyTileBuff(EncounterState encounter, List<TokenState> selectedTokens, TargetPassive buff)
        {
            foreach (TokenState token in selectedTokens)
            {
                token.tile.ApplyBuff(buff);
            }
        }

        public static void ApplyTokenBuff(EncounterState encounter, List<TokenState> selectedTokens, string buff_name)
        {
            ApplyTileBuff(encounter, selectedTokens, TargetPassive.GetPassive(buff_name));
        }

        public static void ApplyTokenBuff(EncounterState encounter, List<TokenState> selectedTokens, TargetPassive buff)
        {
            foreach (TokenState token in selectedTokens)
            {
                token.ApplyBuff(buff);
            }
        }
    }
}
