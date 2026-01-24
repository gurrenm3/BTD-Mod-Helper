using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Unity;
namespace BTD_Mod_Helper.Api.Bloons;

/// <summary>
/// Provides Utility methods for dealing with BloonModels
/// </summary>
public class BloonModelUtils
{
    /// <summary>
    /// Constructs an accurate BloonID for a BloonModel based off of it's statuses.
    /// </summary>
    /// <param name="bloonName"></param>
    /// <param name="camo"></param>
    /// <param name="regrow"></param>
    /// <param name="fortified"></param>
    /// <returns></returns>
    public static string ConstructBloonId(string bloonName, bool camo, bool regrow, bool fortified)
    {
        var baseName = bloonName.Replace("Camo", "").Replace("Regrow", "").Replace("Fortified", "");

        if (Game.instance?.model == null)
        {
            return baseName + (regrow ? "Regrow" : "") + (fortified ? "Fortified" : "") + (camo ? "Camo" : "");
        }

        return BloonType.Construct(baseName, camo, regrow, fortified);
    }

    /// <summary>
    /// Creates a GrowModel behavior that adds Regrowth.
    /// </summary>
    /// <param name="regrowsTo"></param>
    /// <param name="regrowRate"></param>
    /// <returns></returns>
    public static GrowModel CreateGrowModel(string regrowsTo, float regrowRate) =>
        new("GrowModel_", regrowRate, regrowsTo, null);
}