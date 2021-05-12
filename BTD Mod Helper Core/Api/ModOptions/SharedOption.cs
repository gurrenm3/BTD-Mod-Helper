using BTD_Mod_Helper.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace BTD_Mod_Helper.Api.ModOptions
{
    public class SharedOption
    {
        private readonly ModSetting modSetting;
        public GameObject instantiatedGameObject;
        public RectTransform rectTransform;
        protected GameObject parent;
        public Text title;

        public SharedOption(GameObject parentGO)
        {
            parent = parentGO;
        }

        public SharedOption(GameObject parentGO, string gameObjectName) : this (parentGO)
        {
            rectTransform = parent.GetComponentInChildrenByName<RectTransform>(gameObjectName);

            if (rectTransform.IsVisible())
                rectTransform.Hide();

            var go = rectTransform.gameObject;
            var modOptionsContainer = parentGO.GetComponentInChildrenByName<RectTransform>("ModOptions Container");

            instantiatedGameObject = GameObject.Instantiate(go, modOptionsContainer);
            title = instantiatedGameObject.transform.Find("OptionBase/Name").GetComponent<Text>();
            
            instantiatedGameObject.Show();
        }

        public SharedOption(GameObject parentGO, ModSetting modSetting, string gameObjectName) : this(parentGO, gameObjectName)
        {
            this.modSetting = modSetting;
            title.text = modSetting.GetName();
        }

        public void Show()
        {
            instantiatedGameObject.Show();
        }

        public void Hide()
        {
            instantiatedGameObject.Hide();
        }

        public ModSetting GetModSetting()
        {
            return modSetting;
        }

        internal void SetLocation(float yCoord)
        {
            instantiatedGameObject.transform.position = new Vector3(rectTransform.position.x, yCoord);
        }

        internal static RectTransform GetOriginalAsset(GameObject parentGO, string name)
        {
            return parentGO.GetComponentInChildrenByName<RectTransform>(name);
        }
    }
}
