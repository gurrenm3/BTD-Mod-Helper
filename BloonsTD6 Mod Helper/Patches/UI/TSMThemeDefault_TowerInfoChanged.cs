using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Towers;
using UnityEngine;

namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(TSMThemeDefault), nameof(TSMThemeDefault.TowerInfoChanged))]
internal class TSMThemeDefault_TowerInfoChanged
{
    [HarmonyPostfix]
    internal static void Postfix(TSMThemeDefault __instance, TowerToSimulation tower)
    {
        if (tower.Def.GetModTower()?.ModTowerSet is ModTowerSet modTowerSet && !tower.IsParagon)
        {
            var texture = ResourceHandler.GetTexture(modTowerSet.PortraitReference.GUID);
            if (texture != null)
            {
                var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f), 5.4f, 0, SpriteMeshType.FullRect, new Vector4(22.5f, 22.5f, 22.5f, 22.5f));
                __instance.towerBackgroundImage.sprite = sprite;
            }
        }
    }
}