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

namespace BTD_Mod_Helper.Api.ModOptions
{
    public class ModOptionsMenu
    {
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
                if (canvasGo is null)
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

        public ModOptionsMenu()
        {
            modOptionsWindow = CanvasGO.GetComponentInChildrenByName<RectTransform>("ModOptions");
#if BloonsTD6
            var scene = SceneManager.GetSceneByName("SettingsUI");
#elif BloonsAT
            var scene = SceneManager.GetSceneByName("UI-Settings");
#endif
            var rootGameObjects = scene.GetRootGameObjects();
            var mainMenuCanvas = rootGameObjects[0];
            instantiatedUI = GameObject.Instantiate(modOptionsWindow.gameObject, mainMenuCanvas.transform);

            instantiatedUI.transform.localScale = new Vector3(2, 2);

            modList = instantiatedUI.GetComponentInChildrenByName<RectTransform>("ModList Container");
            optionsList = instantiatedUI.GetComponentInChildrenByName<RectTransform>("ModOptions Container");
            uiElementsContainer = instantiatedUI.GetComponentInChildrenByName<RectTransform>("UI Elements");
            modListItem = instantiatedUI.GetComponentInChildrenByName<RectTransform>("ModList Item");

            HideOriginalAssets(instantiatedUI);

            for (int i = 0; i < MelonHandler.Mods.OfType<BloonsMod>().Count(); i++)
            {
                var bloonsMod = MelonHandler.Mods.OfType<BloonsMod>().ElementAt(i);
                if (!bloonsMod.ModSettings.Any()) continue;

                PopulateModListItems(bloonsMod, i);
            }
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
                        GameObject.Destroy(item);
                    }
                }
            }

            for (int i = 0; i < bloonsMod.ModSettings.Values.Count; i++)
            {
                var modSetting = bloonsMod.ModSettings.ElementAt(i).Value;
                var modOption = modSetting.ConstructModOption2(instantiatedUI.gameObject);

                var yCoord = ButtonOption.GetOriginalAsset(instantiatedUI).position.y - (i * 100);
                modOption.SetLocation(yCoord);
            }
        }

        private void PopulateModListItems(BloonsMod bloonsMod, int index)
        {
            var item = GameObject.Instantiate(modListItem, modList);

            var button = item.GetComponentInChildren<Button>();
            button.onClick.AddListener(() => PopulateModOptions(bloonsMod));
            button.GetComponentInChildren<Text>().text = bloonsMod.GetModName();

            var height = button.GetComponent<RectTransform>().rect.height;
            item.gameObject.transform.position = new Vector3(item.gameObject.transform.position.x, item.gameObject.transform.position.y - (index * height));
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
    }
}
