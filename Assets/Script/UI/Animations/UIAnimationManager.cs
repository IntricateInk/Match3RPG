using Match3.Encounter;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Match3.UI.Animation
{
    public abstract class UIInstruction
    {
        internal abstract void Run(UIAnimationManager manager, float dt);
    }

    public abstract class UIAnimation : UIInstruction
    {
        public bool isDone { get; protected set; }
        internal float PlayTime;
        internal bool IsShortCutPlay = false;
    }

    public class UIAnimation_BeginBatch : UIAnimation
    {
        public UIAnimation_BeginBatch() { isDone = true; }
        internal override void Run(UIAnimationManager manager, float dt) { }
    }

    public class UIAnimation_EndBatch : UIAnimation
    {
        public UIAnimation_EndBatch() { isDone = true; }
        internal override void Run(UIAnimationManager manager, float dt) { }
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

        public static void AddAnimation(UIAnimation animation, float play_time)
        {
            animation.PlayTime = play_time;
            animation.IsShortCutPlay = true;

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
        internal UIVictoryOverlayController victoryOverlay;

        [SerializeField]
        internal Transform canvas;

        internal static event Action<TokenType, int> OnResourceChange;
        internal void RaiseResourceChange(TokenType type, int amount) { if (OnResourceChange != null) OnResourceChange(type, amount); }

        internal static event Action<int> OnTurnChange;
        internal void RaiseTurnChange(int turn) { if (OnTurnChange != null) OnTurnChange(turn); }

        internal static event Action<float> OnTimeChange;
        internal void RaiseTimeChange(float time) { if (OnTimeChange != null) OnTimeChange(time); }
        
        internal static event Action<int> OnEnergyChange;
        internal void RaiseEnergyChange(int energy) { if (OnEnergyChange != null) OnEnergyChange(energy); }

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
            ExecuteAllInstructions();

            // no current animation and no more animations
            if (UIAnimationManager.Current.Count == 0 && AnimationQueue.Count == 0) return;
            
            bool load_next_anim = true;

            while (true)
            {
                for (int i = 0; i < UIAnimationManager.Current.Count; i++)
                {
                    UIAnimation current_anim = UIAnimationManager.Current[i];
                    current_anim.Run(this, Time.deltaTime);

                    if (current_anim.IsShortCutPlay)
                    {
                        current_anim.PlayTime -= Time.deltaTime;

                        if (current_anim.PlayTime > 0)
                        {
                            load_next_anim = false;
                        }
                        else if (current_anim.isDone)
                        {
                            UIAnimationManager.Current.RemoveAt(i);
                            i--;
                        }
                    }
                    else
                    {
                        if (current_anim.isDone)
                        {
                            UIAnimationManager.Current.RemoveAt(i);
                            i--;
                        }
                        else
                        {
                            load_next_anim = false;
                        }
                    }
                }

                if (load_next_anim)
                {
                    // no more animations
                    if (AnimationQueue.Count == 0) return;

                    DequeueAnimation();
                } else
                {
                    break;
                }
            }
        }

        private void DequeueAnimation()
        {
            bool is_batch = false;

            do
            {
                UIAnimation next = AnimationQueue.Dequeue();

                if (next is UIAnimation_BeginBatch)
                {
                    is_batch = true;
                }
                else if (next is UIAnimation_EndBatch)
                {
                    is_batch = false;
                }
                else
                {
                    UIAnimationManager.Current.Add(next);
                }
            } while (is_batch);
        }

        private void ExecuteAllInstructions()
        {
            while (UIAnimationManager.InstructionQueue.Count != 0)
                UIAnimationManager.InstructionQueue.Dequeue().Run(this, Time.deltaTime);
        }
    }
}
