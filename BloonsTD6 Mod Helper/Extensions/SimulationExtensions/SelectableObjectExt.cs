using Assets.Scripts.Simulation.Objects;
using UnityEngine;
using System.Linq;

namespace BTD_Mod_Helper.Extensions
{
    public static class SelectableObjectExt
    {
        public static SkinnedMeshRenderer GetSkinnedMeshRenderer(this SelectableObject selectableObject)
        {
            var renders = selectableObject.entity?.GetUnityDisplayNode()?.genericRenderers;
            return renders.FirstOrDefault(renderer => renderer.GetIl2CppType().Name == "SkinnedMeshRenderer").Cast<SkinnedMeshRenderer>();
        }
    }
}