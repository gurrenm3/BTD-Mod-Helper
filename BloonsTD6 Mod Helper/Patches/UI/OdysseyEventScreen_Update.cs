using Il2CppAssets.Scripts.Unity.UI_New.Odyssey;
namespace BTD_Mod_Helper.Patches.UI;

[HarmonyPatch(typeof(OdysseyEventScreen), nameof(OdysseyEventScreen.Update))]
internal class OdysseyEventScreen_Update
{
    [HarmonyPostfix]
    internal static void Postfix()
    {
        // Setting only if false because this method is called constantly when screen is open
        if (!SessionData.Instance.IsInOdyssey)
        {
            SessionData.Instance.IsInOdyssey = true;
        }
    }
}