using Assets.Scripts.Unity.Display;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Components;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for UnityDisplayNodes
/// </summary>
public static partial class UnityDisplayNodeExt
{
    /// <summary>
    /// (Cross-Game compatible) Get all 3D models attached to this UnityDisplayNode. 
    /// </summary>
    /// <param name="unityDisplayNode"></param>
    /// <returns></returns>
    public static List<Transform> Get3DModels(this UnityDisplayNode unityDisplayNode)
    {
        return unityDisplayNode.transform.parent.GetComponentsInChildren<Transform>().ToList();
    }

    /// <summary>
    /// (Cross-Game compatible) Gets the first generic renderer of the specified type, recalculating the renderers if need be
    /// </summary>
    /// <param name="node">The UnityDisplayNode</param>
    /// <param name="recalculate">Whether to recalculate renderers</param>
    /// <typeparam name="T">The type of Renderer you're looking for</typeparam>
    public static T GetRenderer<T>(this UnityDisplayNode node, bool recalculate = true) where T : Renderer
    {
        return node.GetRenderers<T>(recalculate)
            .OrderBy(renderer => renderer.name.StartsWith("FlatSkin") ? 0 : 1)
            .FirstOrDefault()!;
    }

    /// <summary>
    /// (Cross-Game compatible) Gets all generic renderers on this UnityDisplayNode, recalculating the renderers if need be
    /// </summary>
    /// <param name="node">The UnityDisplayNode</param>
    /// <param name="recalculate">Whether to recalculate renderers</param>
    /// <returns></returns>
    public static List<Renderer> GetRenderers(this UnityDisplayNode node, bool recalculate = true)
    {
        var renderers = new List<Renderer>();

#if BloonsTD6
        if (node.genericRenderers == null)
        {
            renderers = node.GetComponents<Renderer>().ToList();
            if (renderers.Count == 0)
                return new List<Renderer>();
        }

        if (recalculate && node.genericRenderers![0] == null)
        {
            node.RecalculateGenericRenderers();
        }
#elif BloonsAT
            renderers = node.GetComponents<Renderer>().ToList();
#endif

        return renderers;
    }

    /// <summary>
    /// (Cross-Game compatible) Gets all generic renderers of the specified type, recalculating the renderers if need be
    /// </summary>
    /// <param name="node">The UnityDisplayNode</param>
    /// <param name="recalculate">Whether to recalculate renderers</param>
    /// <typeparam name="T">The type of Renderer you're looking for</typeparam>
    /// <returns></returns>
    public static List<T> GetRenderers<T>(this UnityDisplayNode node, bool recalculate = true) where T : Renderer
    {
        var renderers = new List<Renderer>();

#if BloonsTD6
        if (node.genericRenderers == null)
        {
            renderers = node.GetComponents<Renderer>().ToList();
            if (renderers.Count == 0)
                return new List<T>();
        }

        if (recalculate && node.genericRenderers![0] == null)
        {
            node.RecalculateGenericRenderers();
        }
#elif BloonsAT
            renderers = node.GetComponents<Renderer>().ToList();
#endif

        return renderers.GetItemsOfType<Renderer, T>();
    }

    /// <summary>
    /// (Cross-Game compatible) Gets the first (or an indexed) SkinnedMeshRenderer/MeshRenderer
    /// </summary>
    /// <param name="node"></param>
    /// <param name="index"></param>
    /// <param name="recalculate"></param>
    /// <returns></returns>
    public static Renderer GetMeshRenderer(this UnityDisplayNode node, int index = 0, bool recalculate = true)
    {
        return node.GetMeshRenderers()[index];
    }

