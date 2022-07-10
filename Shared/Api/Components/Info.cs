using UnityEngine;

namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// Struct used to represent the name, position and size information of a ModHelperComponent
/// </summary>
public readonly struct Info
{
    /// <summary>
    /// The name of the ModHelperComponent's Unity GameObject
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The localPosition field, by default relative to the parent's center unless anchors are changed
    /// </summary>
    public Vector2 Position { get; }

    /// <summary>
    /// The sizeDelta field. This technically is how much the size should change compared to (anchorMax - anchorMin)
    /// </summary>
    public Vector2 SizeDelta { get; }

    /// <summary>
    /// If this is part of a layout group, then the relative flexible width of this component.
    /// </summary>
    public int FlexWidth { get; }

    /// <summary>
    /// If this is part of a layout group, then the relative flexible height of this component.
    /// </summary>
    public int FlexHeight { get; }

    /// <summary>
    /// The lower anchor. (0, 0) is the parent's lower left while (1,1) is the parent's upper right
    /// </summary>
    public Vector2 AnchorMin { get; }

    /// <summary>
    /// The upper anchor. (0, 0) is the parent's lower left while (1,1) is the parent's upper right
    /// </summary>
    public Vector2 AnchorMax { get; }

    /// <summary>
    /// The local scale field to initialize width
    /// </summary>
    public Vector3 Scale { get; }

    /// <summary>
    /// The point between (0, 0) and (1, 1) that this object rotates around
    /// </summary>
    public Vector2 Pivot { get; }

    /// <summary>
    /// The localPosition x field, by default relative to the parent's center unless anchors are changed
    /// </summary>
    public float X => Position.x;

    /// <summary>
    /// The localPosition y field, by default relative to the parent's center unless anchors are changed
    /// </summary>
    public float Y => Position.y;

    /// <summary>
    /// The sizeDelta x field. This technically is how much the width should change compared to (anchorMax.x - anchorMin.x)
    /// </summary>
    public float Width => SizeDelta.x;

    /// <summary>
    /// The sizeDelta x field. This technically is how much the width should change compared to (anchorMax.x - anchorMin.x)
    /// </summary>
    public float Height => SizeDelta.y;


    /// <summary>
    /// Creates a new info struct representing the name, position and size of a ModHelperComponent
    /// </summary>
    /// <param name="name">The name of the ModHelperComponent's Unity GameObject</param>
    /// <param name="x">The localPosition x field, by default relative to the parent's center unless anchors are changed</param>
    /// <param name="y">The localPosition y field, by default relative to the parent's center unless anchors are changed</param>
    /// <param name="width">The sizeDelta x field. This technically is how much the width should change compared to (anchorMax.x - anchorMin.x)</param>
    /// <param name="height">The sizeDelta x field. This technically is how much the width should change compared to (anchorMax.x - anchorMin.x)</param>
    /// <param name="flexWidth">If this is part of a layout group, then the relative flexible width of this component.</param>
    /// <param name="flexHeight">If this is part of a layout group, then the relative flexible height of this component.</param>
    /// <param name="anchorMin">The lower anchor. (0, 0) is the parent's lower left while (1,1) is the parent's upper right</param>
    /// <param name="anchorMax">The upper anchor. (0, 0) is the parent's lower left while (1,1) is the parent's upper right</param>
    /// <param name="scale">The local scale field to initialize width</param>
    /// <param name="pivot">The point between (0, 0) and (1, 1) that this object rotates around</param>
    /// <param name="anchor">Sets both anchorMin and anchorMax to be this value</param>
    /// <param name="flex">Sets both flexWidth and flexHeight to be this value</param>
    /// <param name="size">Sets both width and height to be this value</param>
    public Info(string name, float x = 0f, float y = 0f, float width = 0f, float height = 0f, int flexWidth = -1,
        int flexHeight = -1, Vector2? anchorMin = null, Vector2? anchorMax = null, Vector3? scale = null,
        Vector2? pivot = null, Vector2? anchor = null, int? flex = null, float? size = null)
    {
        Name = name;
        Position = new Vector2(x, y);
        SizeDelta = new Vector2(size ?? width, size ?? height);
        FlexWidth = flex ?? flexWidth;
        FlexHeight = flex ?? flexHeight;
        AnchorMin = anchorMin ?? anchor ?? new Vector2(0.5f, 0.5f);
        AnchorMax = anchorMax ?? anchor ?? new Vector2(0.5f, 0.5f);
        Scale = scale ?? Vector3.one;
        Pivot = pivot ?? new Vector2(0.5f, 0.5f);
    }
        
    /// <summary>
    /// Sets the properties of the RectTransform based on this Info object
    /// </summary>
    public void Apply(RectTransform rectTransform)
    {
        rectTransform.anchorMax = AnchorMax;
        rectTransform.anchorMin = AnchorMin;
        rectTransform.localScale = Scale;
        rectTransform.sizeDelta = SizeDelta;
        rectTransform.localPosition = Position;
        rectTransform.anchoredPosition = Position;
        rectTransform.pivot = Pivot;
    }

    /// <summary>
    /// Creates a new Info with all the same properties as this
    /// </summary>
    public Info Duplicate(string name)
    {
        return new Info(name, Position.x, Position.y, SizeDelta.x, SizeDelta.y, FlexWidth, FlexHeight, AnchorMin,
            AnchorMax, Scale, Pivot);
    }
}