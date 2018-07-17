using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class RandomUtil {
    
    public static List<int> TakeRandomN(int lower, int upper, int n)
    {
        return Enumerable.Range(lower, upper - lower).OrderBy(x => Random.Range(0f, 1f)).Take(n).ToList();
    }
}
