using System;
using System.Collections.Generic;
using System.Text;
using UnhollowerBaseLib;
using UnityEngine;

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
    }
}
