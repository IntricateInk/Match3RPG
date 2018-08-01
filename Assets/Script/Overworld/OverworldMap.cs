using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Encounter.Encounter;
using UnityEngine.SceneManagement;
using Match3.Encounter;
using System;

public class OverworldMap
 {
    
    public OverworldNode[,] levelMap;
    public int sizeX { get { return levelMap.GetLength(0); } }
    public int sizeY { get { return levelMap.GetLength(1); } }

    public int playerX { get; private set; }
    public int playerY { get; private set; }

    public OverworldMap(int depth = 10, int width = 7, int branches = 4)
    {
       
        bool generateSuccessful = this.GenerateLevelMap(depth, width);

        if (!generateSuccessful)
        {
            throw new System.Exception("Failed to fetch map");
        }

        this.generateEdges(branches);
        this.playerX = 0;
        this.playerY = -99;

    }

    #region HELPER

    public List<OverworldNode> GetNextNodes(int nx, int ny)
    {
        List<OverworldNode> next = new List<OverworldNode>();
        int x = nx + 1;

        if (x >= sizeX) return next;
        
        if (nx == 0)
        {
            for (int y = 0; y < this.sizeY; y++)
            {
                OverworldNode node = this.levelMap[x, y];

                if (node != null && node.isInPath) next.Add(node);
            }
        }
        else
        {
            for (int y = Math.Max(0, ny - 1); y <= ny + 1; y++)
            {
                if (y >= this.sizeY) break;

                OverworldNode node = this.levelMap[x, y];

                if (node != null && node.isInPath) next.Add(node);
            }
        }

        return next;
    }
    #endregion HELPER


    public bool GenerateLevelMap(int depth = 10, int width = 7)
    {
        // conventions
        // index 0 is always the start, we mark as special ENUM START
        // index depth is always the boss
        // the numbers are real world numbers without offsetting.
        // floor 1(encounter 1) = index 1
        int maxDepth = depth + 1;
        this.levelMap = new OverworldNode[maxDepth, width];


        for (int i = 0; i < maxDepth; i++)
        {
            List<OverworldNode.nodeType> overWorldNodeTypes = OverworldNode.FetchOverworldNodeTypes(i, maxDepth);
            for (int j = 0; j < width; j++)
            {
                levelMap[i, j] = new OverworldNode(this, overWorldNodeTypes.RandomChoice(), i, j);
            }
        }

        return true;
    }
    
    public void generateEdges(int branches = 4)
    {
        if (this.levelMap == null)
        {
            throw new System.Exception("Level map is not generated");
        }

        // define starting points
        int divider = (int)Mathf.Ceil(this.sizeY / (float)branches);
        Vector2Int[,] pathsMatrix = new Vector2Int[sizeX, branches];

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

            for (int j = 0; j < this.sizeX; j++)
            {
                int prevPoint = candidatePoint;
                int rand = UnityEngine.Random.Range(-1, 2);
                candidatePoint = candidatePoint + rand;
                if (candidatePoint < 0)
                {
                    candidatePoint = 0;
                }
                else if (candidatePoint >= this.sizeY)
                {
                    candidatePoint = this.sizeY - 1;
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

    internal void LoadLevel(int i, int j)
    {
        this.playerX = i;
        this.playerY = j;
        this.levelMap[i, j].LoadLevel();
    }
}

