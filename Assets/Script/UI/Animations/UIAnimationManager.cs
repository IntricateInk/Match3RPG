using Match3.Encounter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI.Animation
{
    public interface UIInstruction
    {
        void Run(UIAnimationManager manager, float dt);
    }

    public interface UIAnimation : UIInstruction
    {
        bool isDone { get; }
    }

    public class UIAnimation_BeginBatch : UIAnimation
    {
        public bool isDone { get { return true; } }
        public void Run(UIAnimationManager manager, float dt) { }
    }

    public class UIAnimation_EndBatch : UIAnimation
    {
        public bool isDone { get { return true; } }
        public void Run(UIAnimationManager manager, float dt) { }
    }

    public class UIAnimationManager : MonoBehaviour
    {
        // statics
        
        private static readonly Queue<UIAnimation> AnimationQueue = new Queue<UIAnimation>();
        private static readonly Queue<UIInstruction> InstructionQueue = new Queue<UIInstruction>();
        private static List<UIAnimation> Current = new List<UIAnimation>();
        
        public static void AddAnimation(UIInstruction instruction, bool isQueued = false)
        {
            if (isQueued)
                AddAnimation(new UIAnimation_InstructionWrapper(instruction));
            else
                InstructionQueue.Enqueue(instruction);
        }

        public static void AddAnimation(UIAnimation animation)
        {
            AnimationQueue.Enqueue(animation);
        }

        public static void ClearAnimation()
        {
            Current.Clear();
            AnimationQueue.Clear();
        }
        
        // instance

        [SerializeField]
        internal UIBoardController board;

        [SerializeField]
        internal Text encounterLabel;

        [SerializeField]
        internal Image encounterIcon;

        [SerializeField]
        internal UIPlayerStateController player;

        [SerializeField]
        internal UISkillContainer skillContainer;

        [SerializeField]
        internal UIBuffContainer buffContainer;

        [SerializeField]
        internal UIObjectiveListController mainObjectives;

        [SerializeField]
        internal UIObjectiveListController bonusObjectives;

        [SerializeField]
        internal UITextOverlayController textOverlay;

        [SerializeField]
        internal Transform canvas;

        internal static event Action<TokenType, int> OnResourceChange;
        internal void RaiseResourceChange(TokenType type, int amount) { if (OnResourceChange != null) OnResourceChange(type, amount); }

        internal static event Action<int> OnTurnChange;
        internal void RaiseTurnChange(int turn) { if (OnTurnChange != null) OnTurnChange(turn); }

        internal static event Action<float> OnTimeChange;
        internal void RaiseTimeChange(float time) { if (OnTimeChange != null) OnTimeChange(time); }

        internal static int SelectedSkill = -1;
        internal static event Action<int> OnSelectedSkill;
        internal void RaiseSelectedSkill(int index)
        {
            SelectedSkill = index;
            if (OnSelectedSkill != null) OnSelectedSkill(index);
        }

        private void Update()
        {
            EncounterState.Current.TimeTick(Time.deltaTime);

            while (UIAnimationManager.InstructionQueue.Count != 0)
                UIAnimationManager.InstructionQueue.Dequeue().Run(this, Time.deltaTime);

            // no current animation and no more animations
            if (UIAnimationManager.Current.Count == 0 && AnimationQueue.Count == 0) return;

            if (UIAnimationManager.Current.Count == 0)
                UIAnimationManager.Current.Add(AnimationQueue.Dequeue());

            while (true) {
                bool is_all_done = true;

                for (int i = 0; i < UIAnimationManager.Current.Count; i++)
                {
                    UIAnimation current_inst = UIAnimationManager.Current[i];
                    current_inst.Run(this, Time.deltaTime);

                    if (current_inst.isDone)
                    {
                        UIAnimationManager.Current.RemoveAt(i);
                        i--;
                    } else
                    {
                        is_all_done = false;
                    }
                }
                
                if (is_all_done)
                {
                    UIAnimationManager.Current.Clear();
                    if (AnimationQueue.Count == 0) return;

                    bool is_batch = false;

                    do
                    {
                        UIAnimation next = AnimationQueue.Dequeue();

                        if (next is UIAnimation_BeginBatch)
                        {
                            is_batch = true;
                        } else if (next is UIAnimation_EndBatch)
                        {
                            is_batch = false;
                        } else { 
                            UIAnimationManager.Current.Add(next);
                        }
                    } while (is_batch);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
