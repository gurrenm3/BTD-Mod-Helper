using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using ArgumentException = System.ArgumentException;
using Array = Il2CppSystem.Array;
using Int32 = Il2CppSystem.Int32;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class RendererExt
    {
        public static void SetTriangles(this SkinnedMeshRenderer skinnedMeshRenderer, List<int[]> trianglesAsArrays)
        {
            skinnedMeshRenderer.SetTriangles(trianglesAsArrays.SelectMany(array => array.AsEnumerable()).ToList());
        }

        public static void SetTriangles(this SkinnedMeshRenderer skinnedMeshRenderer, List<int> triangles)
        {
            var length = triangles.Count;
            if (length % 3 != 0)
            {
                throw new ArgumentException("Triangles list must be all sets of 3");
            }
            var array = Array.CreateInstance(Int32.Il2CppType, length);
            for (var i = 0; i < length; i++)
            {
                array.SetValue(new Int32 { m_value = triangles[i] }.BoxIl2CppObject(), i);
            }
            skinnedMeshRenderer.sharedMesh.SetTrianglesImpl(0, IndexFormat.UInt32, array, length, 0, length, true, (int)skinnedMeshRenderer.sharedMesh.GetBaseVertex(0));
        }

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
}
