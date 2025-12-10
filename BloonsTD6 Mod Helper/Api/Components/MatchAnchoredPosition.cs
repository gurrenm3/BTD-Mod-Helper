using System;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// Component to make this transform continuously match the position of another transform
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class MatchAnchoredPosition : MonoBehaviour
{
    /// <summary>
    /// Other transform to constantly copy the scale from
    /// </summary>
    public RectTransform transformToCopy;

    /// <summary>
    /// Offset from the transform to stay
    /// </summary>
    public Vector2 offset;

    /// <summary>
    /// Scale for the original anchored position
    /// </summary>
    public Vector2 scale = Vector2.one;

    /// <inheritdoc />
    public MatchAnchoredPosition(IntPtr ptr) : base(ptr)
    {
    }

    private void LateUpdate()
    {
        var copy = transformToCopy.anchoredPosition;
        var rectTransform = transform.Cast<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(copy.x * scale.x + offset.x, copy.y * scale.y + offset.y);
    }
}