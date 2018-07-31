using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Encounter.Encounter;
using Match3.Encounter;

public class OverworldNode
{


    public EncounterSheet _encounterSheet { get; private set; } // encounter data sheet
    public EventSheet _eventSheet { get; private set; } // event data sheet
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

    public bool isInPath = false;
        private int prevNode;
    private int xIndex; // public?
    private int yIndex; // public?

    public int fromEdge;
    public int toEdge;


    // constructor
    public OverworldNode(nodeType type)
    {
        this._nodeType = type;

        // TODO randomize encounter  sheet choice here

        assignEncounter(_nodeType);
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

    public void attachEdges(int prevNode)
    {
        this.prevNode = prevNode;
        this.isInPath = true;
    }

    public void LoadLevel()
    {
        switch(_nodeType)
        {
            case nodeType.REST:
                break;
            case nodeType.EVENT:
                EventManager.NewEvent(this._eventSheet);
                break;
            case nodeType.SHOP:
                break;
            default: // MOB ELITE BOSS
                EncounterState.NewEncounter(this._encounterSheet);
                break;
        }
    }

    

    public void assignEncounter(nodeType type)
    {
        switch (type)
        {
            case nodeType.MOB:
                this._encounterSheet = EncounterSheet.AllEncounters.RandomChoice();
                return;
            case nodeType.SHOP:
                EncounterSheet.AllEncounters.RandomChoice();
                return;
            case nodeType.ELITE:
                EncounterSheet.AllEncounters.RandomChoice();
                return;
            case nodeType.BOSS:
                EncounterSheet.AllEncounters.RandomChoice();
                return;
            case nodeType.EVENT:
                this._eventSheet = EventSheet.AllEvents.RandomChoice();
                return;
            default:
                return;
        }
    }
}
