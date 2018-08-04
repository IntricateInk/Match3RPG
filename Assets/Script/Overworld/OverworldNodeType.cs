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

        public static int AsInt(this OverworldNodeType self)
        {
            return (int)self;
        }
    }
}