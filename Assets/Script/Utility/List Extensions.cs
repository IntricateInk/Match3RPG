using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions {
    
    public static T[] Flatten<T>(this T[,] array)
    {
        int d0 = array.GetLength(0);
        int d1 = array.GetLength(1);
        T[] tmp = new T[d0 * d1];

        for (int i = 0; i < d0 * d1; i++)
        {
            tmp[i] = array[i % d1, i / d1];
        }

        return tmp;
    }

    public static void Shuffle<T>(this List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int idx = UnityEngine.Random.Range(i, list.Count);
            T e = list[idx];
            list.RemoveAt(idx);
            list.Insert(i, e);
        }
    }

    public static T RandomChoice<T>(this List<T> list)
    {
        return list[UnityEngine.Random.Range(0, list.Count)];
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
