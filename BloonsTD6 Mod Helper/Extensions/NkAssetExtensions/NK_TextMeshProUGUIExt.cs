using Assets.Scripts.Unity;

namespace BTD_Mod_Helper.Extensions
{
    public static class NK_TextMeshProUGUIExt
    {
        public static string GetText(this NK_TextMeshProUGUI text) => Game.instance.GetLocalizationManager().textTable[text.localizeKey];

        public static void SetText(this NK_TextMeshProUGUI text, string localizeKey, string value)
        {
            var localMgr = Game.instance.GetLocalizationManager();
            if (!localMgr.ContainsKey(localizeKey))
                localMgr.textTable.Add(localizeKey, value);


            text.localizeKey = localizeKey;
            //text.LocalizeTextAsync();    // broken in update 27.0. Not sure what to do to fix it
        }
    }
}