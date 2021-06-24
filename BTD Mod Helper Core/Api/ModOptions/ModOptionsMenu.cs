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
    internal class ModOptionsMenu
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
        }

        private void PopulateModOptions(BloonsMod bloonsMod)
        {
            optionsList.anchoredPosition = new Vector2(optionsList.anchoredPosition.x, 0);
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

            var count = bloonsMod.ModSettings.Values.Count;
            for (var i = 0; i < count; i++)
            {
                var modSetting = bloonsMod.ModSettings.ElementAt(i).Value;
                var modOption = modSetting.ConstructModOption2(instantiatedUI.gameObject);

                var yCoord = ButtonOption.GetOriginalAsset(instantiatedUI).position.y - (i * 100);
                modOption.SetLocation(yCoord);
            }

            // increase size of scroll height
            optionsList.sizeDelta = new Vector2(0, 100 * count * 5);
        }

        private void PopulateModListItems(BloonsMod bloonsMod, int index)
        {
            var item = GameObject.Instantiate(modListItem, modList);
            
            var button = item.GetComponentInChildren<Button>();
            button.onClick.AddListener(() => PopulateModOptions(bloonsMod));
            button.GetComponentInChildren<Text>().text = bloonsMod.GetModName();

            item.gameObject.transform.position -= new Vector3(0, index * 65);
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
