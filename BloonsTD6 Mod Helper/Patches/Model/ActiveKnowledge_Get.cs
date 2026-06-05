using BTD_Mod_Helper.Api.Scenarios;
using Il2CppAssets.Scripts.Data.Knowledge;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Gameplay.Mods;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppSystem.Collections.Generic;

namespace BTD_Mod_Helper.Patches;

/// <summary>
/// Make DisableMonkeyKnowledgeModModel actually work for ModGameModes
/// </summary>
[HarmonyPatch(typeof(ActiveKnowledge), nameof(ActiveKnowledge.Get), typeof(ActiveKnowledge), typeof(GameModel))]
internal static class ActiveKnowledge_Get
{
    [HarmonyPostfix]
    internal static void Postifx(HashSet<string> __result)
    {
        if (!string.IsNullOrEmpty(InGameData.Editable?.selectedMode) &&
            ModGameMode.Cache.TryGetValue(InGameData.Editable.selectedMode, out var modGameMode) &&
            modGameMode.model?.mutatorMods?.Any(model => model.Is<DisableMonkeyKnowledgeModModel>()) == true)
        {
            __result.Clear();
        }
    }
}