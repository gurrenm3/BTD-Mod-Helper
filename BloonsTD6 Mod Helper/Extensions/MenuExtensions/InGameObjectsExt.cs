using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// InGameObjects extensions
/// </summary>
public static class InGameObjectsExt
{
    /// <inheritdoc cref="InGameObjectsExt"/>
    extension(InGameObjects)
    {
        /// <summary>
        /// Gets the main shop menu instance
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public static InGameObjects instance => InGame.instance?.playerContexts?.FirstOrDefault().inGameObjects;
    }
}