using System.Linq;

using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;

using UnityEngine;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TowerSetBgSprites), nameof(TowerSetBgSprites.GetSprite))]
internal class TowerSetBgSprites_GetSprite {
    [HarmonyPostfix]
    internal static void Postfix(string name, ref Sprite __result) {
        if (ModContent.GetContent<ModTowerSet>().FirstOrDefault(set => set.Id == name) is ModTowerSet modTowerSet) {
            __result = ModContent.GetSprite(modTowerSet.mod, modTowerSet.Container);
        }
    }
}