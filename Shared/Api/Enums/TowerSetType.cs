using System.Collections.Generic;
using BTD_Mod_Helper.Api.Towers;
namespace BTD_Mod_Helper.Api.Enums;

/// <summary>
/// Enum-like class for the different tower set types
/// </summary>
public static class TowerSetType
{
    /// <summary>
    /// The primary set of towers
    /// </summary>
    public const string Primary = "Primary";
    
    /// <summary>
    /// The military set of towers
    /// </summary>
    public const string Military = "Military";
    
    /// <summary>
    /// The magic set of towers
    /// </summary>
    public const string Magic = "Magic";
    
    /// <summary>
    /// The support set of towers
    /// </summary>
    public const string Support = "Support";

    /// <summary>
    /// Enumeration of all (vanilla) tower sets
    /// </summary>
    public static IEnumerable<string> All
    {
        get
        {
            yield return Primary;
            yield return Military;
            yield return Magic;
            yield return Support;
        }
    }

    /// <summary>
    /// Gets the ID to use for a custom tower set
    /// </summary>
    public static string Custom<T>() where T : ModTowerSet => ModContent.GetInstance<T>().Id;
}