using Match3.Encounter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverworldManager : MonoBehaviour
{
    // singleton access
    private static OverworldManager _instance;
    private static OverworldMap _map { get; set; }
    //public GameObject buttonPrefab;
    private int score;

    // constructor
    void Start()
    {
        if (_map == null)
        {
            _map = createOverworld();
        }
    }


    // singleton access
    public static OverworldManager Instance
    {
        get
        {
            if (_instance == null)
            {
               
            }
            return _instance;
        }
    }

    // to keep level data across scene changes
    void Awake()
    {
        //loadingImage.SetActive(false);
        //DontDestroyOnLoad(this.gameObject);
    }




    public static OverworldMap createOverworld()
    {
        OverworldMap map = new OverworldMap();
        bool isGenerateSuccessful = map.generateLevel();
        // show map

        if (isGenerateSuccessful)
        {
           
        }
        
        return map;
    }

   

    public void loadLevel(int index)
    {
        _map.nodeList[index].LoadLevel();
    }
    

}


