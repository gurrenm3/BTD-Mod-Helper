using System.Collections.Generic;
using System.Linq;
namespace BTD_Mod_Helper.Api.Data;

/// <summary>
/// A bunch of ModTextOverrides that all share the same Active condition and don't require any on the fly determinations of their text
/// </summary>
public abstract class ModMultiTextOverride : ModTextOverride
{
    private Dictionary<string, string> table;

    /// <summary>
    /// The table of keys and values 
    /// </summary>
    public abstract Dictionary<string, string> Table { get; }

    /// <inheritdoc />
    public sealed override string LocalizationKey => null;

    /// <inheritdoc />
    public sealed override string TextValue => null;

    /// <summary>
    /// Suffix added to all keys in the table, by default nothing ""
    /// </summary>
    public virtual string KeyPrefix => "";
    
    /// <summary>
    /// Suffix added to all keys in the table, by default nothing ""
    /// </summary>
    public virtual string KeySuffix => "";

    /// <inheritdoc />
    public override void Register()
    {
        table = Table.ToDictionary(pair => KeyPrefix + pair.Key + KeySuffix, pair => pair.Value);
        foreach (var key in table.Keys)
        {
            AddToCache(key, this);
        }
    }

    internal override string TextValueForKey(string key) => table[key];
}