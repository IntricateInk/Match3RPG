using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Encounter.Encounter;
using Match3.Encounter;

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
        this._nodeType = type;
        this._encounterSheet = EncounterSheet.AllEncounters.RandomChoice();
    }


    public static List<string> FetchOverworldNodeTypes()
    {
        string[] array = (string[])nodeType.GetValues(typeof(string));
        List<string> list = new List<string>(array);
        return list;
    }



    public void LoadLevel()
    {
        EncounterState.NewEncounter(_encounterSheet);
    }
}
