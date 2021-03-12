using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BTD_Mod_Helper.Api.InGame_Mod_Options
{
    public class ModOptionsMenu
    {
        private static AssetBundle assetBundle;
        private static GameObject canvasGo;
        
        private GameObject instantiatedUI;

        private GameObject modList;
        private GameObject optionsList;
        private GameObject uiElementsContainer;

        public ModOptionsMenu()
        {
            if (assetBundle is null)
                assetBundle = AssetBundle.LoadFromMemory(Properties.Resources.modoptions);

            if (canvasGo is null)
                canvasGo = assetBundle.LoadAsset("Canvas").Cast<GameObject>();

            instantiatedUI = GameObject.Instantiate(canvasGo);
            modList = instantiatedUI.transform.Find("ModOptions/ModList ScrollRect/ModList Container").GetComponent<GameObject>();
            optionsList = instantiatedUI.transform.Find("ModOptions/ModOptions ScrollRect/ModOptions Container").GetComponent<GameObject>();
            uiElementsContainer = instantiatedUI.transform.Find("ModOptions/UI Elements").GetComponent<GameObject>();

            var button = new ButtonOption(instantiatedUI);
            var slider = new SliderOption(instantiatedUI);
            var checkbox = new CheckboxOption(instantiatedUI);
            var input = new InputOption(instantiatedUI);
        }
    }
}
