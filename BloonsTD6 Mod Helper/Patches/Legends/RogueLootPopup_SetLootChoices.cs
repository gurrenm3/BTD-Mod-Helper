using System.Linq;
using BTD_Mod_Helper.Api.Legends;
using Il2CppAssets.Scripts.Data.Legends;
using Il2CppAssets.Scripts.Unity.UI_New.Legends;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;

namespace BTD_Mod_Helper.Patches;

/// <summary>
/// Fix the stack count on RogueLootPopup screen
/// </summary>
[HarmonyPatch(typeof(RogueLootPopup), nameof(RogueLootPopup.SetLootChoices))]
internal static class RogueLootPopup_SetLootChoices
{
    internal static RogueLoot lastRogueLoot;
    internal static bool hijackingLootButtonClicked;

    [HarmonyPostfix]
    internal static void Postfix(RogueLootPopup __instance)
    {
        var choices = __instance.activeButtons.ToArray()
            .Select(o => o.GetComponentInChildren<RogueArtifactDisplayIcon>())
            .Where(icon => icon != null)
            .ToArray();

        hijackingLootButtonClicked = true;
        foreach (var rogueArtifactDisplayIcon in choices)
        {
            lastRogueLoot = null;
            rogueArtifactDisplayIcon.selectBtn.onClick.Invoke();
            if (lastRogueLoot.Is(out ArtifactLoot artifactLoot))
            {
                ModArtifact.HandleSmallIcon(rogueArtifactDisplayIcon, artifactLoot.baseId);
            }
        }
        hijackingLootButtonClicked = false;
    }
}

/// <summary>
/// Hijack LootButtonClicked since RogueLoot classes aren't stored in the buttons after initializing
/// </summary>
[HarmonyPatch(typeof(RogueLootPopup), nameof(RogueLootPopup.LootButtonClicked))]
internal static class RogueLootPopup_LootButtonClicked
{
    [HarmonyPrefix]
    internal static bool Prefix(RogueLoot loot)
    {
        RogueLootPopup_SetLootChoices.lastRogueLoot = loot;
        return !RogueLootPopup_SetLootChoices.hijackingLootButtonClicked;
    }
}