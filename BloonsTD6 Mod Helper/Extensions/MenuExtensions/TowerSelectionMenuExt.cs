using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// TowerSelectionMenu extensions
/// </summary>
public static class TowerSelectionMenuExt
{
    /// <inheritdoc cref="TowerSelectionMenuExt"/>
    extension(TowerSelectionMenu)
    {
        /// <summary>
        /// Gets the main TowerSelectionMenu instance
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static TowerSelectionMenu instance => InGame.instance?.playerContexts?.FirstOrDefault().towerSelectionMenu;
    }
}