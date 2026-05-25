using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Il2CppInterop.Runtime;
using Il2CppNinjaKiwi.Common.Linq;
using Il2CppSystem.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;
using Enumerable = System.Linq.Enumerable;

namespace BTD_Mod_Helper.Api.Internal.Generators;

/// <summary>
/// Base for generators that emit a static class of <c>public const string</c> entries plus a
/// <c>ByName</c> lookup dictionary, under the <c>BTD_Mod_Helper.Api.Enums</c> namespace by default.
/// </summary>
internal abstract class EnumClassGenerator : ModSourceFileGenerator
{
    public override string[] OutputPath => ["Api", "Enums"];

    /// <summary>Yields the (raw display name, constant value) pairs to emit.</summary>
    protected abstract IEnumerable<(string Name, string Value)> CollectEntries();

    /// <summary>Convert a raw name into a valid C# identifier. Default handles the common Addressables-style names.</summary>
    protected virtual string FixName(string name) => DefaultFixName(name);

    public override void Generate(StringBuilder sb)
    {
        // Group by sanitized identifier; multiple distinct values under the same identifier get
        // suffixed "2", "3", ... in stable (sorted) order so regeneration is deterministic.
        var grouped = CollectEntries()
            .GroupBy(e => FixName(e.Name))
            .Where(g => !string.IsNullOrEmpty(g.Key))
            .Select(g => (Identifier: g.Key, Values: g.Select(e => e.Value).Distinct().OrderBy(v => v).ToArray()))
            .ToList();

        sb.AppendLine(
            $$"""
              using System.Collections.Generic;

              #pragma warning disable CS1591
              namespace {{Namespace}};

              public static class {{FileName}}
              {
              """);

        var realNames = new List<string>();
        foreach (var (identifier, values) in grouped)
        {
            for (var i = 0; i < values.Length; i++)
            {
                var realName = identifier + (i > 0 ? (i + 1).ToString() : "");
                sb.AppendLine($"""    public const string {realName} = "{values[i]}";""");
                realNames.Add(realName);
            }
        }

        sb.AppendLine();
        sb.AppendLine(
            $$"""
                  public static readonly Dictionary<string, string> ByName;
                  static {{FileName}}()
                  {
                      ByName = new Dictionary<string, string>
                      {
              """);
        foreach (var realName in realNames)
        {
            sb.AppendLine($"""            ["{realName}"] = {realName},""");
        }
        sb.AppendLine(
            """
                    };
                }
            }
            """);
    }

    private static string DefaultFixName(string name)
    {
        if (Regex.IsMatch(name, @"^\d\d\d-"))
        {
            name = string.Concat(Enumerable.Reverse(name.Split('-')));
        }
        if (name.Contains('#'))
        {
            name = name.Split('#')[0].Trim();
        }
        if (Regex.IsMatch(name, @"^\d.+"))
        {
            name = "The" + name;
        }
        return Regex.Replace(name, @"[^A-Za-z0-9_]", "");
    }


    /// <summary>
    /// Yields every GUID-keyed Addressables entry whose first <see cref="IResourceLocation"/>
    /// matches <typeparamref name="T"/>, paired with that location.
    /// </summary>
    public static IEnumerable<(string Guid, IResourceLocation Location)> GetAllAddressables<T>()
        where T : UnityEngine.Object
    {
        var resourceMap = Addressables.ResourceLocators.First();
        var keys = resourceMap.Keys.ToArray().Select(o => o.ToString()).ToArray();

        foreach (var key in keys)
        {
            if (!Guid.TryParse(key, out _)) continue;
            if (!resourceMap.Locate(key, Il2CppType.Of<T>(), out var list)) continue;

            var location = list.FirstOrDefault();
            if (location != null)
            {
                yield return (key, location);
            }
        }
    }
}