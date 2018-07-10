using Match3.Encounter.Effect.Passive;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect
{
    internal class GameEffect
    {
        // System Calls

        public delegate void Action(EncounterState encounter, List<TokenState> selectedTokens);

        internal static void Invoke(Action[] actions, EncounterState encounter, List<TokenState> tokens)
        {
            if (actions == null) return;

            foreach (GameEffect.Action action in actions)
            {
                action(encounter, tokens);
            }
        }

        // Without Args

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

        // With Args
        
        internal static Action TransformSelectedToType(TokenType type)
        {
            return (EncounterState encounter, List<TokenState> selectedTokens) =>
            {
                foreach (TokenState token in selectedTokens)
                {
                    token.type = type;
                }
            };
        }

        public static Action GainSelectedAsResource(int amount)
        {
            return (EncounterState encounter, List<TokenState> selectedTokens) =>
            {
                foreach (TokenState token in selectedTokens)
                {
                    encounter.playerState.GainResource(token.type, amount);
                }
            };
        }

        internal static Action GainRandomResource(int amount)
        {
            return (EncounterState encounter, List<TokenState> selectedTokens) =>
            {
                encounter.playerState.GainResource(TokenTypeHelper.RandomResource(), amount);
            };
        }

        public static Action GainResource(TokenType type, int amount)
        {
            return (EncounterState encounter, List<TokenState> selectedTokens) =>
            {
                encounter.playerState.GainResource(type, amount);
            };
        }

        public static Action ApplyBuff(string buff_name)
        {
            return (EncounterState encounter, List<TokenState> selectedTokens) =>
            {
                encounter.playerState.ApplyBuff(buff_name);
            };
        }

        public static Action ApplyTileBuff(string buff_name) { return ApplyTileBuff(TargetPassive.GetPassive(buff_name)); }
        public static Action ApplyTileBuff(TargetPassive buff)
        {
            return (EncounterState encounter, List<TokenState> selectedTokens) =>
            {
                foreach (TokenState token in selectedTokens)
                {
                    token.tile.ApplyBuff(buff);
                }
            };
        }

        public static Action ApplyTokenBuff(string buff_name) { return ApplyTileBuff(TargetPassive.GetPassive(buff_name)); }
        public static Action ApplyTokenBuff(TargetPassive buff)
        {
            return (EncounterState encounter, List<TokenState> selectedTokens) =>
            {
                foreach (TokenState token in selectedTokens)
                {
                    token.ApplyBuff(buff);
                }
            };
        }
    }
}
