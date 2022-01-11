using Assets.Scripts.Unity.UI_New.Main;
using Assets.Scripts.Unity.UI_New.Main.Home;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.BTD6_UI;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.ModMenu
{
    internal static class ModsButton
    {
        private static SpriteReference Sprite => ModContent.GetSpriteReference<MelonMain>("ModsBtn");

        public static void Create(MainMenu mainMenu)
        {
            var mainMenuTransform = mainMenu.transform.Cast<RectTransform>();
            var bottomGroup = mainMenuTransform.FindChild("BottomButtonGroup");
            var baseButton = bottomGroup.FindChild("Knowledge").gameObject;
            bottomGroup.TranslateScaled(new Vector3(300, 0 ,0));

            var modsButton = baseButton.Duplicate(bottomGroup);
            modsButton.RemoveComponent<KnowledgeEnabledChecker>();
            modsButton.GetComponentInChildrenByName<RectTransform>("MKindicator").gameObject.Destroy();
            modsButton.GetComponentInChildrenByName<RectTransform>("NewTowerDot").gameObject.Destroy();
            modsButton.GetComponentInChildrenByName<Image>("Button").SetSprite(Sprite);
            modsButton.GetComponentInChildren<NK_TextMeshProUGUI>().localizeKey = $"   Mods ({MelonHandler.Mods.Count})";
            modsButton.GetComponentInChildren<Button>().SetOnClick(() =>
            {
                ModHelper.Msg("Clicky button!");
                ModGameMenu.Open<ModsMenu>();
            });

            var matchLocalPosition = modsButton.transform.GetChild(0).gameObject.AddComponent<MatchLocalPosition>();
            matchLocalPosition.transformToCopy = baseButton.transform.GetChild(0);

            var rect = mainMenuTransform.rect;
            var aspectRatio = rect.width / rect.height;

            if (aspectRatio < 1.5)
            {
                matchLocalPosition.offset = new Vector3(-360, 0);
                matchLocalPosition.scale = new Vector3(1, 3.33f, 1);
            } else if (aspectRatio < 1.7)
            {
                matchLocalPosition.offset = new Vector3(-250, 0);
                matchLocalPosition.scale = new Vector3(1, 3f, 1);
            }
        }
    }
}