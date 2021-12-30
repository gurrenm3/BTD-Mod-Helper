using Assets.Scripts.Unity.Display;
using Assets.Scripts.Utils;
using MelonLoader;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Components;
using UnityEngine;

namespace BTD_Mod_Helper.Extensions
{
    public static partial class UnityDisplayNodeExt
    {
        /// <summary>
        /// Gets all generic renderers of the specified type, recalculating the renderers if need be
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        /// <param name="recalculate">Whether to recalculate renderers</param>
        /// <typeparam name="T">The type of Renderer you're looking for</typeparam>
        /// <returns></returns>
        public static List<T> GetRenderers<T>(this UnityDisplayNode node, bool recalculate = true) where T : Renderer
        {
            if (node.genericRenderers == null)
            {
                return new List<T>();
            }

            if (recalculate && node.genericRenderers[0] == null)
            {
                node.RecalculateGenericRenderers();
            }

            return node.genericRenderers.GetItemsOfType<Renderer, T>().ToList();
        }

        /// <summary>
        /// Gets the first generic renderer of the specified type, recalculating the renderers if need be
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        /// <param name="recalculate">Whether to recalculate renderers</param>
        /// <typeparam name="T">The type of Renderer you're looking for</typeparam>
        public static T GetRenderer<T>(this UnityDisplayNode node, bool recalculate = true) where T : Renderer
        {
            return node.GetRenderers<T>(recalculate)
                .OrderBy(renderer => renderer.name.StartsWith("FlatSkin") ? 0 : 1)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets all renderers that are of type SkinnedMeshRenderer or MeshRenderer
        /// </summary>
        /// <param name="node"></param>
        /// <param name="recalculate"></param>
        /// <returns></returns>
        public static List<Renderer> GetMeshRenderers(this UnityDisplayNode node, bool recalculate = true)
        {
            if (node.genericRenderers == null)
            {
                return new List<Renderer>();
            }

            if (recalculate && node.genericRenderers[0] == null)
            {
                node.RecalculateGenericRenderers();
            }

            return node.genericRenderers.Where(nodeGenericRenderer =>
                    nodeGenericRenderer.IsType<SkinnedMeshRenderer>() || nodeGenericRenderer.IsType<MeshRenderer>())
                .ToList();
        }

        /// <summary>
        /// Gets the first (or an indexed) SkinnedMeshRenderer/MeshRenderer
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
        /// Saves the texture used for this node's mesh renderer 
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
                path = FileIOUtil.GetSandboxPath() + node.name + index + ".png";
            }

            var meshRenderers = node.GetMeshRenderers();
            if (meshRenderers.Count == 0)
            {
                MelonLogger.Error(
                    "Can't save mesh texture because the node doesn't have any MeshRenderers or SkinnedMeshRenderers, you might want to call node.PrintInfo()");
            }
            else if (meshRenderers.Count <= index)
            {
                MelonLogger.Error(
                    $"The node doesn't have {index} total mesh renderers, you might want to call node.PrintInfo()");
            }
            else
            {
                meshRenderers[index].material.mainTexture.TrySaveToPNG(path);
            }
        }

        /// <summary>
        /// Prints relevant info about this node to the console including:
        /// <br/>
        /// 
        /// </summary>
        /// <param name="node"></param>
        public static void PrintInfo(this UnityDisplayNode node)
        {
            var start = $"-------------Information about UnityDisplayNode {node.name}-------------";
            MelonLogger.Msg(start);

            MelonLogger.Msg("Generic Renderers:");
            for (var i = 0; i < node.genericRenderers.Count; i++)
            {
                var renderer = node.genericRenderers[i];
                MelonLogger.Msg($"   {i}. {renderer.name} ({renderer.GetIl2CppType().Name})");
            }

            MelonLogger.Msg("");

            MelonLogger.Msg("Generic Render Layers:");
            for (var i = 0; i < node.genericRendererLayers.Count; i++)
            {
                var layer = node.genericRendererLayers[i];
                MelonLogger.Msg($"   {i}. {layer}");
            }

            MelonLogger.Msg("");

            MelonLogger.Msg("Component Hierarchy:");
            node.gameObject.RecursivelyLog();

            MelonLogger.Msg(new string('-', start.Length));
        }

        public static void RemoveBone(this UnityDisplayNode unityDisplayNode, string boneName,
            bool alreadyUnbound = false)
        {
            var bone = unityDisplayNode.GetBone(boneName);
            bone.gameObject.AddComponent<ScaleOverrideZero>();
        }

        public static Transform GetBone(this UnityDisplayNode unityDisplayNode, string boneName)
        {
            return unityDisplayNode.gameObject.GetComponentInChildrenByName<Transform>(boneName);
        }
    }
}