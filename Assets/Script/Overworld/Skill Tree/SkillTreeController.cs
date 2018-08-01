using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Overworld
{
    public class SkillTreeController : MonoBehaviour
    {
        [SerializeField]
        private RectTransform linePrefab;

        [SerializeField]
        private Transform lineContainer;
        
        private List<SkillItemController> nodes = new List<SkillItemController>();

        private List<string> list_1 = new List<string>()
        {
            "Warrior",
            "Warrior",
            "Warrior",

            "Scholar",
            "Scholar",
            "Scholar",

            "Jester",
            "Jester",
            "Jester",

            "Nobleman",
            "Nobleman",
            "Nobleman",

            "Shaman",
            "Shaman",
        };

        private List<string> list_2 = new List<string>()
        {
            "Berserker",
            "Captain",
            "Beastmaster",

            "Necromancer",
            "Shaman",
            "Pyromanic",

            "Pyromanic",
            "Berserker",
            "Beastmaster",

            "Beastmaster",
            "Captain",
            "Shaman",

            "Beastmaster",
            "Necromancer",
        };

        public void RegisterNode(SkillItemController node)
        {
            this.nodes.Add(node);
            foreach (SkillItemController other in nodes)
            {
                for (int i = 0; i < list_1.Count; i++)
                {
                    if (list_1[i] == node.trophy.name && list_2[i] == other.trophy.name ||
                        list_2[i] == node.trophy.name && list_1[i] == other.trophy.name)
                            this.DrawLine(node.transform, other.transform);
                }
            }
        }

        private void DrawLine(Transform item0, Transform item1)
        {
            RectTransform line = Instantiate<RectTransform>(linePrefab, this.lineContainer);
            line.PositionFrom(item0.position, item1.position);
        }
    }
}