using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppSystem.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Api.Internal;

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
                                                ModHelper.Mods.SelectMany(bloonsMod => bloonsMod.Resources.Values)
                                                    .Sum(bytes => bytes.Length) >
                                                BytesPerFrame * 5;

    internal static PreLoadResourcesTask Instance { get; private set; }

    private static GameObject resizedSpritesParent;

    /// <summary>
    /// Don't load this like a normal task
    /// </summary>
    /// <returns></returns>
    public override IEnumerable<ModContent> Load() => Enumerable.Empty<ModContent>();

    public static bool Complete { get; private set; }

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

        resizedSpritesParent = new GameObject("resizedVanillaSprites")
        {
            transform =
            {
                parent = modHelperResources.transform
            }
        };

        foreach (var (guid, (orig, scale, square)) in SpriteResizer.GUIDs)
        {
            PreloadResizedSprite(guid, orig, scale, square);
        }

        Complete = true;
    }

    internal static void PreloadResizedSprite(string guid, string origGuid, Vector2 scale, bool square)
    {
        try
        {
            var gameObject = new GameObject(guid)
            {
                transform =
                {
                    parent = resizedSpritesParent.transform
                }
            };
            gameObject.SetActive(false);
            var image = gameObject.AddComponent<Image>();

            ResourceLoader.LoadSpriteFromSpriteReferenceAsync(new SpriteReference(origGuid), image);

            TaskScheduler.ScheduleTask(() =>
            {
                var sprite = SpriteResizer.SpriteCache[guid] = image.sprite.PadSpriteToScale(scale.x, scale.y);
                SpriteResizer.TextureCache[guid] = sprite.texture;

                if (square)
                {
                    sprite = sprite.PadSpriteToSquare();
                }

                image.SetSprite(sprite);
            }, () => image.sprite != null);
        }
        catch (Exception e)
        {
            ModHelper.Warning($"Failed to resize sprite {origGuid} to scale {scale.ToString()}");
            ModHelper.Warning(e);
        }

    }

    internal static void PreloadSprite(Sprite sprite, string name, GameObject parent)
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