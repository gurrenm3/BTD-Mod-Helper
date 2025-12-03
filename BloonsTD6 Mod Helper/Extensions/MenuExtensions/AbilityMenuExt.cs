using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.AbilitiesMenu;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// AbilityMenu extensions
/// </summary>
public static class AbilityMenuExt
{
    /// <inheritdoc cref="AbilityMenuExt"/>
    extension(AbilityMenu)
    {
        /// <summary>
        /// Gets the main AbilityMenu instance
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static AbilityMenu instance => InGame.instance?.playerContexts?.FirstOrDefault().abilityMenu;
    }
}