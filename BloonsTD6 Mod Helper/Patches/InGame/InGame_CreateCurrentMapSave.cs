using System.Collections.Generic;
using System.Linq;
using BTD_Mod_Helper.Api.Bloons;
using Il2CppAssets.Scripts.Simulation.Bloons;
namespace BTD_Mod_Helper.Patches;


[HarmonyPatch(typeof(Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame), nameof(Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame.CreateCurrentMapSave))]
internal class InGame_CreateCurrentMapSave
{
    [HarmonyPrefix]
    internal static bool Prefix() => Il2CppAssets.Scripts.Unity.UI_New.InGame.InGame.instance.GetAllBloonToSim().Exists(bloon => ModBoss.Cache.ContainsKey(bloon.Def.name));
}