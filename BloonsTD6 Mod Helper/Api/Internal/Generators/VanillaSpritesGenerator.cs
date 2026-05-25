using System.Collections.Generic;
using System.IO;
using System.Linq;
using Il2CppInterop.Runtime;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppSystem.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.U2D;
namespace BTD_Mod_Helper.Api.Internal.Generators;

internal sealed class VanillaSpritesGenerator : EnumClassGenerator
{
    protected override IEnumerable<(string Name, string Value)> CollectEntries()
    {
        foreach (var (guid, location) in GetAllAddressables<Sprite>())
        {
            yield return (Path.GetFileNameWithoutExtension(location.InternalId), guid);
        }

        var resourceMap = Addressables.ResourceLocators.First();
        var atlasNames = resourceMap.AllLocations.ToArray()
            .Where(location => location.ResourceType == Il2CppType.Of<SpriteAtlas>())
            .Select(location => location.PrimaryKey)
            .Distinct();

        foreach (var atlasName in atlasNames)
        {
            if (atlasName == "AssetLibraryAtlas") continue;

            var atlas = ResourceLoader.LoadAtlas(atlasName).WaitForCompletion();

            var sprites = new Il2CppReferenceArray<Sprite>(atlas.spriteCount);
            atlas.GetSprites(sprites);

            foreach (var sprite in sprites)
            {
                var name = sprite.name.Replace("(Clone)", "");
                yield return (name, $"{atlasName}[{name}]");
            }
        }
    }
}