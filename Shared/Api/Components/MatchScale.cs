using System;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Helpers;

/// <summary>
/// Component to make this transform continuously match the scale of another transform
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class MatchScale : MonoBehaviour
{
    /// <summary>
    /// Other transform to constantly copy the scale from
    /// </summary>
    public Transform transformToCopy;

    /// <inheritdoc />
    public MatchScale(IntPtr ptr) : base(ptr)
    {
    }

    private void LateUpdate()
    {
        transform.localScale = transformToCopy.localScale;
    }
}