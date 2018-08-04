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

        public static void ChainFromFirst(EncounterState encounter, List<TokenState> selectedTokens)
        {
            TokenState current = selectedTokens[0];
            List<TokenState> adj_tokens = new List<TokenState>();

            while (true)
            {
                adj_tokens = current.GetAllAdjacent();

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
