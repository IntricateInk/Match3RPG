﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Encounter.Encounter;
using Match3.Encounter;
using System.Linq;
using Match3.Events.core;
using Match3.Events.list;

namespace Match3.Overworld
{
    public class OverworldNode
    {

        public readonly OverworldNodeType nodeType;
        private bool obfuscated;

        public bool isInPath = false;
        public bool isTraversed = false;

        private int prevNode;

        public readonly int x;
        public readonly int y;

        public int fromEdge;
        public int toEdge;

        public readonly OverworldMap map;

        // constructor
        public OverworldNode(OverworldMap map, OverworldNodeType type, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.map = map;
            this.nodeType = type;
        }


        public static List<OverworldNodeType> FetchOverworldNodeTypes(int depth, int maxDepth)
        {
            if (depth == 0)
                return new List<OverworldNodeType> { OverworldNodeType.START };

            if (depth == maxDepth - 1)
                return new List<OverworldNodeType> { OverworldNodeType.BOSS };

            return new List<OverworldNodeType>
            {
                OverworldNodeType.FOREST,
                OverworldNodeType.SEA,
                OverworldNodeType.SHORE,
                OverworldNodeType.RUINS,
                OverworldNodeType.TOWN
            };
        }

        public void attachEdges(int prevNode)
        {
            this.prevNode = prevNode;
            this.isInPath = true;
        }

        public void LoadLevel()
        {

            IEnumerable<EncounterSheet> encounters = EncounterSheet.GetEncounters(this.x);
            IEnumerable<GameEvent> events = EventState._AllEvents;
            
            int encounter_total = encounters.Sum((e) => { return e.GetWeight(this.nodeType); });
            int event_total = events.Sum((e) => { return e.GetWeight(this.nodeType); });
            int roll = Random.Range(0, encounter_total + event_total);

            //Debug.Log("Event total = " + event_total);
            //Debug.Log("roll = " + roll);

            if (roll < event_total)
            {
                try
                {
                    //GameEvent selected = events[roll];
                    //GameEvent selected = events[0];
                    foreach (GameEvent selectedEvent in events)
                    {
                        int w = selectedEvent.GetWeight(this.nodeType);
                        if (roll < w)
                        {

                            EventState.NewEvent(selectedEvent);
                            return;
                        }
                    }
                } catch
                {
                    Debug.Log("Passing events because list out of range");
                }
                
            }

            roll -= event_total;

            if (roll < encounter_total)
            {
                foreach (EncounterSheet selected in encounters)
                {
                    int w = selected.GetWeight(this.nodeType);
                    if (roll < w)
                    {
                        EncounterState.NewEncounter(selected);
                        return;
                    }

                    roll -= w;
                }
            }
        }
    }
}