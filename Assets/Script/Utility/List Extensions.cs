using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions {
    
    public static void Shuffle<T>(this List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int idx = Random.Range(i, list.Count);
            T e = list[idx];
            list.RemoveAt(idx);
            list.Insert(i, e);
        }
    }

    public static T RandomChoice<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static IEnumerable<T> RandomChoice<T>(this List<T> list, int n)
    {
        List<T> cpy = new List<T>(list);

        while (n > 0)
        {
            T item = cpy.RandomChoice();
            cpy.Remove(item);
            yield return item;
            n--;
        }
        yield break;
    }
}
