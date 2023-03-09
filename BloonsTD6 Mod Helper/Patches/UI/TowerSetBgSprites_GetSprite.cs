using Il2CppAssets.Scripts.Models.TowerSets;
using UnityEngine;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TowerSetBgSprites), nameof(TowerSetBgSprites.GetSprite))]
internal class TowerSetBgSprites_GetSprite
{
    [HarmonyPostfix]
    internal static void Postfix(TowerSet ts, ref Sprite __result)
    {
        // TODO fix modded tower sets
        /*if (ModContent.GetContent<ModTowerSet>().FirstOrDefault(set => set.Id == name) is ModTowerSet modTowerSet)
        {
            __result = ModContent.GetSprite(modTowerSet.mod, modTowerSet.Container);
        }*/
    }
}