    /// <summary>
    /// (Cross-Game compatible) Gets all renderers that are of type SkinnedMeshRenderer or MeshRenderer
    /// </summary>
    /// <param name="node"></param>
    /// <param name="recalculate"></param>
    /// <returns></returns>
    public static List<Renderer> GetMeshRenderers(this UnityDisplayNode node, bool recalculate = true)
    {
        List<Renderer> renderers = new List<Renderer>();

#if BloonsTD6
        if (node.genericRenderers == null)
        {
            renderers = node.GetComponents<Renderer>().ToList();
            if (renderers.Count == 0)
                return new List<Renderer>();
        }
        else
        {
            renderers = node.genericRenderers.ToList();

            if (recalculate && renderers.Any(renderer => renderer == null))
            {
                node.RecalculateGenericRenderers();
            }
        }
#elif BloonsAT
            renderers = node.GetComponents<Renderer>().ToList();
#endif

        return renderers.Where(nodeGenericRenderer => nodeGenericRenderer.IsType<SkinnedMeshRenderer>() ||
                                                      nodeGenericRenderer.IsType<MeshRenderer>()).ToList();
    }

    /// <summary>
    /// (Cross-Game compatible) Prints relevant info about this node to the console including:
    /// <br/>
    /// 
    /// </summary>
    /// <param name="node"></param>
    public static void PrintInfo(this UnityDisplayNode node)
    {
        var start = $"-------------Information about UnityDisplayNode {node.name}-------------";
        ModHelper.Log(start);

        var renderers = node.GetRenderers();

        ModHelper.Log("Generic Renderers:");
        for (var i = 0; i < renderers.Count; i++)
        {
            var renderer = renderers[i];
            ModHelper.Log($"   {i}. {renderer.name} ({renderer.GetIl2CppType().Name})");
        }

        ModHelper.Log("");

#if BloonsTD6

        ModHelper.Log("Generic Render Layers:");
        for (var i = 0; i < node.genericRendererLayers.Count; i++)
        {
            var layer = node.genericRendererLayers[i];
            ModHelper.Log($"   {i}. {layer}");
        }
#endif

        ModHelper.Log("");

        ModHelper.Log("Component Hierarchy:");
        node.gameObject.RecursivelyLog();

        ModHelper.Log(new string('-', start.Length));
    }

    /// <summary>
    /// (Cross-Game compatible) Removes (hides) a given bone
    /// </summary>
    public static void RemoveBone(this UnityDisplayNode unityDisplayNode, string boneName,
        bool alreadyUnbound = false)
    {
        var bone = unityDisplayNode.GetBone(boneName);
        bone.gameObject.AddComponent<ScaleOverride>();
    }

    /// <summary>
    /// (Cross-Game compatible) Gets the transform associated with the given bone
    /// </summary>
    public static Transform GetBone(this UnityDisplayNode unityDisplayNode, string boneName)
    {
        return unityDisplayNode.gameObject.GetComponentInChildrenByName<Transform>(boneName)!;
    }

    /// <summary>
    /// (Cross-Game compatible) Saves the texture used for this node's mesh renderer 
    /// <br/>
    /// By default, this saves to local files, aka "C:\Users\...\AppData\LocalLow\Ninja Kiwi\BloonsTD6"
    /// </summary>
    /// <param name="node">The UnityDisplayNode</param>
    /// <param name="index"></param>
    /// <param name="path">Optional path to save to instead</param>
    public static void SaveMeshTexture(this UnityDisplayNode node, int index = 0, string path = null)
    {
        if (path == null)
        {
#if BloonsTD6
            path = FileIOUtil.GetSandboxPath() + node.name + index + ".png";
#elif BloonsAT
                ModHelper.Error("Can't save mesh texture because no save path was provided");
                return;
#endif
        }

        var meshRenderers = node.GetMeshRenderers();
        if (meshRenderers.Count == 0)
        {
            ModHelper.Error(
                "Can't save mesh texture because the node doesn't have any MeshRenderers or SkinnedMeshRenderers, you might want to call node.PrintInfo()");
        }
        else if (meshRenderers.Count <= index)
        {
            ModHelper.Error(
                $"The node doesn't have {index} total mesh renderers, you might want to call node.PrintInfo()");
        }
        else
        {
            meshRenderers[index].material.mainTexture.TrySaveToPNG(path);
        }
    }
}