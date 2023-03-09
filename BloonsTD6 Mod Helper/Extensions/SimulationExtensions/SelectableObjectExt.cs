using System.Linq;
using Il2CppAssets.Scripts.Simulation.Objects;
using UnityEngine;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Selectable Objects
/// </summary>
public static class SelectableObjectExt
{
    /// <summary>
    /// Gets the first SkinnedMeshRenderer of this object
    /// </summary>
    public static SkinnedMeshRenderer GetSkinnedMeshRenderer(this SelectableObject selectableObject)
    {
        var renders = selectableObject.entity?.GetUnityDisplayNode()?.genericRenderers;
        return renders?.FirstOrDefault(renderer => renderer.IsType<SkinnedMeshRenderer>())
            ?.Cast<SkinnedMeshRenderer>();
    }
}