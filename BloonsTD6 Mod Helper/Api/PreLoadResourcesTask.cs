using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Unity.Towers.Mods;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api;

/// <summary>
/// Task to preload images and save them in the Unity scene so they can be accessed quickly
/// </summary>
public class PreLoadResourcesTask : ModLoadTask
{
    private const int BytesPerFrame = 100000;

    /// <inheritdoc />
    public override string DisplayName => "Pre-loading mod resources...";

    private int currentByteTotal;

    /// <summary>
    /// Don't load this like a normal task
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<ModContent> Load() => Enumerable.Empty<ModContent>();

    /// <inheritdoc />
    public override IEnumerator Coroutine()
    {
        var scene = SceneManager.GetSceneByName("Global");

        var rootGameObject = scene.GetRootGameObjects()[0];
        var modHelperResources = new GameObject("ModHelperResources")
        {
            transform =
            {
                parent = rootGameObject.transform
            }
        };

        var modIcons = new GameObject("ModIcons")
        {
            transform =
            {
                parent = modHelperResources.transform
            }
        };
        foreach (var modHelperData in ModHelperData.All)
        {
            if (modHelperData.GetIcon() is Sprite sprite)
            {
                PreloadSprite(sprite, modHelperData.Name, modIcons);
            }
        }

        yield return null;

        foreach (var bloonsMod in ModHelper.Mods)
        {
            var modObject = new GameObject(bloonsMod.GetModName())
            {
                transform =
                {
                    parent = modHelperResources.transform
                }
            };
            foreach (var (key, bytes) in bloonsMod.Resources)
            {
                PreloadSprite(ResourceHandler.GetSprite(GetId(bloonsMod, key)), key, modObject);
                currentByteTotal += bytes.Length;
                if (currentByteTotal > BytesPerFrame)
                {
                    currentByteTotal = 0;
                    yield return null;
                }
            }
        }
    }

    private static void PreloadSprite(Sprite sprite, string name, GameObject parent)
    {
        var gameObject = new GameObject(name)
        {
            transform =
            {
                parent = parent.transform
            }
        };
        gameObject.SetActive(false);
        var image = gameObject.AddComponent<Image>();
        image.SetSprite(sprite);
    }
}