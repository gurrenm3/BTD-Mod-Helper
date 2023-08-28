using System.Linq;
using BTD_Mod_Helper.Api.Bloons.Bosses;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
namespace BTD_Mod_Helper.Patches.Bosses.Patches;

[HarmonyPatch(typeof(Il2CppAssets.Scripts.Unity.UI_New.UI), nameof(Il2CppAssets.Scripts.Unity.UI_New.UI.LoadGame))]
internal static class UI_LoadGame
{
    [HarmonyPostfix]
    private static void Postfix(MapSaveDataModel mapSaveData)
    {
        if (InGameData.CurrentGame == null || InGameData.CurrentGame.gameEventId != ModBoss.EventId || mapSaveData is null)
        {
            return;
        }

        if (ModBoss.Cache.TryGetValue((int) InGameData.CurrentGame.bossData.bossBloon, out var boss))
        {
            var bloon = mapSaveData.bloons.FirstOrDefault(bloonSaveDataModel =>
                boss.tiers.Exists(modBossTier => modBossTier.bloonModel.id == bloonSaveDataModel.modelId));
            if (bloon is null)
            {
                return;
            }
            boss.CurrentTier = boss.tiers.First(modBossTier => modBossTier.bloonModel.id == bloon.modelId);
        }
    }
}