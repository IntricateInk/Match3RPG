using Match3.Encounter;
using Match3.Encounter.Encounter;
using Match3.Events.core;
using Match3.Overworld;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Events.list
{
    public class PirateEvent : GameEvent
    {
        public static string title = "Band of Brigands";
        private static string result = null;

        private static string[] options_start = new string[] { "Obediently pay toll", "Never" };
        private static string DIALOG_START = "You go through a narrow canal over the cliff. As you";


        private static string DIALOG_PAY = "A pleasure, now scram.";
        public static string[] options_PAY = new string[] { "Pass through" };
        private static string result_pay = "You lost {0} gold";

        private static string DIALOG_REJECT = "Yer be swimming with the fishes tonight";
        public static string[] options_REJECT = new string[] { "All hands on deck!" };
        private static string result_reject = "You prepare to fight";



        private static string imageUrl = "eventImage/pirate";

        private static int[] weights = new int[]
       {
           0,400,0,0,0,0
       };

        private SCREENTYPE screen = SCREENTYPE.INTRO;

        private enum SCREENTYPE
        {
            INTRO, FIGHT, COMPLETE
        }

        public PirateEvent() : base(title, DIALOG_START, options_start, imageUrl, weights)
        {

        }


        public override void onButtonPress(int buttonPressed)
        {
            switch (this.screen)
            {
                case SCREENTYPE.INTRO:
                    if (buttonPressed == 0) // pay toll
                    {
                        
                        this.screen = SCREENTYPE.COMPLETE;
                        int cost = UnityEngine.Random.Range(30, 60);
                        string processed = string.Format(result_pay, cost);
                        OverworldState.Current.player.GainReward(-cost, 0); ;
                        updateDialog(DIALOG_PAY, options_PAY, processed, imageUrl);
                    }
                    else if (buttonPressed == 1)
                    {
                        //EventManager.Instance.GoBackToOverworld();
                        updateDialog(DIALOG_REJECT, options_REJECT, result_reject, imageUrl);
                        this.screen = SCREENTYPE.FIGHT;
                    }
                    break;
                
                case SCREENTYPE.FIGHT:
                    if (buttonPressed == 0)
                    {
                        EncounterState.NewEncounter(EncounterSheet.siren_1);
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
