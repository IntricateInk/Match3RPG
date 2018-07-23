using Match3.Encounter.Effect.Passive;
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

        public delegate void Action(EncounterState encounter, List<TokenState> selectedTokens);

        // encounter specific effects
        
        internal static void BeginAnimationBatch()
        {
            UIAnimationManager.AddAnimation(new UIAnimation_BeginBatch());
        }

        internal static void EndAnimationBatch()
        {
            UIAnimationManager.AddAnimation(new UIAnimation_EndBatch());
        }

        public static void SelectSurrounding(EncounterState encounter, List<TokenState> selectedTokens)
        {
            TokenState[] old_selected_tokens = selectedTokens.ToArray();
            selectedTokens.Clear();

            foreach (TokenState token in old_selected_tokens)
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        TokenState new_token = token.GetAdjacent(i, j);

                        if (new_token == null) continue;
                        if (selectedTokens.Contains(new_token)) continue;

                        selectedTokens.Add(new_token);
                    }
                }
            }
        }

        internal static void TransformSelectedToRandom(EncounterState encounter, List<TokenState> selectedTokens)
        {
            foreach (TokenState token in selectedTokens)
            {
                token.type = TokenTypeHelper.RandomResource();
            }
        }
        
        public static void DestroySelected(EncounterState encounter, List<TokenState> selectedTokens)
        {
            foreach (TokenState token in selectedTokens)
            {
                token.Destroy();
            }
        }

        public static void SwapFirstTwoSelected(EncounterState encounter, List<TokenState> selectedTokens)
        {
            encounter.inputState.selectedTokens[0].Swap(encounter.inputState.selectedTokens[1]);
        }
        
        internal static void GainSelectedAsResource(EncounterState encounter, List<TokenState> selectedTokens)
        {
            foreach (TokenState token in selectedTokens)
            {
                encounter.playerState.GainResource(token.type, 1);
            }
        }

        public static void ChainFromFirst(EncounterState encounter, List<TokenState> selectedTokens)
        {
            TokenState current = selectedTokens[0];
            List<TokenState> adj_tokens = new List<TokenState>();

            while (true)
            {
                adj_tokens.Clear();

                TokenState adj_token = current.GetAdjacent(-1, 0);
                if (adj_token != null && adj_token.type == current.type && !selectedTokens.Contains(adj_token))
                    adj_tokens.Add(adj_token);

                adj_token = current.GetAdjacent(1, 0);
                if (adj_token != null && adj_token.type == current.type && !selectedTokens.Contains(adj_token))
                    adj_tokens.Add(adj_token);

                adj_token = current.GetAdjacent(0, 1);
                if (adj_token != null && adj_token.type == current.type && !selectedTokens.Contains(adj_token))
                    adj_tokens.Add(adj_token);

                adj_token = current.GetAdjacent(0, -1);
                if (adj_token != null && adj_token.type == current.type && !selectedTokens.Contains(adj_token))
                    adj_tokens.Add(adj_token);

                // no more tokens to chain to
                if (adj_tokens.Count == 0) break;

                current = adj_tokens.RandomChoice();
                selectedTokens.Add(current);
            }
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

        internal static void AddTileAnimation(EncounterState encounter, List<TokenState> selectedTokens, string animation_name, float normalized_size = 1f)
        {
            AddAnimation(encounter, selectedTokens, animation_name, UIAnimation_AddAnimation.AnimationType.Tile_Add, normalized_size);
        }

        internal static void RemoveTileAnimation(EncounterState encounter, List<TokenState> selectedTokens, string animation_name, float normalized_size = 1f)
        {
            AddAnimation(encounter, selectedTokens, animation_name, UIAnimation_AddAnimation.AnimationType.Tile_Remove, normalized_size);
        }

        internal static void AddTokenAnimation(EncounterState encounter, List<TokenState> selectedTokens, string animation_name, float normalized_size = 1f)
        {
            AddAnimation(encounter, selectedTokens, animation_name, UIAnimation_AddAnimation.AnimationType.Token_Add, normalized_size);
        }

        internal static void RemoveTokenAnimation(EncounterState encounter, List<TokenState> selectedTokens, string animation_name, float normalized_size = 1f)
        {
            AddAnimation(encounter, selectedTokens, animation_name, UIAnimation_AddAnimation.AnimationType.Token_Remove, normalized_size);
        }

        internal static void PlayAnimation(EncounterState encounter, List<TokenState> selectedTokens, string animation_name, float normalized_size = 1f)
        {
            AddAnimation(encounter, selectedTokens, animation_name, UIAnimation_AddAnimation.AnimationType.None, normalized_size);
        }

        private static void AddAnimation(EncounterState encounter, List<TokenState> selectedTokens, string animation_name, UIAnimation_AddAnimation.AnimationType animation_type, float normalized_size)
        {
            foreach (TokenState token in selectedTokens)
            {
                UIAnimation anim = new UIAnimation_AddAnimation(animation_name, token.x, token.y, animation_type, normalized_size);
                UIAnimationManager.AddAnimation(anim);
            }
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
