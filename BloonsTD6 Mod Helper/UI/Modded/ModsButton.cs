using System.Linq;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.UI.Menus;
using Il2CppAssets.Scripts.Unity.UI_New.Main;
using Il2CppAssets.Scripts.Unity.UI_New.Main.Home;
using Il2CppAssets.Scripts.Utils;
using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.UI.Modded;

internal static class ModsButton
{
    private static SpriteReference Sprite => ModContent.GetSpriteReference<MelonMain>("ModsBtn");

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
        modsButton.GetComponentInChildrenByName<Image>("Button").SetSprite(Sprite);
        modsButton.GetComponentInChildren<NK_TextMeshProUGUI>().localizeKey = $"   Mods ({ModHelper.Melons.Count()})";
        modsButton.GetComponentInChildren<Button>().SetOnClick(() => ModGameMenu.Open<ModsMenu>());

        var indicator = modsButton.GetComponentInChildrenByName<RectTransform>("ParagonAvailable");
        indicator.gameObject.SetActive(ModHelperData.All.Any(data => data.UpdateAvailable));
        indicator.Find("Glow").GetComponent<Image>().color = Color.green;
        indicator.Find("Icon").GetComponent<Image>().SetSprite(VanillaSprites.UpgradeBtn);

        var matchLocalPosition = modsButton.transform.GetChild(0).gameObject.AddComponent<MatchLocalPosition>();
        matchLocalPosition.transformToCopy = copyLocalFrom.transform.GetChild(0);

        var rect = mainMenuTransform.rect;
        var aspectRatio = rect.width / rect.height;

        if (aspectRatio < 1.5)
        {
            matchLocalPosition.offset = new Vector3(-560, 0);
            matchLocalPosition.scale = new Vector3(1, 3.33f, 1);
        }
        else if (aspectRatio < 1.7)
        {
            matchLocalPosition.offset = new Vector3(-450, 0);
            matchLocalPosition.scale = new Vector3(1, 3f, 1);
        }
        else
        {
            matchLocalPosition.offset = new Vector3(-200, 0);
        }
    }
}