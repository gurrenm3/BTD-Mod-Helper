using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.BTD6_UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Menus;
using Object = UnityEngine.Object;

namespace BTD_Mod_Helper.Api.ModOptions
{
    internal class ShowModOptions_Button
    {
#if BloonsTD6
        public ModOptionsMenu modOptionsMenu;
        public static GameObject settingsUI_Canvas;
        public Button instantiatedButton;
        public Button optionsButton;

        public ShowModOptions_Button()
        {
        }

        public void Init()
        {
#if BloonsTD6
            var scene = SceneManager.GetSceneByName("SettingsUI");
#elif BloonsAT
            var scene = SceneManager.GetSceneByName("UI-Settings");
#endif
            var rootGameObjects = scene.GetRootGameObjects();
            settingsUI_Canvas = rootGameObjects[0];
            optionsButton = ModOptionsMenu.CanvasGO.transform.Find("ModOptionsButton/Button").GetComponent<Button>();

            var twitch = settingsUI_Canvas.GetComponentInChildren<TwitchSettingsButton>().transform;
            var newObject = Object.Instantiate(twitch.gameObject, settingsUI_Canvas.transform);

            newObject.RemoveComponent<TwitchSettingsButton>();
            instantiatedButton = newObject.GetComponentInChildren<Button>();

            newObject.GetComponentInChildren<NK_TextMeshProUGUI>().localizeKey = "Mod Options";
            newObject.GetComponentInChildrenByName<Image>("Panel")
                .SetSprite(ModContent.GetSpriteReference<MelonMain>("ModSettings"));
            newObject.GetComponentInChildrenByName<Image>("Image").Destroy();

            instantiatedButton.onClick.AddListener(OptionButtonClicked);

            var matchPosition = newObject.AddComponent<MatchLocalPosition>();
            matchPosition.transformToCopy = twitch;
            matchPosition.offset = new Vector3(-400, 0, 0);
        }

        public void OptionButtonClicked()
        {
            //modOptionsMenu = new ModOptionsMenu();
            //instantiatedButton.gameObject.SetActive(false);
            ModGameMenu.Open<OldModSettingsMenu>("Test");
        }
#endif
    }
}