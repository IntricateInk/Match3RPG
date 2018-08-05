using Match3.Events.core;
using Match3.Events.list;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class EventState{

    //public static string title { get;  set; }
    //public static string description { get;  set; }
    //public static string[] options { get;  set; }
    //public static string[] results { get;  set; }

    
    public static GameEvent gameEvent    { get; set; }
    public static void NewEvent(GameEvent gameEvent)
    {
        if (gameEvent != null)
        {
            EventState.gameEvent = gameEvent;
        }
        else {
            EventState.gameEvent = new MerchantEvent();
        }
        // event state is a static non-unity class to hold event data between scenes.
        SceneManager.LoadScene("EventEncounter");
    }
    public static List<GameEvent> _AllEvents = new List<GameEvent>()
    {
        new MerchantEvent(),
        new PirateEvent(),
    };

    

}


