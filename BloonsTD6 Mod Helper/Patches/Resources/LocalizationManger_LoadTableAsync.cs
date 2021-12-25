using System;
using BTD_Mod_Helper.Api;
using HarmonyLib;
using MelonLoader;
using NinjaKiwi.Common;

namespace BTD_Mod_Helper.Patches.Resources
{
    [HarmonyPatch(typeof(LocalizationManager._LoadTableAsync_d__44),
        nameof(LocalizationManager._LoadTableAsync_d__44.MoveNext))]
    internal static class LocalizationManger_LoadTableAsync
    {
        [HarmonyPostfix]
        private static void Postfix(LocalizationManager._LoadTableAsync_d__44 __instance)
        {
            var result = __instance.__t__builder.Task.Result;
            if (result != null)
            {
                foreach (var namedModContent in ModContent.GetContent<NamedModContent>())
                {
                    try
                    {
                        namedModContent.RegisterText(result);
                    }
                    catch (Exception e)
                    {
                        MelonLogger.Msg($"Failed to register text for {namedModContent}");
                        MelonLogger.Error(e);
                    }
                }
            }
        }
    }
}