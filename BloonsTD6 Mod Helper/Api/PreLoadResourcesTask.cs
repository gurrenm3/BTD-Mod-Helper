using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Api;

/// <summary>
/// Task to preload images and save them in the Unity scene so they can be accessed quickly
/// </summary>
internal class PreLoadResourcesTask : ModLoadTask
{
    private const int BytesPerFrame = 100000;

    private int currentByteTotal;

    private bool? showProgressBar;

    public PreLoadResourcesTask()
    {
        Instance = this;
        mod = ModHelper.Main;
    }

    public override string DisplayName => "Pre-loading mod resources...";

    public override bool ShowProgressBar => showProgressBar ??=
        ModHelper.Mods.SelectMany(BloonsTD6Mod => BloonsTD6Mod.Resources.Values).Sum(bytes => bytes.Length) >
        BytesPerFrame * 5;

    internal static PreLoadResourcesTask Instance { get; private set; }

    /// <summary>
    /// Don't load this like a normal task
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<ModContent> Load() => Enumerable.Empty<ModContent>();

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

        var totalMods = ModHelper.Mods.Count();
        foreach (var bloonsMod in ModHelper.Mods)
        {
            var name = bloonsMod.GetModName();
            // Description = name;

            var modObject = new GameObject(name)
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

            Progress += 1f / totalMods;
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