using System;
using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for RectTransforms
/// </summary>
public static class RectTransformExt
{
    /// <summary>
    /// Checks whether an inner rect transform is fully contained within an outer rect transform
    /// </summary>
    /// <param name="outer">outer rect</param>
    /// <param name="inner">inner rect</param>
    /// <returns>whether inner is fully contained within outer</returns>
    public static bool FullyContains(this RectTransform outer, RectTransform inner)
    {
        var innerCorners = new Il2CppStructArray<Vector3>(4);
        var outerCorners = new Il2CppStructArray<Vector3>(4);

        inner.GetWorldCorners(innerCorners);
        outer.GetWorldCorners(outerCorners);

        var outerMin = outerCorners[0];
        var outerMax = outerCorners[2];

        for (var i = 0; i < 4; i++)
        {
            var corner = innerCorners[i];
            if (corner.x < outerMin.x ||
                corner.x > outerMax.x ||
                corner.y < outerMin.y ||
                corner.y > outerMax.y)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Checks whether a rect overlaps with another rect
    /// </summary>
    /// <param name="a">rect</param>
    /// <param name="b">rect</param>
    /// <returns>whether rects overlap</returns>
    public static bool OverlapsWith(this RectTransform a, RectTransform b)
    {
        var aCorners = new Il2CppStructArray<Vector3>(4);
        var bCorners = new Il2CppStructArray<Vector3>(4);

        a.GetWorldCorners(aCorners);
        b.GetWorldCorners(bCorners);

        var aRect = new Rect(aCorners[0], aCorners[2] - aCorners[0]);
        var bRect = new Rect(bCorners[0], bCorners[2] - bCorners[0]);

        return aRect.Overlaps(bRect);
    }

    /// <see href="https://docs.unity3d.com/ScriptReference/RectTransformUtility.RectangleContainsScreenPoint.html"/>
    public static bool ContainsScreenPoint(this RectTransform rect, Vector2 screenPoint) =>
        RectTransformUtility.RectangleContainsScreenPoint(rect, screenPoint);

    /// <see href="https://docs.unity3d.com/ScriptReference/RectTransformUtility.ScreenPointToLocalPointInRectangle.html"/>
    public static Vector2 ScreenPointToLocalPoint(this RectTransform rect, Vector2 screenPoint)
    {
        Vector2 result;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPoint, null, out result);
        return result;
    }

    /// <summary>
    /// Gets the mouse position as a local position within this rectangle
    /// </summary>
    /// <param name="rect">this</param>
    /// <param name="clamp">whether to clamp the position to within the bounds of this rect</param>
    /// <returns></returns>
    public static Vector2 MousePositionLocal(this RectTransform rect, bool clamp = false)
    {
        var mousePos = rect.ScreenPointToLocalPoint(Input.mousePosition);
        if (clamp)
        {
            mousePos.x = Math.Clamp(mousePos.x, rect.rect.xMin, rect.rect.xMax);
            mousePos.y = Math.Clamp(mousePos.y, rect.rect.yMin, rect.rect.yMax);
        }
        return mousePos;
    }
}