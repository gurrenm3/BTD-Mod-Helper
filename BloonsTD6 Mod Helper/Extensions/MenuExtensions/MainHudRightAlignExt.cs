using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// MainHudRightAlign extensions
/// </summary>
public static class MainHudRightAlignExt
{
    /// <inheritdoc cref="MainHudRightAlignExt"/>
    extension(MainHudRightAlign)
    {
        /// <summary>
        /// Gets the main MainHudRightAlign instance
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static MainHudRightAlign instance => InGame.instance?.playerContexts?.FirstOrDefault().hudRight;
    }
}