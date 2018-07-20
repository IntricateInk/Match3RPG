using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Encounter.Encounter;
using Match3.Encounter;

public class OverworldNode
{


    public EncounterSheet _encounterSheet { get; private set; } // link to encounter object
    public enum nodeType
    {
        START,
        MOB,
        BOSS,
        SHOP,
        EVENT,
        ELITE,
        REST

    };


    public nodeType _nodeType { get; private set; }
    private bool obfuscated;

    private int xIndex; // public?
    private int yIndex; // public?

    public int fromEdge;
    public int toEdge;


    // constructor
    public OverworldNode(nodeType type)
    {
        this._nodeType = type;

        // TODO randomize encounter  sheet choice here



        this._encounterSheet = assignEncounter(_nodeType);
    }


    public static List<nodeType> FetchOverworldNodeTypes(int depth, int maxDepth)
    {

        if (depth == 0)
        {
            return new List<nodeType> { nodeType.START };
        }

        // Only boss on the last node
        if (depth == maxDepth - 1)
        {
            return new List<nodeType> { nodeType.BOSS };
        }

        // No elites on the first 3 nodes
        if (depth < 4)
        {

            return new List<nodeType> { nodeType.MOB, nodeType.EVENT };
        }

        // Only rest site before boss
        if (depth == maxDepth - 2)
        {
            return new List<nodeType> { nodeType.REST };
        }

        // else allow everything
        return new List<nodeType> { nodeType.ELITE, nodeType.EVENT, nodeType.MOB, nodeType.REST, nodeType.SHOP };
        //nodeType[] types = (nodeType[])System.Enum.GetValues(typeof(nodeType));
        //List<nodeType> list = new List<nodeType>(types);
        //return list;
    }

    public void attachEdges()
    {

    }

    public void LoadLevel()
    {
        if (_nodeType != nodeType.REST && _nodeType != nodeType.START)
        {
            EncounterState.NewEncounter(_encounterSheet);
        }
    }

    public EncounterSheet assignEncounter(nodeType type)
    {
        switch (type)
        {
            case nodeType.MOB:
                return EncounterSheet.AllEncounters.RandomChoice();
            case nodeType.SHOP:
                return EncounterSheet.AllEncounters.RandomChoice();
            case nodeType.ELITE:
                return EncounterSheet.AllEncounters.RandomChoice();
            case nodeType.BOSS:
                return EncounterSheet.AllEncounters.RandomChoice();
            case nodeType.EVENT:
                return EncounterSheet.AllEncounters.RandomChoice();
            default:
                return null;
        }
    }
}
