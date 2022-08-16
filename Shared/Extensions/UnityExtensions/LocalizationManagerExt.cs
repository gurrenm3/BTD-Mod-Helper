#if BloonsAT
using Assets.Scripts.Unity.Localization;
#elif BloonsTD6
using NinjaKiwi.Common;

#endif
using Il2CppSystem.Collections.Generic;

namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extension methods for the Localization Manager.
/// </summary>
public static class LocalizationManagerExt {
    /// <summary>
    /// Returns the text table that is currently in use.
    /// </summary>
    /// <param name="localization"></param>
    /// <returns></returns>
    public static Dictionary<string, string> GetTextTable(this LocalizationManager localization) {
#if BloonsTD6
        return localization.textTable;
#elif BloonsAT
            return localization.textTable.value.textLookup;
#endif
    }
}