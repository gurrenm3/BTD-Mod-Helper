using Assets.Scripts.Unity.Display;
using System.Collections.Generic;
using System.Linq;
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
            if (node.genericRenderers == null || !node.genericRenderers.Any())
            {
                return new List<T>();
            }

            if (recalculate && node.genericRenderers[0] == null)
            {
                node.RecalculateGenericRenderers();
            }

            return node.genericRenderers.GetItemsOfType<Renderer, T>();
        }

        /// <summary>
        /// Gets the first generic renderer of the specified type, recalculating the renderers if need be
        /// </summary>
        /// <param name="node">The UnityDisplayNode</param>
        /// <param name="recalculate">Whether to recalculate renderers</param>
        /// <typeparam name="T">The type of Renderer you're looking for</typeparam>
        /// <returns>Hey</returns>
        public static T GetRenderer<T>(this UnityDisplayNode node, bool recalculate = true) where T : Renderer
        {
            return node.GetRenderers<T>(recalculate).FirstOrDefault();
        }
    }
}
