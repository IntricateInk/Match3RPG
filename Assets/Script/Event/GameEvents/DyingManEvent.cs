using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Events.core;

namespace Match3.Events.list
{
    public class DyingManEvent : GameEvent
    {
        public static string title = "";
        private static string result = null;

        public static string[] options_start = new string[] { "" };
        private static string DIALOG_START = "A man capsized ashore. Help me and I will grant ";

        private static string imageUrl = "";

        // SHORE SEA TOWN FOREST RUINS BOSS
        private static int[] weights = new int[]
        {
            0,   0,   700,    0,    0,    0
        };

        private SCREENTYPE screen = SCREENTYPE.INTRO;

        private enum SCREENTYPE
        {
            INTRO, COMPLETE
        }

        public DyingManEvent() : base(title, DIALOG_START, options_start, imageUrl, weights)
        {

        }


        public override void onButtonPress(int buttonPressed)
        {
            switch (this.screen)
            {
                case SCREENTYPE.INTRO:
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