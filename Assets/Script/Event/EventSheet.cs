using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// class def

public sealed partial class EventSheet
{
    public string title { get; private set; }
    public string description { get; private set; }
    public string[] options { get; private set; }
    public string[] results { get; private set; }

    // constructor
    public EventSheet(
        string title,
        string description,
        string[] options,
        string[] results
    )
    {
        this.title = title;
        this.description = description;
        this.options = options;
        this.results = results;
        
        if (_AllEvents == null)
        {
            _AllEvents = new Dictionary<string, EventSheet>();
        }
        _AllEvents.Add(title, this);
    }
}

public sealed partial class EventSheet {
    private static Dictionary<string, EventSheet> _AllEvents = new Dictionary<string, EventSheet>();
    public static List<EventSheet> AllEvents { get { return new List<EventSheet>(_AllEvents.Values); } }

    public static EventSheet pirate = new EventSheet(
            title: "Pirates of the deep seas",
            description: "You encounter a band of pirate brigands seeking loot",
            options: new string[] { "High Tide", "All ships to port" },
            results: new string[] {"Success", "Fail"}
        );
    public static EventSheet storms = new EventSheet(
            title: "Raging storms",
            description: "You encounter a band of pirate brigands seeking loot",
            options: new string[] { "Await", "Power through" },
            results: new string[] { "Success", "Fail" }
        );

   
}
