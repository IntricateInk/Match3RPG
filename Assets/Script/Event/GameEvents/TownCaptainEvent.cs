﻿using Match3.Encounter;
using Match3.Encounter.Encounter;
using Match3.Events.core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Events.list
{
    public class TownCaptainEvent : GameEvent
    {
        public static string title = "Skills for sale";
        private static string result = null;

        public static string[] options_start = new string[] { "" };
        private static string DIALOG_START = "";

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

        public TownCaptainEvent() : base(title, DIALOG_START, options_start, imageUrl, weights) {}

        private int price;

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
