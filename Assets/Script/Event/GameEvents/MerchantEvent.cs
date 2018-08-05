using Match3.Character;
using Match3.Encounter;
using Match3.Encounter.Encounter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Events.core;
using Match3.Overworld;

namespace Match3.Events.list
{
    public class MerchantEvent : GameEvent
    {
        /**
         * String declarations
         * 
         * */
        public static string title = "Wayfaring Merchant";
        private static string result = null;

        private static string[] options_start = new string[] { "Hail Them", "Plunder", "Sail away" };
        private static string DIALOG_START = "You see a vessel bearing the mark of the eagle.";

        private static string[] options_trade = new string[] { "Trade", "Politely decline and leave"};
        private static string DIALOG_TRADE = "The nobleman boards your vessel. \"Hail friend, I am a curio collector, would you like to trade your {0} with my {1}?\"";

        private static string[] options_trade_success = new string[] { "Thank you for your patronage" };
        private static string DIALOG_TRADE_SUCCESS = "You pondered for a moment, before deciding to trade them.";
        private static string RESULT_TRADE_SUCCESS = "Exchanged {0} with {1}";


        private static string[] options_trade_fail = new string[] { "(Shrugs)" };
        private static string DIALOG_TRADE_FAIL = "The nobleman boards your vessel. He glaced around the captain's quarters, seemingly uninterested and took his leave.";


        private static string[] options_fight = new string[] { "Engage" };
        private static string DIALOG_FIGHT = "A merchant ship is too good to pass up. You cock up your cannons.";
        private static string RESULT_FIGHT = "You prepare to fight";


        private static string[] options_sail = new string[] { "Back to Map" };
        private static string DIALOG_SAIL= "You ignored the merchant ship and go on your merry ways";

        private static string imageUrl = "eventImage/merchant";
        /**
         * Weighted distributions
         * */

        private static int[] weights = new int[]
        {
           0,1000,0,0,0,0
        };
       

    /**
     *  Enum and constructor
     *
     *   */

    private SCREENSTATE nextState = SCREENSTATE.INTRO;
        private enum SCREENSTATE
        {
            INTRO, TRADE, TRADE_SUCCESS, TRADE_FAIL, FIGHT, SAIL, END
        }

        public MerchantEvent() : base (title, DIALOG_START, options_start, imageUrl, weights)
        {
            
        }

        /**
         * Helper variables
         * */
        TrophySheet trophyToSell = null;
        TrophySheet trophynotOwned = null;
        /**
         * State machine and main function
         * 
         * */

        public override void onButtonPress(int buttonPressed)
        {
            switch (this.nextState)
            {
                case SCREENSTATE.INTRO:
                    
                    if (buttonPressed == 0) // Hail and Trade
                    {
                        
                        List<TrophySheet> ownedTrophy = OverworldState.Current.player.trophies;

                        if (ownedTrophy.Count > 0)
                        {
                            this.trophyToSell = ownedTrophy.RandomChoice();
                            this.trophynotOwned = OverworldState.Current.player.getTrophyNotOwned().RandomChoice();
                            string processed = string.Format(DIALOG_TRADE, trophyToSell.name, trophynotOwned.name);
                            updateDialog(processed, options_trade, result, imageUrl);
                            this.nextState = SCREENSTATE.TRADE;
                        } else

                        {
                            updateDialog(DIALOG_TRADE_FAIL, options_trade_fail, result, imageUrl);
                            this.nextState = SCREENSTATE.END;
                        }


                    } else if (buttonPressed == 1) // Plunder
                    {
                        this.nextState = SCREENSTATE.FIGHT;
                        updateDialog(DIALOG_FIGHT, options_fight, RESULT_FIGHT, imageUrl);

                    } else if (buttonPressed == 2) // Sail Away
                    {
                        updateDialog(DIALOG_SAIL, options_sail, result, imageUrl);
                        this.nextState = SCREENSTATE.END;
                    }
                    break;
                case SCREENSTATE.TRADE:
                    if (buttonPressed == 0) // Agree to trade
                    {
                        OverworldState.Current.player.trophies.Remove(trophyToSell);
                        OverworldState.Current.player.AddTrophy(trophynotOwned);
                        string processed = string.Format(RESULT_TRADE_SUCCESS, trophyToSell.name, trophynotOwned.name);
                        updateDialog(DIALOG_TRADE_SUCCESS, options_trade_success, processed, imageUrl);
                        this.nextState = SCREENSTATE.END;
                    }
                    else if (buttonPressed == 1) // decline
                    {
                        EventManager.instance.GoBackToOverworld();
                    }
                    break;
                case SCREENSTATE.FIGHT:
                    EncounterState.NewEncounter(EncounterSheet.drown_1);
                    break;
                case SCREENSTATE.END:
                    EventManager.instance.GoBackToOverworld();
                    break;
                default:
                    break;
            }
        }

        private void processNextState(SCREENSTATE prevState, SCREENSTATE nextState)
        {

        }
    }

}
