using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Encounter.Encounter;

public class OverworldNode {


    public EncounterSheet _encounterSheet { get; private set; } // link to encounter object
    public enum nodeType {
        MOB,
        BOSS,
        SHOP,
        EVENT,

    };


    public nodeType _nodeType {get; private set;}
    private bool obfuscated;
   

    // constructor
    public OverworldNode (nodeType type)
    {
        this.obfuscated = Random.value < 0.3f ? true : false;
        // randomizer
        this._encounterSheet = EncounterSheet.TEST_1;
    }


    public static List<string> FetchOverworldNodeTypes()
    {
        string[] array = (string[])nodeType.GetValues(typeof(string));
        List<string> list = new List<string>(array);
        return list;
    }
}
