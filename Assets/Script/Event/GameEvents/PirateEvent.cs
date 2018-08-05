using Match3.Encounter;
using Match3.Encounter.Encounter;
using Match3.Events.core;
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
        private static string DIALOG_START = "Avast, surrender your Doubloons";


        private static string DIALOG_PAY = "Aye, now scram.";
        public static string[] options_PAY = new string[] { "Pass through" };
        private static string result_pay = "You lost {0}";

        private static string DIALOG_REJECT = "Yer be swimming with the fishes tonight";
        public static string[] options_REJECT = new string[] { "All hands on deck!" };
        private static string result_reject = "You prepare to fight";



        private static string imageUrl = "";

        private static int[] weights = new int[]
       {
           0,100,0,0,0,0
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
                        
                        updateDialog(DIALOG_PAY, options_PAY, result_pay, "");
                    }
                    else if (buttonPressed == 1)
                    {
                        //EventManager.Instance.GoBackToOverworld();
                        updateDialog(DIALOG_REJECT, options_REJECT, result_reject, "");
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
