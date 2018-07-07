using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Encounter.Effect
{
    internal class GameEffect
    {
        public delegate void Action(EncounterState encounter, List<TokenState> selectedTokens);

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

        internal static void Invoke(Action[] actions, EncounterState encounter) { Invoke(actions, encounter, null); }
        internal static void Invoke(Action[] actions, EncounterState encounter, List<TokenState> tokens)
        {
            if (actions == null) return;

            foreach (GameEffect.Action action in actions)
            {
                action(encounter, tokens);
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
            foreach (TokenState token in selectedTokens) {
                while (true)
                {
                    List<TokenState> adj_tokens = new List<TokenState>();

                    TokenState adj_token = token.GetAdjacent(-1, 0);
                    if (adj_token != null && adj_token.type == token.type && !selectedTokens.Contains(adj_token))
                        adj_tokens.Add(adj_token);

                    adj_token = token.GetAdjacent(1, 0);
                    if (adj_token != null && adj_token.type == token.type && !selectedTokens.Contains(adj_token))
                        adj_tokens.Add(adj_token);

                    adj_token = token.GetAdjacent(0, 1);
                    if (adj_token != null && adj_token.type == token.type && !selectedTokens.Contains(adj_token))
                        adj_tokens.Add(adj_token);

                    adj_token = token.GetAdjacent(0, -1);
                    if (adj_token != null && adj_token.type == token.type && !selectedTokens.Contains(adj_token))
                        adj_tokens.Add(adj_token);

                    // no more tokens to chain to
                    if (adj_tokens.Count == 0) break;

                    selectedTokens.Add(adj_tokens.RandomChoice());
                }
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
    }
}
