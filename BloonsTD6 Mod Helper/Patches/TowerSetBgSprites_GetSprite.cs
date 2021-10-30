using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using HarmonyLib;
using UnityEngine;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(TowerSetBgSprites), nameof(TowerSetBgSprites.GetSprite))]
    internal class TowerSetBgSprites_GetSprite
    {
        [HarmonyPostfix]
        internal static void Postfix(string name, ref Sprite __result)
        {
            if (ModContent.GetInstances<ModTowerSet>().FirstOrDefault(set => set.Id == name) is ModTowerSet modTowerSet)
            {
                __result = ModContent.GetSprite(modTowerSet.mod, modTowerSet.Container);
            }
        }
    }



}