using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Encounter.Encounter;
using UnityEngine.SceneManagement;
using Match3.Encounter;

public class OverworldMap
 {
    
    public OverworldNode[,] levelMap;
    public int depth { get; private set; }   
    public int width;
    public int levelIndex;

    public OverworldMap(int depth = 10, int width = 7, int branches = 4)
    {
       
        bool generateSuccessful = this.GenerateLevelMap(depth, width);

        if (!generateSuccessful)
        {
            throw new System.Exception("Failed to fetch map");
        }

        this.generateEdges(branches);
    }

    public bool GenerateLevelMap(int depth = 10, int width = 7)
    {


        // conventions
        // index 0 is always the start, we mark as special ENUM START
        // index depth is always the boss
        // the numbers are real world numbers without offsetting.
        // floor 1(encounter 1) = index 1
        int maxDepth = depth + 1;
        OverworldNode[,] levelMap = new OverworldNode[maxDepth, width];


        for (int i = 0; i < maxDepth; i++)
        {
            List<OverworldNode.nodeType> overWorldNodeTypes = OverworldNode.FetchOverworldNodeTypes(i, maxDepth);
            for (int j = 0; j < width; j++)
            {
                levelMap[i, j] = new OverworldNode(overWorldNodeTypes.RandomChoice());
            }
        }



        /* 
        // test function
        for (int i = 0; i < maxDepth; i++)
        {
            for (int j = 1; j < width; j++)
            {
                Debug.Log("Level " + i  + "," +  j + "  :  " + levelMap[i, j]);
            }
        }
        */

        this.levelMap = levelMap;
        this.depth = depth;
        this.width = width;
        return true;
    }
    
    public void generateEdges(int branches = 4)
    {
        if (this.levelMap == null)
        {
            throw new System.Exception("Level map is not generated");
        }

        // define starting points
        int divider = (int)Mathf.Ceil(this.width / (float)branches);
        int[] startingPoints = new int[branches];

        for (int i =0; i < branches; i++)
        {
            startingPoints[i] = (0 + (i * divider));
            //Debug.Log("Starting point is " + startingPoints[i]);
        }

        // generate edges lazily
        for (int i = 0; i < branches; i++)
        {
            
        }
    }

    public void incrementLevel()
    {
        this.levelIndex += 1;
    }
}

