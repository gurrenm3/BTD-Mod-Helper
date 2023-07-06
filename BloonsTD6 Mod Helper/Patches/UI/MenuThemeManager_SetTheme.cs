using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Internal;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.TowerSelectionMenu.TowerSelectionMenuThemes;
using UnityEngine;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(MenuThemeManager), nameof(MenuThemeManager.SetTheme))]
internal class MenuThemeManager_SetTheme
{
    [HarmonyPostfix]
    internal static void Postfix(MenuThemeManager __instance, BaseTSMTheme newTheme)
    {
        if (__instance.selectionMenu.Is(out TowerSelectionMenu menu) &&
            menu.selectedTower.Def.GetModTower()?.ModTowerSet is ModTowerSet modTowerSet &&
            !menu.selectedTower.IsParagon &&
            newTheme.Is(out TSMThemeDefault defaultTheme))
        {
            var texture = ResourceHandler.GetTexture(ModContent.GetId(modTowerSet.mod, modTowerSet.Portrait));
            if (texture != null)
            {
                var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f), 5.4f, 0, SpriteMeshType.FullRect, new Vector4(22.5f, 22.5f, 22.5f, 22.5f));
                defaultTheme.towerBackgroundImage.sprite = sprite;
            }
        }
    }
}