using System;
using System.Collections;
using System.IO;
using System.Linq;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppInterop.Runtime;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppSystem.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.U2D;

namespace BTD_Mod_Helper.Api.Commands;

internal class ExportAssetsCommand : ModCommand<ExportCommand>
{
    public override string Command => "assets";
    public override string Help => "Exports all the addressable png assets in the game";

    public override bool Execute(ref string resultText)
    {
        MelonCoroutines.Start(ExportAllImages());
        resultText = "Starting coroutine for exporting assets, check console for details";
        return true;
    }

    public static IEnumerator ExportAllImages()
    {
        var resourceMap = Addressables.ResourceLocators.First().Cast<ResourceLocationMap>();

        foreach (var list in resourceMap.Locations.Values())
        {
            var spriteLocation = list.Cast<Il2CppReferenceArray<IResourceLocation>>()
                .FirstOrDefault(location => location.ResourceType == Il2CppType.Of<Sprite>());

            if (spriteLocation != null)
            {
                var sprite = Addressables.LoadAsset<Sprite>(spriteLocation);

                yield return sprite;

                var path = Path.Combine(FileIOHelper.sandboxRoot, spriteLocation.InternalId);
                Directory.CreateDirectory(Path.GetDirectoryName(path)!);

                try
                {
                    sprite.Result.TrySaveToPNG(path);
                    ModHelper.Msg($"Successfully saved {path}");
                }
                catch (Exception e)
                {
                    ModHelper.Warning($"Failed to save {path}");
                    ModHelper.Warning(e);
                }
            }
        }

        var spriteAtlases = resourceMap.Locations.Values()
            .SelectMany(list => list.Cast<Il2CppReferenceArray<IResourceLocation>>())
            .Where(location => location.ResourceType == Il2CppType.Of<SpriteAtlas>())
            .DistinctBy(location => location.PrimaryKey)
            .ToDictionary(location => location.PrimaryKey, location => location.InternalId);

        foreach (var (atlasName, atlasPath) in spriteAtlases)
        {
            if (atlasName == "AssetLibraryAtlas") continue;

            var atlas = ResourceLoader.LoadAtlas(atlasName);

            yield return atlas;

            var dummyArray = new Il2CppReferenceArray<Sprite>(atlas.Result.spriteCount);
            atlas.Result.GetSprites(dummyArray);

            foreach (var sprite in dummyArray)
            {
                var name = sprite.name.Replace("(Clone)", "");
                var path = Path.Combine(FileIOHelper.sandboxRoot,
                    atlasPath[..atlasPath.LastIndexOf(".", StringComparison.Ordinal)], name + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(path)!);

                try
                {
                    sprite.TrySaveToPNG(path);
                    ModHelper.Msg($"Successfully saved {path}");
                }
                catch (Exception e)
                {
                    ModHelper.Warning($"Failed to save {path}");
                    ModHelper.Warning(e);
                }
            }
        }

        ModHelper.Msg("All assets exported.");
    }
}