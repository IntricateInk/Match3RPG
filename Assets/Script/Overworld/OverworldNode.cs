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
        ELITE,
        REST

    };
    

    public nodeType _nodeType {get; private set;}
    private bool obfuscated;
   


    // constructor
    public OverworldNode (nodeType type)
    {
        this._nodeType = type;
        this._encounterSheet = EncounterSheet.TEST_1;
    }


    public static List<nodeType> FetchOverworldNodeTypes(int depth, int maxDepth)
    {
       

        // Only boss on the last node
        if (depth == maxDepth)
        {
            return new List<nodeType> { nodeType.BOSS };
        }

        // No elites on the first 3 nodes
        if (depth < 4)
        {
            
            return new List<nodeType> { nodeType.MOB, nodeType.EVENT };
        }

        // Only rest site before boss
        if (depth > maxDepth)
        {
            return new List<nodeType> { nodeType.REST };
        }

        // else allow everything
        nodeType[] types = (nodeType[])System.Enum.GetValues(typeof(nodeType));
        List<nodeType> list = new List<nodeType>(types);
        return list;
    }



    public void LoadLevel()
    {
        EncounterState.NewEncounter(_encounterSheet);
    }
}
