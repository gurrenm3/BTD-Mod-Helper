using Assets.Scripts.Unity.Localization;

namespace BTD_Mod_Helper.Extensions
{
    public static class NK_TextMeshProUGUIExt
    {
        public static string GetText(this NK_TextMeshProUGUI text) => LocalizationManager.instance.textTable[text.localizeKey];

        public static void SetText(this NK_TextMeshProUGUI text, string localizeKey, string value)
        {
            if (!LocalizationManager.instance.ContainsKey(localizeKey))
                LocalizationManager.instance.textTable.Add(localizeKey, value);

            text.localizeKey = localizeKey;
            text.LocalizeTextAsync();
        }
    }
}