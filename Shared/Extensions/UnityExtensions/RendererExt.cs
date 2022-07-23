using System;
using System.Collections.Generic;
using System.Linq;
using UnhollowerBaseLib;
using UnityEngine;
using Object = UnityEngine.Object;
using Tuple = System.Tuple<int, int, int>;

namespace BTD_Mod_Helper.Extensions;

public static partial class RendererExt
{
    private static readonly int OutlineColor = Shader.PropertyToID("_OutlineColor");

    /// <summary>
    /// Set the texture for this renderer. Equivalent to "render.material.mainTexture = texture2D"
    /// </summary>
    /// <param name="renderer"></param>
    /// <param name="texture2D"></param>
    public static void SetMainTexture(this Renderer renderer, Texture2D texture2D)
    {
        renderer.material.mainTexture = texture2D;
    }

    /// <summary>
    /// Sets the outline color for this renderer
    /// </summary>
    public static void SetOutlineColor(this Renderer renderer, Color color)
    {
        renderer.material.SetColor(OutlineColor, color);
        renderer.material.SetShaderKeywords(Array.Empty<string>());
    }
    
    /// <summary>
    /// Set the texture for all renderers in this collection. Equivalent to a "ForEach(render.material.mainTexture = texture2D)"
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="skinnedMeshRenderer"></param>
    /// <returns></returns>
    public static Mesh BakedMesh(this SkinnedMeshRenderer skinnedMeshRenderer)
    {
        var mesh = new Mesh();
        skinnedMeshRenderer.BakeMesh(mesh);
        return mesh;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="skinnedMeshRenderer"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="skinnedMeshRenderer"></param>
    /// <param name="submesh"></param>
    /// <returns></returns>
    public static List<int[]> GetTrianglesAsArrays(this SkinnedMeshRenderer skinnedMeshRenderer, int submesh = 0)
    {
        var triangles = skinnedMeshRenderer.GetTriangles();
        var trianglesAsVectors = new List<int[]>();
        for (var i = 0; i < triangles.Count; i += 3)
        {
            trianglesAsVectors.Add(new[] { triangles[i], triangles[i + 1], triangles[i + 2] });
        }

        return trianglesAsVectors;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="skinnedMeshRenderer"></param>
    /// <param name="name"></param>
    /// <returns></returns>
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
}