using System;
using System.Collections;
using System.IO;
using System.Linq;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppInterop.Runtime;
using Il2CppNinjaKiwi.Common.Linq;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppSystem.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
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
        var total = 0;

        var resourceMap = Addressables.ResourceLocators.First();

        var keys = resourceMap.Keys.ToArray().Select(o => o.ToString()).ToArray();

        foreach (var key in keys)
        {
            if (!resourceMap.Locate(key, Il2CppType.Of<Sprite>(), out var list)) continue;
            var spriteLocation = list.FirstOrDefault();

            var sprite = Addressables.LoadAssetAsync<Sprite>(spriteLocation);

            yield return sprite;

            var path = Path.Combine(FileIOHelper.sandboxRoot, spriteLocation.InternalId);
            Directory.CreateDirectory(Path.GetDirectoryName(path)!);

            try
            {
                sprite.Result.TrySaveToPNG(path);
                ReportProgress(ref total);
                // ModHelper.Msg($"Successfully saved {path}");
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to save {path}");
                ModHelper.Warning(e);
            }
        }

        var allLocations = resourceMap.AllLocations.ToArray();

        var spriteAtlases = allLocations
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
                    ReportProgress(ref total);
                    // ModHelper.Msg($"Successfully saved {path}");
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

    public static void ReportProgress(ref int howMany)
    {
        howMany++;

        if (howMany % 500 == 0)
        {
            ModHelper.Msg($"Exported {howMany} images so far...");
        }
    }
}