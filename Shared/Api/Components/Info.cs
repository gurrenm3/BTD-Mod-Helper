using UnityEngine;
#pragma warning disable CS1573

namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// Struct used to represent the name, position and size information of a ModHelperComponent
/// </summary>
public readonly struct Info
{
    private readonly Vector2 position;
    private readonly Vector2 sizeDelta;
    private readonly Vector2 anchorMin;
    private readonly Vector2 anchorMax;
    private readonly Vector2 pivot;

    #region Properties

    /// <summary>
    /// The name of the ModHelperComponent's Unity GameObject
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The localPosition field, by default relative to the parent's center unless anchors are changed
    /// </summary>
    public Vector2 Position
    {
        get => position;
        init => position = value;
    }

    /// <summary>
    /// The localPosition x field, by default relative to the parent's center unless anchors are changed
    /// </summary>
    public float X
    {
        get => position.x;
        init => position.x = value;
    }

    /// <summary>
    /// The localPosition y field, by default relative to the parent's center unless anchors are changed
    /// </summary>
    public float Y
    {
        get => position.y;
        init => position.y = value;
    }

    /// <summary>
    /// The sizeDelta field. This technically is how much the size should change compared to (anchorMax - anchorMin)
    /// </summary>
    public Vector2 SizeDelta
    {
        get => sizeDelta;
        init => sizeDelta = value;
    }

    /// <summary>
    /// Sets both the width and the height to be a certain value
    /// </summary>
    public float Size
    {
        init => sizeDelta = new Vector2(value, value);
    }

    /// <summary>
    /// The sizeDelta x field. This technically is how much the width should change compared to (anchorMax.x - anchorMin.x)
    /// </summary>
    public float Width
    {
        get => sizeDelta.x;
        init => sizeDelta.x = value;
    }

    /// <summary>
    /// The sizeDelta y field. This technically is how much the width should change compared to (anchorMax.x - anchorMin.x)
    /// </summary>
    public float Height
    {
        get => sizeDelta.y;
        init => sizeDelta.y = value;
    }

    /// <summary>
    /// If this is part of a layout group, then the relative flexible width of this component.
    /// </summary>
    public int FlexWidth { get; init; }

    /// <summary>
    /// If this is part of a layout group, then the relative flexible height of this component.
    /// </summary>
    public int FlexHeight { get; init; }

    /// <summary>
    /// Sets both FlexWidth and FlexHeight to be a certain value
    /// </summary>
    public int Flex
    {
        init => FlexWidth = FlexHeight = value;
    }

    /// <summary>
    /// The lower anchor. (0, 0) is the parent's lower left while (1,1) is the parent's upper right. Default (0.5, 0.5)
    /// </summary>
    public Vector2 AnchorMin
    {
        get => anchorMin;
        init => anchorMin = value;
    }

    /// <summary>
    /// Sets the X coordinate of the AnchorMin to be the specified value, leaving the Y coordinate unchanged (0.5)
    /// </summary>
    public float AnchorMinX
    {
        get => anchorMin.x;
        init => anchorMin.x = value;
    }

    /// <summary>
    /// Sets the Y coordinate of the AnchorMin to be the specified value, leaving the X coordinate unchanged (0.5)
    /// </summary>
    public float AnchorMinY
    {
        get => anchorMin.y;
        init => anchorMin.y = value;
    }

    /// <summary>
    /// The upper anchor. (0, 0) is the parent's lower left while (1,1) is the parent's upper right. Default (0.5, 0.5)
    /// </summary>
    public Vector2 AnchorMax
    {
        get => anchorMax;
        init => anchorMax = value;
    }


    /// <summary>
    /// Sets the X coordinate of the AnchorMax to be the specified value, leaving the Y coordinate unchanged (0.5)
    /// </summary>
    public float AnchorMaxX
    {
        get => anchorMax.x;
        init => anchorMax.x = value;
    }

    /// <summary>
    /// Sets the Y coordinate of the AnchorMax to be the specified value, leaving the X coordinate unchanged (0.5)
    /// </summary>
    public float AnchorMaxY
    {
        get => anchorMax.y;
        init => anchorMax.y = value;
    }

    /// <summary>
    /// Sets both AnchorMin and AnchorMax to the given value
    /// </summary>
    public Vector2 Anchor
    {
        init => AnchorMin = AnchorMax = value;
    }

    /// <summary>
    /// The local scale field to initialize width
    /// </summary>
    public Vector3 Scale { get; init; }

    /// <summary>
    /// The point between (0, 0) and (1, 1) that this object rotates around and expands out from, by default (0.5, 0.5)
    /// </summary>
    public Vector2 Pivot
    {
        get => pivot;
        init => pivot = value;
    }

    /// <summary>
    /// The x component of the pivot
    /// </summary>
    public float PivotX
    {
        get => pivot.x;
        init => pivot.x = value;
    }

    /// <summary>
    /// The y component of the pivot
    /// </summary>
    public float PivotY
    {
        get => pivot.y;
        init => pivot.y = value;
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Creates a new info struct representing the name, position and size of a ModHelperComponent
    /// <param name="name">The name of the ModHelperComponent's Unity GameObject</param>
    /// </summary>
    public Info(string name)
    {
        Name = name;
        position = new Vector2(0, 0);
        sizeDelta = new Vector2(0, 0);
        FlexWidth = 0;
        FlexHeight = 0;
        anchorMin = new Vector2(0.5f, 0.5f);
        anchorMax = new Vector2(0.5f, 0.5f);
        Scale = Vector3.one;
        pivot = new Vector2(0.5f, 0.5f);
    }

    /// <inheritdoc cref="Info(string)"/>
    /// <param name="width">The sizeDelta x field. This technically is how much the width should change compared to (anchorMax.x - anchorMin.x)</param>
    /// <param name="height">The sizeDelta x field. This technically is how much the width should change compared to (anchorMax.x - anchorMin.x)</param>
    public Info(string name, float width, float height) : this(name)
    {
        Width = width;
        Height = height;
    }


    /// <inheritdoc cref="Info(string)"/>
    /// <param name="size">Sets both the width and the height to be this value</param>
    public Info(string name, float size) : this(name)
    {
        Size = size;
    }

    /// <inheritdoc cref="Info(string, float)"/>
    /// <param name="x">The localPosition x field, by default relative to the parent's center unless anchors are changed</param>
    /// <param name="y">The localPosition y field, by default relative to the parent's center unless anchors are changed</param>
    public Info(string name, float x, float y, float size) : this(name, size)
    {
        X = x;
        Y = y;
    }

    /// <inheritdoc cref="Info(string, float, float)"/>
    /// <param name="x">The localPosition x field, by default relative to the parent's center unless anchors are changed</param>
    /// <param name="y">The localPosition y field, by default relative to the parent's center unless anchors are changed</param>
    public Info(string name, float x, float y, float width, float height) : this(name, width, height)
    {
        X = x;
        Y = y;
    }

    /// <inheritdoc cref="Info(string, float, float, float, float)"/>
    /// <param name="anchor">Sets both anchorX and anchorY to this value</param>
    public Info(string name, float x, float y, float width, float height, Vector2 anchor) : this(name, x, y, width,
        height)
    {
        Anchor = anchor;
    }

    /// <inheritdoc cref="Info(string, float, float, float)"/>
    /// <param name="anchor">Sets both anchorX and anchorY to this value</param>
    public Info(string name, float x, float y, float size, Vector2 anchor) : this(name, x, y, size, size, anchor)
    {
    }

    /// <inheritdoc cref="Info(string, float, float)"/>
    /// <param name="anchor">Sets both anchorX and anchorY to this value</param>
    public Info(string name, float width, float height, Vector2 anchor) : this(name, width, height)
    {
        Anchor = anchor;
    }

    /// <inheritdoc cref="Info(string, float, float, float, float, Vector2)"/>
    /// <param name="pivot">The point between (0, 0) and (1, 1) that this object rotates around and expands out from, by default (0.5, 0.5)</param>
    public Info(string name, float x, float y, float width, float height, Vector2 anchor, Vector2 pivot) : this(name, x,
        y, width, height, anchor)
    {
        Pivot = pivot;
    }

    /// <summary>
    /// Creates a new info struct representing the name, position and size of a ModHelperComponent
    /// </summary>
    /// <param name="name">The name of the ModHelperComponent's Unity GameObject</param>
    /// <param name="preset">A preset to apply</param>
    public Info(string name, InfoPreset preset) : this(name)
    {
        switch (preset)
        {
            case InfoPreset.FillParent:
                AnchorMin = Vector2.zero;
                AnchorMax = Vector2.one;
                break;
            case InfoPreset.Flex:
                Flex = 1;
                break;
        }
    }

    #endregion

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
    public Info Duplicate(string name) => new(name)
    {
        Position = position,
        SizeDelta = sizeDelta,
        Pivot = Pivot,
        AnchorMin = AnchorMin,
        AnchorMax = AnchorMax,
        FlexWidth = FlexWidth,
        FlexHeight = FlexHeight,
        Scale = Scale
    };
}

/// <summary>
/// Specific common preset setups of Info structs
/// </summary>
public enum InfoPreset
{
    /// <summary>
    /// Will fill its parent component by matching its top left and bottom right with the parent's
    /// <br/>
    /// Equivalent to
    /// <code>
    /// {
    ///     AnchorMin = new Vector2(0, 0),
    ///     AnchorMax = new Vector2(1, 1)
    /// }
    /// </code>
    /// Set alongside negative width/height to add padding around the edges, or positive to expand beyond
    /// </summary>
    FillParent,

    /// <summary>
    /// Will fully flex horizontally and vertically,
    /// <br/>
    /// Equivalent to
    /// <code>
    /// {
    ///     FlexWidth = 1,
    ///     FlexHeight = 1
    /// }
    /// </code>
    /// </summary>
    Flex
}