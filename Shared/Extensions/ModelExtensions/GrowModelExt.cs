using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extension methods for <see cref="GrowModel"/>.
/// </summary>
public static class GrowModelExt
{
    /// <summary>
    /// Sets which bloon this should regrow into.
    /// </summary>
    /// <param name="growModel"></param>
    /// <param name="regrowsTo">The ID of the bloon this should regrow into</param>
    public static void SetRegrowBloon(this GrowModel growModel, string regrowsTo)
    {
#if BloonsTD6
        growModel.growToId = regrowsTo;
#elif BloonsAT
            growModel.name = $"GrowModel_{regrowsTo}"; // untested
#endif
    }

    /// <summary>
    /// Sets which bloon this should regrow into.
    /// </summary>
    /// <param name="growModel"></param>
    /// <param name="regrowsTo">The ID of the bloon this should regrow into</param>
    /// <param name="regrowRate">The rate at which this regrows.</param>
    public static void SetRegrowBloon(this GrowModel growModel, string regrowsTo, float regrowRate)
    {
        growModel.SetRegrowBloon(regrowsTo);
        growModel.rate = regrowRate;
    }

    /// <summary>
    /// Returns the ID of the BloonModel that this regrows into.
    /// </summary>
    /// <param name="growModel"></param>
    /// <returns></returns>
    public static string GetRegrowBloon(this GrowModel growModel)
    {
#if BloonsTD6
        return growModel.growToId;
#elif BloonsAT
            return growModel.name.Replace("GrowModel_", ""); // untested
#endif
    }
}