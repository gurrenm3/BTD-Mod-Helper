using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Il2CppAssets.Scripts.Unity.UI_New.Upgrade;
using UnityEngine;
namespace BTD_Mod_Helper.Patches.UI;

/// <summary>
/// Stop the first object in the top upgrade row from being automatically selected, since it may not exist for modded towers
/// </summary>
[HarmonyPatch(typeof(UpgradeScreen))]
internal class UpgradeScreen_Open
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.GetDeclaredMethods(typeof(UpgradeScreen))
            .First(info => info.Name.Contains("Open") && info.ReturnType == typeof(GameObject));
    }

    [HarmonyPrefix]
    internal static bool Prefix(UpgradeScreen __instance)
    {
        return false;
    }
}