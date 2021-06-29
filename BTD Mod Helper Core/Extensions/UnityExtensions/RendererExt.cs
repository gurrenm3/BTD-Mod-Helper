using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Il2CppSystem;
using UnhollowerBaseLib;
using UnityEngine;
using UnityEngine.Rendering;
using ArgumentException = System.ArgumentException;
using Array = Il2CppSystem.Array;
using Object = UnityEngine.Object;
using Tuple = System.Tuple<int, int, int>;
using Int32 = Il2CppSystem.Int32;

namespace BTD_Mod_Helper.Extensions
{
    public static class RendererExt
    {
        /// <summary>
        /// (Cross-Game compatible) Set the texture for this renderer. Equivalent to "render.material.mainTexture = texture2D"
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="texture2D"></param>
        public static void SetMainTexture(this Renderer renderer, Texture2D texture2D)
        {
            renderer.material.mainTexture = texture2D;
        }

        /// <summary>
        /// (Cross-Game compatible) Set the texture for all renderers in this collection. Equivalent to a "ForEach(render.material.mainTexture = texture2D)"
        /// </summary>
        /// <param name="renderers"></param>
        /// <param name="texture2D"></param>
        public static void SetMainTexture(this Il2CppReferenceArray<Renderer> renderers, Texture2D texture2D)
        {
            renderers.ForEach(renderer => renderer.material.mainTexture = texture2D);
        }
        
        /// <summary>
        /// Unbinds the renderer's sharedMesh, so that changes you make to it don't change the original
        /// </summary>
        /// <param name="skinnedMeshRenderer"></param>
        /// <returns></returns>
        public static Mesh UnbindMesh(this SkinnedMeshRenderer skinnedMeshRenderer)
        {
            return skinnedMeshRenderer.sharedMesh = Object.Instantiate(skinnedMeshRenderer.sharedMesh);
        }
        
        public static Mesh BakedMesh(this SkinnedMeshRenderer skinnedMeshRenderer)
        {
            var mesh = new Mesh();
            skinnedMeshRenderer.BakeMesh(mesh);
            return mesh;
        }

        public static List<Vector3> GetVertices(this SkinnedMeshRenderer skinnedMeshRenderer)
        {
            return skinnedMeshRenderer.sharedMesh.isReadable
                ? skinnedMeshRenderer.sharedMesh.vertices.ToList()
                : skinnedMeshRenderer.BakedMesh().vertices.ToList();
        }

        /// <summary>
        /// Gets the list of triangles for a Mesh, even if its not marked as isReadable
        /// <br/>
        /// Each "triangle" is a set of 3 consecutive ints in the list, where the number is the index in the vertices
        /// </summary>
        /// <param name="skinnedMeshRenderer"></param>
        /// <param name="submesh"></param>
        /// <returns></returns>
        public static List<int> GetTriangles(this SkinnedMeshRenderer skinnedMeshRenderer, int submesh = 0)
        {
            return skinnedMeshRenderer.sharedMesh.GetTrianglesImpl(submesh, false).ToList();
        }

        public static List<int[]> GetTrianglesAsArrays(this SkinnedMeshRenderer skinnedMeshRenderer, int submesh = 0)
        {
            var triangles = skinnedMeshRenderer.GetTriangles();
            var trianglesAsVectors = new List<int[]>();
            for (var i = 0; i < triangles.Count; i += 3)
            {
                trianglesAsVectors.Add(new[] {triangles[i], triangles[i + 1], triangles[i + 2]});
            }

            return trianglesAsVectors;
        }

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
                array.SetValue(new Int32{m_value = triangles[i]}.BoxIl2CppObject(), i);
            }
            skinnedMeshRenderer.sharedMesh.SetTrianglesImpl(0, IndexFormat.UInt32, array, length, 0, length, true, (int) skinnedMeshRenderer.sharedMesh.GetBaseVertex(0));
        }
        
        public static int GetBoneIndex(this SkinnedMeshRenderer skinnedMeshRenderer, string name)
        {
            for (var i = 0; i < skinnedMeshRenderer.bones.Count; i++)
            {
                if (skinnedMeshRenderer.bones[i].name == name)
                {
                    return i;
                }
            }

            return -1;
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
