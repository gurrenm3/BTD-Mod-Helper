using System.Collections.Generic;
using System.Linq;
using Il2CppNinjaKiwi.Common;

namespace BTD_Mod_Helper.Api.Data;

/// <summary>
/// Class for dynamically overriding In-Game text in a way that's compatible with other mods
/// </summary>
public abstract class ModTextOverride : ModContent
{
    internal static readonly Dictionary<string, SortedSet<ModTextOverride>> Cache = new();

    /// <inheritdoc />
    public override int RegisterPerFrame => 100;

    /// <summary>
    /// The key within the localization text table that this replaces
    /// </summary>
    public abstract string LocalizationKey { get; }

    /// <summary>
    /// Whether this is active or not at the given moment (that the text is retrieved)
    /// </summary>
    public abstract bool Active { get; }

    /// <summary>
    /// The text that will actually be returned if this is active
    /// </summary>
    public abstract string TextValue { get; }

    internal virtual string TextValueForKey(string key) => TextValue;

    internal bool disableOverride;

    /// <summary>
    /// The original text value being overriden
    /// </summary>
    protected string OriginalText
    {
        get
        {
            try
            {
                disableOverride = true;
                return LocalizationManager.Instance.GetText(LocalizationKey);
            }
            finally
            {
                disableOverride = false;
            }
        }
    }

    private protected static void AddToCache(string key, ModTextOverride textOverride)
    {
        if (!Cache.ContainsKey(key))
        {
            Cache[key] = [];
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

        var modTextOverride = overrides.FirstOrDefault(o => o.Active && !o.disableOverride);
        if (modTextOverride == null) return false;

        text = modTextOverride.TextValueForKey(key);
        return true;
    }
}