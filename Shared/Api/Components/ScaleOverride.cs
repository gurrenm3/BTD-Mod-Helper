using System;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// Custom component to keep the scale of a transform permanently at 0, even if an Animator tries to change it
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ScaleOverride : MonoBehaviour
{
    /// <summary>
    /// The scale to set it to
    /// </summary>
    public Vector3 scale = Vector3.zero;
        
    /// <inheritdoc />
    public ScaleOverride(IntPtr ptr) : base(ptr)
    {
    }
        
    private void LateUpdate()
    {
        transform.localScale = scale;
    }
}