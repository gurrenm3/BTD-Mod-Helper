using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppSystem.Collections.Generic;
namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(Simulation), nameof(Simulation.GetSaveMetaData))]
internal static class Simulation_GetSaveMetaData
{
    [HarmonyPostfix]
    internal static void Postfix(Simulation __instance, Dictionary<string, string> metaData)
    {
        var inventory = __instance.GetTowerInventory(InGame.Bridge.MyPlayerNumber);

        foreach (var modFakeTower in ModContent.GetContent<ModFakeTower>())
        {
            if (inventory.towerMaxes.TryGetValue(modFakeTower.Id, out var max))
            {
                metaData[modFakeTower.Id] = max.ToString();
            }
        }
    }
}