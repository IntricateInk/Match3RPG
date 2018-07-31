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

        // dynamically assign button size
        Vector2 rectTransformSize = mapParent.GetComponent<RectTransform>().sizeDelta;
        Vector2 buttonSize = new Vector2(rectTransformSize.x / map.width, rectTransformSize.y / map.depth);
        mapParent.GetComponent<GridLayoutGroup>().cellSize = buttonSize;
        


        for (int i = 0; i < map.depth; i++)
        {
            for (int j = 0; j < map.width; j++)
            {
                int i0 = i;
                int j0 = j;
                OverworldNode nodeInProcess = map.levelMap[i0, j0];
                Button button = Instantiate<GameObject>(buttonPrefab, mapParent.transform).GetComponent<Button>();
                
                if (nodeInProcess.isInPath)
                {
                    button.GetComponentInChildren<Text>().text = map.levelMap[i0, j0]._nodeType.ToString();
                    //buttonArray[i0, j0] = button;
                    // if at first floor depth
                    bool isFirstFloor = (map.playerPosition.x == 1 && i0 == 1);
                    bool isAdjascent = ((i0 == map.playerPosition.x + 1) && Mathf.Abs(map.playerPosition.y - j0) <= 1);
                    if (isFirstFloor || isAdjascent)
                    {
                        // highlight all
                        button.onClick.AddListener(() => this.loadLevel(button, i0, j0));
                        button.GetComponent<Image>().color = Color.green;
                        button.GetComponent<NodeButtonScript>().shouldBreathe = true;
                    }
                }
                else
                {
                    button.GetComponent<Image>().enabled = false;
                    button.GetComponentInChildren<Text>().text = null;
                    button.GetComponent<NodeButtonScript>().shouldBreathe = false;
                }

            }
            }
        
        return map;
    }



    public void loadLevel(Button self, int i, int j)
    {
        //Debug.Log(i + " , " +j);

        _map.levelMap[i, j].LoadLevel();
    }
    

}


