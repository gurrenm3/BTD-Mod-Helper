using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Unity.UI_New;
using Assets.Scripts.Unity.UI_New.Popups;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Patches;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace BTD_Mod_Helper.Api.ModOptions
{
    internal class ModOptionsMenu
    {
#if BloonsTD6
        private static AssetBundle assetBundle;

        public static AssetBundle AssetBundle
        {
            get
            {
                if (assetBundle is null)
                    assetBundle = AssetBundle.LoadFromMemory(Properties.Resources.modoptions);
                return assetBundle;
            }
            set { assetBundle = value; }
        }


        private static GameObject canvasGo;

        public static GameObject CanvasGO
        {
            get
            {
                if (canvasGo == null || canvasGo.transform == null)
                    canvasGo = AssetBundle.LoadAsset("Canvas").Cast<GameObject>();
                return canvasGo;
            }
            set { canvasGo = value; }
        }


        internal RectTransform modOptionsWindow;
        private GameObject instantiatedUI;

        private RectTransform modList;
        private RectTransform optionsList;
        private RectTransform uiElementsContainer;

        private RectTransform modListItem;

        private Button doneButton;

        public ModOptionsMenu()
        {
            modOptionsWindow = CanvasGO.GetComponentInChildrenByName<RectTransform>("ModOptions");
#if BloonsTD6
            var scene = SceneManager.GetSceneByName("SettingsUI");
#elif BloonsAT // Keep this so we can add support for BloonsAT in the future
            var scene = SceneManager.GetSceneByName("UI-Settings");
#endif
            var rootGameObjects = scene.GetRootGameObjects();
            var mainMenuCanvas = rootGameObjects[0];
            instantiatedUI = Object.Instantiate(modOptionsWindow.gameObject, mainMenuCanvas.transform);

            modList = instantiatedUI.GetComponentInChildrenByName<RectTransform>("ModList Container");
            optionsList = instantiatedUI.GetComponentInChildrenByName<RectTransform>("ModOptions Container");
            uiElementsContainer = instantiatedUI.GetComponentInChildrenByName<RectTransform>("UI Elements");
            modListItem = instantiatedUI.GetComponentInChildrenByName<RectTransform>("ModList Item");


            HideOriginalAssets(instantiatedUI);

            var mods = MelonHandler.Mods.OfType<BloonsMod>().Where(mod => mod.ModSettings.Any()).ToList();

            for (var i = 0; i < mods.Count; i++)
            {
                var bloonsMod = mods.ElementAt(i);
                PopulateModListItems(bloonsMod, i);
            }


            doneButton = instantiatedUI.GetComponentInChildrenByName<Button>("DoneButton");

            doneButton.AddOnClick(() =>
            {
                Object.Destroy(instantiatedUI);
                MelonMain.modsButton.instantiatedButton.gameObject.SetActive(true);
                ModSettingsHandler.SaveModSettings(ModContent.GetInstance<MelonMain>().GetModSettingsDir());
            });

            MelonMain.PerformHook(mod => mod.OnModOptionsOpened());
        }

        private void PopulateModOptions(BloonsMod bloonsMod)
        {
            var options = optionsList.GetComponentsInChildren<Transform>();
            if (options.Any(option => option.name != "ModOptions Container"))
            {
                foreach (var item in options)
                {
                    if (item.name != "ModOptions Container")
                    {
                        item.gameObject.SetActive(false);
                        Object.Destroy(item);
                    }
                }
            }

            var count = bloonsMod.ModSettings.Values.Count;
            for (var i = 0; i < count; i++)
            {
                var modSetting = bloonsMod.ModSettings.ElementAt(i).Value;
                modSetting.ConstructModOption(instantiatedUI.gameObject);
            }
        }

        private void PopulateModListItems(BloonsMod bloonsMod, int index)
        {
            var item = Object.Instantiate(modListItem, modList);

            var button = item.GetComponentInChildren<Button>();
            button.onClick.AddListener(() => PopulateModOptions(bloonsMod));
            button.GetComponentInChildren<Text>().text = bloonsMod.Info.Name;

            item.Show();
        }

        private void HideOriginalAssets(GameObject parent)
        {
            ButtonOption.GetOriginalAsset(parent).Hide();
            SliderOption.GetOriginalAsset(parent).Hide();
            InputOption.GetOriginalAsset(parent).Hide();
            CheckboxOption.GetOriginalAsset(parent).Hide();
            modListItem.Hide();
        }
#endif
    }
}