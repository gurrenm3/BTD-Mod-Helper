using System;
using System.Collections.Generic;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using HarmonyLib;

namespace BTD_Mod_Helper.Patches.Resources
{
    [HarmonyPatch(typeof(Factory), nameof(Factory.CreateAsync))]
    internal static class Factory_CreateAsync
    {
        [HarmonyPrefix]
        private static bool Prefix(string objectId, ref Il2CppSystem.Action<UnityDisplayNode> onComplete)
        {
            if (ModDisplay.Cache.TryGetValue(objectId, out var modDisplay) &&
                modDisplay.ModifiesUnityObject &&
                !(ResourceHandler.Prefabs.ContainsKey(objectId) &&
                  !ResourceHandler.Prefabs[objectId].isDestroyed))
            {
                var complete = onComplete;
                onComplete = new Action<UnityDisplayNode>(node =>
                {
                    complete.Invoke(node);
                    modDisplay.ModifyDisplayNode(node);
                });
            }

            return true;
        }
    }
}