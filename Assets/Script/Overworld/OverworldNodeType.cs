using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Match3.Overworld
{
    public enum OverworldNodeType : int
    {
        START = -1,
        SHORE = 0,
        SEA = 1,
        TOWN = 2,
        FOREST = 3,
        RUINS = 4,
        BOSS = 5
    };


    public static class NodeTypeHelper
    {
        public static int Count(this OverworldNodeType self)
        {
            return 6;
        }

        public static Sprite GetSprite(this OverworldNodeType self)
        {
            switch (self)
            {
                case OverworldNodeType.START:
                    return Resources.Load<Sprite>("ui/node/start");
                case OverworldNodeType.SHORE:
                    return Resources.Load<Sprite>("ui/node/shore");
                case OverworldNodeType.SEA:
                    return Resources.Load<Sprite>("ui/node/sea");
                case OverworldNodeType.TOWN:
                    return Resources.Load<Sprite>("ui/node/town");
                case OverworldNodeType.FOREST:
                    return Resources.Load<Sprite>("ui/node/forest");
                case OverworldNodeType.RUINS:
                    return Resources.Load<Sprite>("ui/node/ruins");
                case OverworldNodeType.BOSS:
                    return Resources.Load<Sprite>("ui/node/boss");
            }

            return null;
        }

        public static int AsInt(this OverworldNodeType self)
        {
            return (int)self;
        }
    }
}