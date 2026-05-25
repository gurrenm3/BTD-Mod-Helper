/*using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace BTD_Mod_Helper.Api.Internal;

internal sealed class VanillaPrefabsGenerator : EnumClassGenerator
{
    protected override IEnumerable<(string Name, string Value)> CollectEntries() => GetAllAddressables<GameObject>()
        .Where(t => Path.GetExtension(t.Location.InternalId) == ".prefab")
        .Where(t => !t.Location.InternalId.Contains("/UI"))
        .Select(t => (t.Location.InternalId, t.Guid));

    protected override string FixName(string name) =>
        name
            .RegexReplace(@"(\d\d\d)-([^\.]+)\.", "$2$1.")
            .Replace("Generated/", "")
            .Replace("Graphics/", "")
            .Replace("Assets/", "")
            .Replace("Combinations/", "")
            .Replace("path01/", "")
            .Replace("path02/", "")
            .Replace("path03/", "")
            .Replace("Prefabs/", "")
            .Replace("AssetBundleMaps/", "")
            .Replace("/", "_")
            .Replace("-", "")
            .Replace(" ", "")
            .Replace("#", "")
            .Replace(".prefab", "");
}*/