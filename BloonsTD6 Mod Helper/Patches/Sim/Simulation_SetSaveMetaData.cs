using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Simulation;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppSystem.Collections.Generic;

namespace BTD_Mod_Helper.Patches.Sim;

[HarmonyPatch(typeof(Simulation), nameof(Simulation.SetSaveMetaData))]
internal static class Simulation_SetSaveMetaData
{
    [HarmonyPostfix]
    internal static void Postfix(Simulation __instance, Dictionary<string, string> metaData)
    {
        var inventory = __instance.GetTowerInventory(InGame.Bridge.MyPlayerNumber);

        foreach (var modFakeTower in ModContent.GetContent<ModFakeTower>().Where(tower => tower.TowerInventoryEnabled))
        {
            if (metaData.TryGetValue(modFakeTower.Id, out var c) && int.TryParse(c, out var count))
            {
                inventory.towerCounts[modFakeTower.Id] = count;
            }
        }
    }
}