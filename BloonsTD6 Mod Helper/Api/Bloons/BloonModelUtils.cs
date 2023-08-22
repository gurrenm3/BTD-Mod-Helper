using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Utils;
namespace BTD_Mod_Helper.Api.Bloons;

/// <summary>
/// Provides Utility methods for dealing with BloonModels
/// </summary>
public class BloonModelUtils
{
    /// <summary>
    /// Converts the <see cref="BloonModel.speed"/> from a BloonModel to <see cref="BloonModel.speedFrames"/>
    /// </summary>
    /// <param name="speed"></param>
    /// <returns></returns>
    public static float SpeedToSpeedFrames(float speed) => speed * 0.416667f / 25f;
    
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

        return BloonTypeUtility.BloonType(baseName, camo, regrow, fortified);
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