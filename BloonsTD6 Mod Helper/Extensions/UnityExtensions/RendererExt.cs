using System;
using System.Collections.Generic;
using System.Linq;
using Il2CppInterop.Runtime;
using UnityEngine;
using UnityEngine.Rendering;
using Array = Il2CppSystem.Array;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for unity renderers
/// </summary>
public static partial class RendererExt
{
    /// <summary>
    /// Experimental method of messing with mesh renderers at runtime
    /// </summary>
    [Obsolete]
    public static void SetTriangles(this SkinnedMeshRenderer skinnedMeshRenderer, List<int[]> trianglesAsArrays)
    {
        skinnedMeshRenderer.SetTriangles(trianglesAsArrays.SelectMany(array => array.AsEnumerable()).ToList());
    }

    /// <summary>
    /// Experimental method of messing with mesh renderers at runtime
    /// </summary>
    [Obsolete]
    public static void SetTriangles(this SkinnedMeshRenderer skinnedMeshRenderer, List<int> triangles)
    {
        var length = triangles.Count;
        if (length % 3 != 0)
        {
            throw new ArgumentException("Triangles list must be all sets of 3");
        }
        var array = Array.CreateInstance(Il2CppType.Of<int>(), length);
        for (var i = 0; i < length; i++)
        {
            array.SetValue(triangles[i], i);
        }
        skinnedMeshRenderer.sharedMesh.SetTrianglesImpl(0, IndexFormat.UInt32, array, length, 0, length, true, (int)skinnedMeshRenderer.sharedMesh.GetBaseVertex(0));
    }

    /// <summary>
    /// Experimental method of messing with mesh renderers at runtime
    /// </summary>
    [Obsolete]
    public static IEnumerable<int> GetVerticesConnectedToBone(this SkinnedMeshRenderer skinnedMeshRenderer, int boneIndex)
    {
        var boneWeights = skinnedMeshRenderer.sharedMesh.boneWeights;
        for (var i = 0; i < boneWeights.Count; i++)
        {
            var boneWeight = boneWeights[i];
            if (boneWeight.boneIndex0 == boneIndex && boneWeight.weight0 > 0 ||
                boneWeight.boneIndex1 == boneIndex && boneWeight.weight1 > 0 ||
                boneWeight.boneIndex2 == boneIndex && boneWeight.weight2 > 0 ||
                boneWeight.boneIndex3 == boneIndex && boneWeight.weight3 > 0)
            {
                yield return i;
            }
        }
    }

    /// <summary>
    /// Experimental method of messing with mesh renderers at runtime
    /// </summary>
    [Obsolete]
    public static bool[] GetVerticesConnectedToBoneArray(this SkinnedMeshRenderer skinnedMeshRenderer, int boneIndex)
    {
        var boneWeights = skinnedMeshRenderer.sharedMesh.boneWeights;
        var array = new bool[boneWeights.Count];

        for (var i = 0; i < boneWeights.Count; i++)
        {
            var boneWeight = boneWeights[i];
            if (boneWeight.boneIndex0 == boneIndex && boneWeight.weight0 > 0 ||
                boneWeight.boneIndex1 == boneIndex && boneWeight.weight1 > 0 ||
                boneWeight.boneIndex2 == boneIndex && boneWeight.weight2 > 0 ||
                boneWeight.boneIndex3 == boneIndex && boneWeight.weight3 > 0)
            {
                array[i] = true;
            }
        }

        return array;
    }
}