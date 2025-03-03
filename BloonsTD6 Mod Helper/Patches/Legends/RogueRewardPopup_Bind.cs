using BTD_Mod_Helper.Api.Legends;
using Il2CppAssets.Scripts.Data.Legends;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
namespace BTD_Mod_Helper.Patches;

[HarmonyPatch(typeof(RogueRewardPopup), nameof(RogueRewardPopup.Bind))]
internal static class RogueRewardPopup_Bind
{
    [HarmonyPostfix]
    internal static void Postfix(RogueRewardPopup __instance, RogueLoot loot)
    {
        if (loot.Is(out ArtifactLoot artifactLoot))
        {
            var icon = __instance.rewardLootDisplay.GetComponentInChildren<RogueArtifactDisplayIcon>();
            ModArtifact.HandleSmallIcon(icon, artifactLoot.baseId);
        }
    }
}