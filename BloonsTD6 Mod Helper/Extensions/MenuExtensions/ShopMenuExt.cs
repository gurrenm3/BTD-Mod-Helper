using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.RightMenu;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// ShopMenu extensions
/// </summary>
public static class ShopMenuExt
{
    /// <inheritdoc cref="ShopMenuExt"/>
    extension(ShopMenu)
    {
        /// <summary>
        /// Gets the main ShopMenu instance
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static ShopMenu instance => InGame.instance?.playerContexts?.FirstOrDefault().shopMenu;
    }
}