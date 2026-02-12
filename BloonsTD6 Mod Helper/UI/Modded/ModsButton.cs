using System;
using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.UI;
using BTD_Mod_Helper.UI.Menus;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.UI_New.Main;
using Il2CppAssets.Scripts.Unity.UI_New.Main.Home;
using Il2CppNinjaKiwi.Common;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using UnityEngine;
using UnityEngine.UI;
using ModHelperData = BTD_Mod_Helper.Api.Data.ModHelperData;
using Object = UnityEngine.Object;
namespace BTD_Mod_Helper.UI.Modded;

internal static class ModsButton
{
    internal static readonly string Mods = ModHelper.Localize(nameof(Mods), "Mods");

    private static MatchLocalPosition currentMatchLocalPosition;

    private static bool createdBefore;

    public static void Create(MainMenu mainMenu)
    {
        var mainMenuTransform = mainMenu.transform.Cast<RectTransform>();
        var bottomGroup = mainMenuTransform.FindChild("BottomButtonGroup");
        var baseButton = bottomGroup.FindChild("Monkeys").gameObject;
        var copyLocalFrom = bottomGroup.FindChild("Knowledge").gameObject;
        bottomGroup.TranslateScaled(new Vector3(300, 0, 0));

        var modsButton = baseButton.Duplicate(bottomGroup);
        modsButton.name = "Mods";
        modsButton.transform.localPosition = new Vector3(1600, 0, 0);
        modsButton.RemoveComponent<PipEventChecker>();
        modsButton.GetComponentInChildrenByName<RectTransform>("NewRibbon").gameObject.SetActive(false);
        modsButton.GetComponentInChildrenByName<Image>("Button").SetSprite(ModHelperSprites.ModsBtn);
        modsButton.GetComponentInChildren<NK_TextMeshProUGUI>().localizeKey = $"   [{Mods}] ({ModHelper.Melons.Count()})";
        modsButton.GetComponentInChildren<Button>().SetOnClick(() => ModGameMenu.Open<ModsMenu>());

        var indicator = modsButton.GetComponentInChildrenByName<RectTransform>("ParagonAvailable");
        indicator.gameObject.SetActive(ModHelperData.All.Any(data => data.UpdateAvailable));
        indicator.Find("Glow").GetComponent<Image>().color = Color.green;
        indicator.Find("Icon").GetComponent<Image>().SetSprite(VanillaSprites.UpgradeBtn);

        var error = indicator.gameObject.Duplicate(indicator.parent);
        error.transform.localPosition = error.transform.localPosition with {x = error.transform.localPosition.x * -1};
        error.gameObject.SetActive(ModHelper.Mods.Any(mod => mod.loadErrors.Any()));
        error.transform.Find("Glow").gameObject.SetActive(false);
        error.transform.Find("Icon").GetComponent<Image>().SetSprite(VanillaSprites.NoticeBtn);
        error.GetComponentInChildren<CustomScaleAnimator>().enabled = false;

        currentMatchLocalPosition = modsButton.transform.GetChild(0).gameObject.AddComponent<MatchLocalPosition>();
        currentMatchLocalPosition.transformToCopy = copyLocalFrom.transform.GetChild(0);

        var screenSize = Object.FindObjectOfType<ScreenResizeDetector>();

        SetPosition(screenSize.currentWidth, screenSize.currentHeight);

        if (!createdBefore)
        {
            Messaging<OnScreenSizeDidChange>.Register(new Action<int, int, bool>(SetPosition));
        }

        createdBefore = true;
    }

    private static void SetPosition(int width, int height, bool isFullscreen = false)
    {
        if (currentMatchLocalPosition == null) return;

        switch (AspectRatios.From(width, height))
        {
            case AspectRatio.NonWidescreen:
                currentMatchLocalPosition.offset = new Vector3(-660, 0);
                currentMatchLocalPosition.scale = new Vector3(1, 3.33f, 1);
                break;
            case AspectRatio.TallWidescreen:
                currentMatchLocalPosition.offset = new Vector3(-460, 0);
                currentMatchLocalPosition.scale = new Vector3(1, 3f, 1);
                break;
            case AspectRatio.Widescreen:
                currentMatchLocalPosition.offset = new Vector3(-200, 0);
                currentMatchLocalPosition.scale = new Vector3(1, 1f, 1);
                break;
        }
    }
}