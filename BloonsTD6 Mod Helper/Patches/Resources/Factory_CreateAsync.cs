using System;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(Factory.__c__DisplayClass21_0), nameof(Factory.__c__DisplayClass21_0._CreateAsync_b__0))]
internal static class Factory_CreateAsync
{
    [HarmonyPrefix]
    private static bool Prefix(Factory.__c__DisplayClass21_0 __instance, UnityDisplayNode prototype)
    {
        var factory = __instance.__4__this;
        var prefabReference = __instance.objectId;
        var guid = prefabReference.guidRef;
        var onComplete = __instance.onComplete;

        if (ModDisplay.Cache.TryGetValue(guid, out var modDisplay))
        {
            var baseRef = ModContent.CreatePrefabReference(modDisplay.BaseDisplay);
            factory.FindAndSetupPrototypeAsync(baseRef, new Action<UnityDisplayNode>(node =>
            {
                UnityDisplayNode newNode = null;
                var realPrototype = prototype;

                if (realPrototype == null)
                {
                    var parent = Game.instance.prototypeObjects.transform;
                    var newPrototype = Object.Instantiate(node.gameObject, parent);

                    var manager = Addressables.Instance.ResourceManager;
                    var handle = manager.CreateCompletedOperation(newPrototype, "");
                    factory.prototypeHandles[prefabReference] = handle;
                    realPrototype = newPrototype.GetComponent<UnityDisplayNode>();

                    SetupUDN(realPrototype, modDisplay);
                }

                // Fake version of the CreateAsync callback
                if (realPrototype != null)
                {
                    var gameObject = realPrototype.gameObject;
                    var position = new Vector3(Factory.kOffscreenPosition.x, 0, 0);
                    var rotation = Quaternion.identity;
                    var newObject = Object.Instantiate(gameObject, position, rotation, factory.DisplayRoot);
                    newNode = newObject.GetComponent<UnityDisplayNode>();
                    newNode.Create();
                    newNode.cloneOf = prefabReference;
                    newObject.SetActive(true);
                    factory.active.Add(newNode);
                }

                onComplete.Invoke(newNode);
            }));

            return false;
        }

        return true;
    }

    private static void SetupUDN(UnityDisplayNode udn, ModDisplay modDisplay,
        Il2CppSystem.Action<UnityDisplayNode> onComplete = null)
    {
        udn.name = modDisplay.Id + "(Clone)";
        udn.RecalculateGenericRenderers();
        try
        {
            modDisplay.ModifyDisplayNode(udn);
        }
        catch (Exception e)
        {
            ModHelper.Error($"Failed to modify DisplayNode for {modDisplay.Name}");
            ModHelper.Error(e);
        }

        try
        {
            if (modDisplay.Scale is < 1f or > 1f)
            {
                udn.transform.GetChild(0).transform.localScale = new Vector3(modDisplay.Scale,
                    modDisplay.Scale, modDisplay.Scale);
            }
        }
        catch (Exception e)
        {
            ModHelper.Error($"Failed to change scale for {modDisplay.Name}");
            ModHelper.Error(e);
        }

        udn.RecalculateGenericRenderers();

        onComplete?.Invoke(udn);

        ResourceHandler.Prefabs[modDisplay.Id] = udn;
    }
}