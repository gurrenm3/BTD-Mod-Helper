using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using UnityEngine;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TowerSetBgSprites), nameof(TowerSetBgSprites.GetSprite))]
internal class TowerSetBgSprites_GetSprite
{
    [HarmonyPrefix]
    internal static bool Prefix(TowerSet ts, ref Sprite __result)
    {
        if (ModContent.GetContent<ModTowerSet>().Find(set => set.Set == ts) is ModTowerSet modTowerSet)
        {
            __result = ModContent.GetSprite(modTowerSet.mod, modTowerSet.Container);
            return false;
        }

        return true;
    }
}