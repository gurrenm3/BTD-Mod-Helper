using Assets.Scripts.Unity.Display;
using Assets.Scripts.Utils;
using System.IO;
using UnityEngine;

namespace BTD_Mod_Helper.Extensions.DisplayNodeExtensions;

/// <summary>
/// Extension for dumping textures from UnityDisplayNodes
/// </summary>
public static partial class DumpNodeExt
{
    /// <summary>
    /// Only runs when tower placed.
    /// Dumps any textures inside of a display node into Ninja Kiwi directory
    /// </summary>
    public static void Dump(this UnityDisplayNode node)
    {
        if (!Directory.Exists($"{FileIOUtil.sandboxRoot}DumpedTextures/"))
        {
            Directory.CreateDirectory($"{FileIOUtil.sandboxRoot}DumpedTextures/");
        }
        foreach (var item in node.genericRenderers)
        {
            if (item.materials.Length > 0)
            {
                if (item.material.mainTexture)
                {
                    item.material.mainTexture.TrySaveToPNG($"{FileIOUtil.sandboxRoot}DumpedTextures/{item.material.mainTexture.name}.png");
                }
            }
        }

        if (node.isSprite)
        {
            foreach (var spriteRenderer in node.gameObject.GetComponentsInChildren<SpriteRenderer>())
            {
                spriteRenderer.sprite.texture.TrySaveToPNG($"{FileIOUtil.sandboxRoot}DumpedTextures/{spriteRenderer.sprite.texture.name}.png");
            }
        }
    }
}