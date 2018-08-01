using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class RectTransformExtensions
{
    public static void PositionFrom(this RectTransform rt, Vector3 p0, Vector3 p1)
    {
        rt.transform.position = p0;
        rt.transform.rotation = Quaternion.FromToRotation(Vector3.right, p1 - p0);
        rt.sizeDelta = new Vector2((p0 - p1).magnitude, rt.sizeDelta.y);
    }

    public static void LocalPositionFrom(this RectTransform rt, Vector3 p0, Vector3 p1)
    {
        rt.transform.localPosition = p0;
        rt.transform.rotation = Quaternion.FromToRotation(Vector3.right, p1 - p0);
        rt.sizeDelta = new Vector2((p0 - p1).magnitude, rt.sizeDelta.y);
    }
}