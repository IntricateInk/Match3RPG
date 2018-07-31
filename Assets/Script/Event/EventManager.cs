using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour {

    // singleton access
    public static EventManager _instance { get; private set; } 
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void NewEvent(EventSheet eventSheet)
    {
        EventState.title = eventSheet.title;
        EventState.description = eventSheet.description;
        EventState.options = eventSheet.options;
        EventState.results = eventSheet.results;
        SceneManager.LoadScene("EventEncounter");
    }
}
