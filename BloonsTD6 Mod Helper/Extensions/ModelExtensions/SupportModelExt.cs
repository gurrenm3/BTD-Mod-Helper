using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extension methods for support models
/// </summary>
public static class SupportModelExt
{
    /// <summary>
    /// Makes a support model use a particular ModBuffIcon as its display
    /// </summary>
    /// <param name="supportModel">The support model to apply to</param>
    /// <typeparam name="T">The ModBuffIcon type</typeparam>
    public static SupportModel ApplyBuffIcon<T>(this SupportModel supportModel) where T : ModBuffIcon
    {
        ModContent.GetInstance<T>().ApplyTo(supportModel);
        return supportModel;
    }
}