using Match3.Encounter;
using Match3.Encounter.Encounter;
using Match3.Events.core;
using Match3.Overworld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Events.list
{
    public class JoustEvent : GameEvent
    {
        public static string title = "Joust festival";
        private static string result = null;

        public static string[] options_start = new string[] { "Bet 50 gold on the title holder", "Bet 50 gold on the underdog", "Ignore" };
        private static string DIALOG_START = "You arrived just in time for the jousting tournament. The sounds of crowd cheering fills the arena";

        private static string DIALOG_WIN = "Your predictions are proven correct, you stash your fortune away";
        
        private static string result_win = "You gained {0} gold";

        private static string DIALOG_LOSE = "You were proven wrong. Disappointed, you continue your adventure";
        private static string result_lose = "You lost 50 gold";

        private static string DIALOG_PASS = "Only fools deal with devils, you ignore the commotion and continue your adventure";

        private static string[] options_end = new string[] { "Go back adventuring" };

        private static string imageUrl = "eventImage/joust";

        // SHORE SEA TOWN FOREST RUINS BOSS
        private static int[] weights = new int[]
        {
            0,   0,   700,    0,    0,    0
        };

        private SCREENTYPE nextEvent = SCREENTYPE.INTRO;
        private enum SCREENTYPE
        {
            INTRO, WIN, LOSE, COMPLETE
        }

        public JoustEvent() : base(title, DIALOG_START, options_start, imageUrl, weights) {}

        private int winAmount;

        public override void onButtonPress(int buttonPressed)
        {
            switch (this.nextEvent)
            {
                case SCREENTYPE.INTRO:
                    if (buttonPressed == 0)
                    {
                        winAmount = 100;
                        float rand = UnityEngine.Random.Range(0, 1f);
                        if (rand < 0.7)
                        {
                            OverworldState.Current.player.GainReward(winAmount, 0);
                            string processed = string.Format(result_win, winAmount);
                            updateDialog(DIALOG_WIN, options_end, processed, imageUrl);
                        } else
                        {
                            OverworldState.Current.player.GainReward(-50, 0);
                            updateDialog(DIALOG_LOSE, options_end, result_lose, imageUrl);
                        }

                        this.nextEvent = SCREENTYPE.COMPLETE;

                    } else if (buttonPressed == 1)
                    {

                        float rand = UnityEngine.Random.Range(0, 1f);
                        winAmount = 200;
                        if (rand < 0.3)
                        {
                            OverworldState.Current.player.GainReward(winAmount, 0);
                            string processed = string.Format(result_win, winAmount);
                            updateDialog(DIALOG_WIN, options_end, processed, imageUrl);

                        } else
                        {
                            OverworldState.Current.player.GainReward(-50, 0);
                            updateDialog(DIALOG_LOSE, options_end, result_lose, imageUrl);
                        }
                        this.nextEvent = SCREENTYPE.COMPLETE;
                    } else
                    {
                        updateDialog(DIALOG_PASS, options_end, result, imageUrl);
                        this.nextEvent = SCREENTYPE.COMPLETE;
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
