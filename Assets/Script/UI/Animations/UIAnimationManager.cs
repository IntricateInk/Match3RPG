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
    
    public class UIAnimationManager : MonoBehaviour
    {
        // statics
        
        private static readonly Queue<UIAnimation> AnimationQueue = new Queue<UIAnimation>();
        private static readonly Queue<UIInstruction> InstructionQueue = new Queue<UIInstruction>();
        private static UIAnimation Current = null;

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

        internal static event Action<TokenType, int> OnResourceChange;
        internal void RaiseResourceChange(TokenType type, int amount) { if (OnResourceChange != null) OnResourceChange(type, amount); }

        private void Update()
        {
            EncounterState.Current.TimeTick(Time.deltaTime);

            while (UIAnimationManager.InstructionQueue.Count != 0)
                UIAnimationManager.InstructionQueue.Dequeue().Run(this, Time.deltaTime);

            // no current animation and no more animations
            if (UIAnimationManager.Current == null && AnimationQueue.Count == 0) return;

            if (UIAnimationManager.Current == null)
                UIAnimationManager.Current = AnimationQueue.Dequeue();

            while (true) {
                UIAnimationManager.Current.Run(this, Time.deltaTime);

                if (UIAnimationManager.Current.isDone)
                {
                    UIAnimationManager.Current = null;
                    if (AnimationQueue.Count == 0) return;

                    UIAnimationManager.Current = AnimationQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }
        }
    }
}
