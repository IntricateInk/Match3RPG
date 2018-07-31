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

    public Vector2Int playerPosition;

    public OverworldMap(int depth = 10, int width = 7, int branches = 4)
    {
       
        bool generateSuccessful = this.GenerateLevelMap(depth, width);

        if (!generateSuccessful)
        {
            throw new System.Exception("Failed to fetch map");
        }

        this.generateEdges(branches);
        this.playerPosition = new Vector2Int(2, 4);
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
        this.depth = maxDepth;
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
        Vector2Int[,] pathsMatrix = new Vector2Int[depth, branches];

        for (int i = 0; i < branches; i++)
        {
            pathsMatrix[0, i] = new Vector2Int(0 + (i * divider), 0);
            //Debug.Log("Starting point is " + pathsMatrix[0, i]);
        }

        // generate edges lazily
        for (int i = 0; i < branches; i++)
        {
            int candidatePoint = pathsMatrix[0, i].x; // y = .25 , .5, .75 and 1 of width
            //Debug.Log("candidate point is =" + candidatePoint);

            for (int j = 0; j < this.depth; j++)
            {
                int prevPoint = candidatePoint;
                int rand = Random.Range(-1, 2);
                candidatePoint = candidatePoint + rand;
                if (candidatePoint < 0)
                {
                    candidatePoint = 0;
                }
                else if (candidatePoint >= this.width)
                {
                    candidatePoint = this.width - 1;
                }
                pathsMatrix[j, i] = new Vector2Int(prevPoint, candidatePoint); // Unity does not support tuple and I'm too lazy to use an arraylist
            }
        }

        // TODO Weave above and below for loops together.
        // mark nodes traversed and draw directions
        for (int i = 0; i < pathsMatrix.GetLength(0); i++)
        {
            //Debug.Log("Path number " + i);
            for (int j = 0; j < pathsMatrix.GetLength(1); j++)
            {

                Vector2Int nodeTarget = pathsMatrix[i, j];
                //Debug.Log("for int " + i + j + " prev is = " + nodeTarget.x + " next is " + nodeTarget.y);
                levelMap[i, nodeTarget.y].attachEdges(nodeTarget.x); // tell that the node is used in the path
                
            }
        }
    }
}

