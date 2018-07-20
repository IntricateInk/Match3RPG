﻿using Match3.Encounter;
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

    // map setting configs
    [SerializeField]
    private int mapWidth;
    [SerializeField]
    private int mapDepth;
    [SerializeField]
    private int branches;

    [SerializeField]
    private GameObject buttonPrefab;
    [SerializeField]
    private GameObject mapParent;
    
    private int levelIndex;



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




    public OverworldMap createOverworld()
    {


        OverworldMap map = new OverworldMap(this.mapDepth, this.mapWidth, this.branches);


        // show map, might need to move to a different function
        if (buttonPrefab == null || mapParent == null)
        {
            throw new System.Exception("No prefab attached, pleae attach prefab to OverWorldManager script");
        }



        for (int i = 0; i < map.depth + 1; i++)
        {
            for (int j = 0; j < map.width; j++)
            {
                int i0 = i;
                int j0 = j;
                Button button = Instantiate<GameObject>(buttonPrefab, mapParent.transform).GetComponent<Button>();
                button.GetComponentInChildren<Text>().text = map.levelMap[i, j]._nodeType.ToString();
                button.onClick.AddListener(() => this.loadLevel(i0, j0));
            }
        }
        
        return map;
    }

   

    public void loadLevel(int i,  int j)
    {
        Debug.Log(i + " , " +j);
        _map.levelMap[i, j].LoadLevel();
    }
    

}


