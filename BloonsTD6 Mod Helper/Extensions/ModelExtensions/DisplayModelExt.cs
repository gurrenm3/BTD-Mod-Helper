using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for DisplayModel
/// </summary>
public static class DisplayModelExt
{
    /// <summary>
    /// Applies a given ModDisplay to this DisplayModel
    /// </summary>
    /// <typeparam name="T">The type of ModDisplay</typeparam>
    public static void ApplyDisplay<T>(this DisplayModel displayModel) where T : ModDisplay
    {
        ModContent.GetInstance<T>().Apply(displayModel);
    }
}