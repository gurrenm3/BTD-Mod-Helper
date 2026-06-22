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
        if (!__instance.PlayerContext.towerSelectionMenu.Is(out TowerSelectionMenu menu) ||
            menu.selectedTower.Def.GetModTower()?.ModTowerSet is not ModTowerSet modTowerSet ||
            menu.selectedTower.IsParagon ||
            !newTheme.Is(out TSMThemeDefault defaultTheme)) return;

        var id = ModContent.GetId(modTowerSet.mod, modTowerSet.Portrait);
        var texture = ResourceHandler.GetTexture(id);

        if (!ResourceHandler.SpriteCache.TryGetValue(id, out var sprite) || sprite == null || sprite.border == Vector4.zero)
        {
            var factor = texture.width / 256f;
            sprite = ResourceHandler.SpriteCache[id] = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f), 10.8f * factor, 0, SpriteMeshType.FullRect,
                factor * 45 * Vector4.one);
        }

        TaskScheduler.ScheduleTask(() => defaultTheme.towerBackgroundImage.sprite = sprite);
    }
}