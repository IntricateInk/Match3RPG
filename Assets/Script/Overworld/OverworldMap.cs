using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match3.Encounter.Encounter;
using UnityEngine.SceneManagement;
using Match3.Encounter;

public class OverworldMap : MonoBehaviour
 {

    public List<OverworldNode> nodeList = null;
    public GameObject loadingImage;
    public GameObject nodePrefab;

    public OverworldMap()
    {
        
    }

    // let's just agree to use the real level index on the for loops here
    // remember to offset by -1
    public bool generateLevel()
    {
        try
        {
            if (this.nodeList == null)
            {
                this.nodeList = new List<OverworldNode>();
            }

            for (int i = 0; i < 3; i++)
            {
                OverworldNode node = new OverworldNode(OverworldNode.nodeType.MOB);
                this.nodeList.Add(node);
            }

            for (int i = 3; i < 6; i++)
            {
                OverworldNode node = new OverworldNode(OverworldNode.nodeType.MOB);
                this.nodeList.Add(node);
            }

            for (int i = 6; i < 10; i++)
            {
                OverworldNode node = new OverworldNode(OverworldNode.nodeType.MOB);
                this.nodeList.Add(node);
            }

            // for the 10th level, add a boss stage
            this.nodeList.Add(new OverworldNode(OverworldNode.nodeType.BOSS));

            /*
            for (int i = 0; i < nodeList.Count; i++)
            {
                Debug.Log("Nodelist #" + i + " is "  + this.nodeList[i]._nodeType);

            }
            */
            
            return true;

        } catch (System.Exception e)
        {
            Debug.Log("ERROR" + e);
            return false;
        }
       
    }

    void isOnLevel(int level)
    {
        for (int i = 0; i < nodeList.Count; i++)
        {
               
        }
    }

    public OverworldNode.nodeType[,] GenerateLevelMap(int depth = 10, int width = 7, int branches = 4)
    {
        
        OverworldNode.nodeType[,] levelMap = new OverworldNode.nodeType[depth, width];

        
        for (int i = 1; i < depth - 1; i++)
        {
            List<OverworldNode.nodeType> overWorldNodeTypes = OverworldNode.FetchOverworldNodeTypes(i, depth);
            for (int j = 1; j < depth; j++)
            {
                levelMap[i, j] = overWorldNodeTypes.RandomChoice();


            }
        }


        // last one is a boss
        levelMap[depth, 2] = OverworldNode.nodeType.BOSS;
        return levelMap;
    }

    public List
}

