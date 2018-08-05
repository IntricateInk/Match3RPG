using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Match3.Character;
using Match3.Overworld;
using UnityEngine.UI;
using Match3.Events.core;
using Match3.Events.list;

public class EventManager : MonoBehaviour {

    // EventManager Instance Singleton
    private static EventManager _instance = null;
    public static EventManager instance
    {
        get
        {
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }


    // unity modifiable constants
    [SerializeField]
    public UIEventDisplay MainDisplay;


    // private constants

    public GameEvent gameEvent { get; private set; }
    

    private PlayerSheet player;
    private TrophySheet playerRandomTrophy;
    private TrophySheet trophyNotOwned;
    private int price;
    private int experienceCost;
    void Start()
    {
        //EventState.eventSheet = EventSheet.pirate;
        
        // fetch event state data
        EventManager.instance = this;
        if (EventState.gameEvent == null)
        {
            throw new System.Exception("No Event Sheet found");
        }

        this.gameEvent = EventState.gameEvent;
       // onNewEvent(this.gameEvent);
    }

    /* Entry point for the scene
     * Pass an event sheet object to begin the event.
     **/
    public void onNewEvent(GameEvent eventSheet)
    {

        // get player references
        this.player = OverworldState.Current.player;
        this.playerRandomTrophy = player.trophies.RandomChoice();
        this.trophyNotOwned = player.getTrophyNotOwned().RandomChoice();

        this.price = UnityEngine.Random.Range(60, 100);
        this.experienceCost = UnityEngine.Random.Range(50, 100);

    }


    public void onEventChoiceClick(int index)// choice c
    {
        gameEvent.onButtonPress(index);
        
    }

    public void GoBackToOverworld()
    {
        SceneManager.LoadScene(1);
    }
}
