using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// MainHudLeftAlign extensions
/// </summary>
public static class MainHudLeftAlignExt
{
    /// <inheritdoc cref="MainHudLeftAlignExt"/>
    extension(MainHudLeftAlign)
    {
        /// <summary>
        /// Gets the main MainHudLeftAlign instance
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static MainHudLeftAlign instance => InGame.instance?.playerContexts?.FirstOrDefault().hudLeft;
    }
}