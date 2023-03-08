using System.Collections.Generic;
using System.Linq;
namespace BTD_Mod_Helper.Api.Data;

/// <summary>
/// Class for dynamically overriding In-Game text in a way that's compatible with other mods
/// </summary>
public abstract class ModTextOverride : ModContent
{
    /// <inheritdoc />
    public override int RegisterPerFrame => 100;

    internal static readonly Dictionary<string, SortedSet<ModTextOverride>> Cache = new();

    /// <summary>
    /// The key within the localization text table that this replaces
    /// </summary>
    public abstract string LocalizationKey { get; }

    /// <summary>
    /// Whether this is active or not at the given moment (that the text is retrieved)
    /// </summary>
    public abstract bool Active { get; }

    internal virtual string TextValueForKey(string key) => TextValue;
    
    /// <summary>
    /// The text that will actually be returned if this is active
    /// </summary>
    public abstract string TextValue { get; }

    private protected static void AddToCache(string key, ModTextOverride textOverride)
    {
        if (!Cache.ContainsKey(key))
        {
            Cache[key] = new SortedSet<ModTextOverride>();
        }

        if (!Cache[key].Add(textOverride))
        {
            ModHelper.Warning($"Failed to register text override {textOverride.Id}");
        }
    }
    
    /// <inheritdoc />
    public override void Register()
    {
        AddToCache(LocalizationKey, this);
    }

    internal static bool TryGetOverride(string key, out string text)
    {
        text = default;
        if (!Cache.TryGetValue(key, out var overrides)) return false;

        var modTextOverride = overrides.FirstOrDefault(o => o.Active);
        if (modTextOverride == null) return false;

        text = modTextOverride.TextValueForKey(key);
        return true;
    }
}