using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.UI.Menus;
using BTD_Mod_Helper.UI.Modded;
using Il2CppAssets.Scripts.Unity.UI_New.Pause;
using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(PauseScreen), nameof(PauseScreen.Open))]
internal static class PauseScreen_Open
{
    [HarmonyPostfix]
    private static void Postfix(PauseScreen __instance)
    {
        ModHelper.PerformHook(mod => mod.OnPauseScreenOpened(__instance));
        SessionData.Instance.IsPaused = true;

        if (__instance.sidePanel.HasComponent<ContentSizeFitter>()) return;

        __instance.sidePanel.transform.localPosition = __instance.sidePanel.transform.localPosition with
        {
            y = 0
        };

        var buttonGroup = __instance.sidePanel.transform.GetChild(0).gameObject;

        for (var i = 0; i < buttonGroup.transform.childCount; i++)
        {
            var child = buttonGroup.transform.GetChild(i).Cast<RectTransform>();
            var layout = child.gameObject.AddComponent<LayoutElement>();
            layout.preferredWidth = child.rect.width;
            layout.preferredHeight = child.rect.height;
        }

        var buttonGroupLayout = buttonGroup.GetComponent<VerticalLayoutGroup>();
        buttonGroupLayout.padding = new RectOffset
        {
            bottom = 150,
            left = 50,
            right = 100,
            top = 75
        };

        var buttonGroupSize = buttonGroup.AddComponent<ContentSizeFitter>();
        buttonGroupSize.verticalFit = ContentSizeFitter.FitMode.PreferredSize;

        var sidePanelLayout = __instance.sidePanel.AddComponent<VerticalLayoutGroup>();
        sidePanelLayout.childAlignment = TextAnchor.UpperCenter;
        sidePanelLayout.childForceExpandHeight = false;
        sidePanelLayout.childForceExpandWidth = false;

        var sidePanelSize = __instance.sidePanel.AddComponent<ContentSizeFitter>();
        sidePanelSize.verticalFit = ContentSizeFitter.FitMode.PreferredSize;


        var modsBtn = buttonGroup.GetComponentInChildrenByName<RectTransform>("Hotkeys").gameObject
            .Duplicate(buttonGroup.transform);
        modsBtn.name = "ModsBtn";

        var modsButton = modsBtn.GetComponent<Button>();
        modsButton.SetOnClick(() => ModGameMenu.Open<ModsMenu>());

        var image = modsBtn.GetComponentInChildrenByName<Image>("Image");
        image.transform.Cast<RectTransform>().sizeDelta = new Vector2(180, 180);

        var sprite = ModContent.GetSprite<MelonMain>(nameof(ModHelperSprites.IconMinimal));
        sprite.texture.mipMapBias = 0;
        image.SetSprite(sprite);

        var modsText = modsBtn.GetComponentInChildren<NK_TextMeshProUGUI>();
        modsText.localizeKey = $"[{ModsButton.Mods}] ({ModHelper.Melons.Count()})";
        modsText.SetText(ModsButton.Mods.Localize());

    }
}