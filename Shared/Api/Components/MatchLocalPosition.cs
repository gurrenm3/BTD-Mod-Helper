using System;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// Component to make this transform continuously match the position of another transform
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class MatchLocalPosition : MonoBehaviour
{
    /// <summary>
    /// Other transform to constantly copy the scale from
    /// </summary>
    public Transform transformToCopy;

    /// <summary>
    /// Offset from the transform to stay
    /// </summary>
    public Vector3 offset;
        
    /// <summary>
    /// Scale for the original local position
    /// </summary>
    public Vector3 scale = Vector3.one;

    /// <inheritdoc />
    public MatchLocalPosition(IntPtr ptr) : base(ptr)
    {
    }

    private void LateUpdate()
    {
        var copy = transformToCopy.localPosition;
        transform.localPosition = new Vector3(copy.x * scale.x + offset.x, copy.y * scale.y + offset.y,
            copy.z * scale.z + offset.z);
    }
}