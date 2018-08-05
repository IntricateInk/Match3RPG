using Match3.Encounter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Match3.Overworld
{
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
        private Button buttonPrefab;
        [SerializeField]
        private RectTransform linePrefab;

        [SerializeField]
        private GameObject mapParent;
        [SerializeField]
        private Transform lineContainer;

        private int levelIndex;

        // constructor
        void Start()
        {
            if (_map == null) _map = createOverworld();

            ShowMap();
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
        
        public OverworldMap createOverworld()
        {
            return new OverworldMap(this.mapDepth, this.mapWidth, this.branches);
        }

        public void ShowMap()
        {
            OverworldMap map = _map;

            // show map, might need to move to a different function
            if (buttonPrefab == null || mapParent == null)
            {
                throw new System.Exception("No prefab attached, pleae attach prefab to OverWorldManager script");
            }

            // dynamically assign button size
            Vector2 size = mapParent.GetComponent<RectTransform>().sizeDelta;
            Vector2 buttonSize = new Vector2(size.x / map.sizeY, size.y / map.sizeX);

            List<OverworldNode> next = _map.GetNextNodes(_map.playerX, _map.playerY);

            for (int i = 0; i < map.sizeX; i++)
            {
                for (int j = 0; j < map.sizeY; j++)
                {
                    int i0 = i;
                    int j0 = j;
                    OverworldNode nodeInProcess = map.levelMap[i0, j0];
                    Button button = Instantiate<Button>(buttonPrefab, mapParent.transform);

                    Vector3 node_pos = GetButtonLocalPosition(nodeInProcess.x, nodeInProcess.y);
                    button.transform.localPosition = node_pos;

                    if (nodeInProcess.isInPath)
                    {
                        button.GetComponentInChildren<Image>().sprite = nodeInProcess.nodeType.GetSprite();

                        //buttonArray[i0, j0] = button;
                        // if at first floor depth
                        if (next.Contains(nodeInProcess))
                        {
                            // highlight all
                            button.onClick.AddListener(() => this.loadLevel(nodeInProcess));
                            button.GetComponent<Image>().color = Color.green;
                            button.GetComponent<NodeButtonScript>().shouldBreathe = true;
                        }

                        foreach (OverworldNode nextNode in map.GetNextNodes(nodeInProcess.x, nodeInProcess.y))
                        {
                            RectTransform rt = Instantiate<RectTransform>(linePrefab, lineContainer);
                            Vector3 next_pos = GetButtonLocalPosition(nextNode.x, nextNode.y);

                            rt.LocalPositionFrom(node_pos, next_pos);
                        }
                    }
                    else
                    {
                        button.gameObject.SetActive(false);
                    }

                }
            }
        }

        public Vector3 GetButtonLocalPosition(int x, int y)
        {
            Vector2 size = mapParent.GetComponent<RectTransform>().rect.size;
            return new Vector3(x * size.x / _map.sizeX, y * size.y / _map.sizeY);
        }

        public void loadLevel(OverworldNode node)
        {
            //Debug.Log(i + " , " +j);

            _map.LoadLevel(node.x, node.y);
        }
    }
}