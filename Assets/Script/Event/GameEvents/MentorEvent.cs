using Match3.Encounter;
using Match3.Encounter.Encounter;
using Match3.Events.core;
using Match3.Overworld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Events.list
{
    public class MentorEvent : GameEvent
    {
        public static string title = "A Chance Expertise";
        private static string result = null;

        public static string[] options_start = new string[] { "Pay to join training", "Ignore" };
        public static string[] options_end = new string[] { "Continue adventure" };
        private static string DIALOG_START = "You went past an old barracks with a battalion of soldiers practicing their formation";
        private static string DIALOG_TRAIN = "You learned new military insights";
        private static string DIALOG_IGNORE = "You ignored and went ahead";
        private static string result_practice = "Gained {0} XP, lost {1} Gold";
        private static string imageUrl = "eventImage/mentor";

        // SHORE SEA TOWN FOREST RUINS BOSS
        private static int[] weights = new int[]
        {
            0,   0,   200,    0,    700,    0
        };

        private SCREENTYPE nextState = SCREENTYPE.INTRO;

        private enum SCREENTYPE
        {
            INTRO, COMPLETE
        }

        public MentorEvent() : base(title, DIALOG_START, options_start, imageUrl, weights)
        {

        }


        public override void onButtonPress(int buttonPressed)
        {
            switch (this.nextState)
            {
                case SCREENTYPE.INTRO:
                    if (buttonPressed == 0)
                    {
                        int RandXP = UnityEngine.Random.Range(50, 100);
                        string processed = string.Format(result_practice, RandXP, -50);
                        OverworldState.Current.player.GainReward(-50, RandXP);
                        updateDialog(DIALOG_TRAIN, options_end, processed, imageUrl);
                        this.nextState = SCREENTYPE.COMPLETE;
                    } else
                    {
                        updateDialog(DIALOG_IGNORE, options_end, result, imageUrl);
                        this.nextState = SCREENTYPE.COMPLETE;
                    }
                    break;

                case SCREENTYPE.COMPLETE:

                    EventManager.instance.GoBackToOverworld();
                    break;
                default:
                    break;
            }
        }
    }

}


