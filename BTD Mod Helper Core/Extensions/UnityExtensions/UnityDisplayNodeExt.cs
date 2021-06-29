using Assets.Scripts.Unity.Display;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Utils;
using MelonLoader;
using UnityEngine;

namespace BTD_Mod_Helper.Extensions
{
    public static class UnityDisplayNodeExt
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
        /// Saves the texture used for this node's mesh renderer 
        /// <br/>
        /// By default, this saves to local files, aka the "Local" shortcut in your main BloonsTD6 directory
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        /// <param name="path">Optional path to save to instead</param>
        public static void SaveMeshTexture(this UnityDisplayNode node, string path = null)
        {
            if (path == null)
            {
                path = FileIOUtil.GetSandboxPath() + node.name + ".png";
            }
            node.GetRenderer<SkinnedMeshRenderer>().material.mainTexture.TrySaveToPNG(path);
        }
        
        /// <summary>
        /// Saves the texture used for this node's mesh renderer 
        /// <br/>
        /// By default, this saves to local files, aka the "Local" shortcut in your main BloonsTD6 directory
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        /// <param name="path">Optional path to save to instead</param>
        public static void SaveMeshTexture(this UnityDisplayNode node, int index, string path = null)
        {
            if (path == null)
            {
                path = FileIOUtil.GetSandboxPath() + node.name + index + ".png";
            }
            node.GetRenderers<SkinnedMeshRenderer>()[index].material.mainTexture.TrySaveToPNG(path);
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
        
        public static void RemoveBone(this UnityDisplayNode unityDisplayNode, string boneName, bool alreadyUnbound = false)
        {
            var skinnedMeshRenderer = unityDisplayNode.GetRenderer<SkinnedMeshRenderer>();
            if (!alreadyUnbound)
            {
                skinnedMeshRenderer.UnbindMesh();
            }

            // Unbind the mesh so we can change it without affecting the original
            skinnedMeshRenderer.UnbindMesh();
            
            // Get the bone index that controls the Boomerang
            var boomerang = skinnedMeshRenderer.GetBoneIndex(boneName);
            
            // Get all vertices that the bone controls
            var badVertices = skinnedMeshRenderer.GetVerticesConnectedToBoneArray(boomerang);

            // Remove all triangles that contain any of those vertices
            var triangles = skinnedMeshRenderer.GetTrianglesAsArrays();
            triangles.RemoveAll(triangle => triangle.Any(v => badVertices[v]));
            skinnedMeshRenderer.SetTriangles(triangles);
        }
    }
}
