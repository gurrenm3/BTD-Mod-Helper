using System.Collections.Generic;
using Assets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using HarmonyLib;
using Il2CppSystem;
using MelonLoader;
using UnityEngine;
using Exception = System.Exception;
using Object = UnityEngine.Object;

namespace BTD_Mod_Helper.Patches.Resources
{
    [HarmonyPatch(typeof(Factory), nameof(Factory.FindAndSetupPrototypeAsync))]
    internal class Factory_FindAndSetupPrototypeAsync
    {
        [HarmonyPrefix]
        internal static bool Prefix(Factory __instance, ref string objectId, ref Action<UnityDisplayNode> onComplete)
        {
            var id = objectId;
            var action = onComplete;
            if (ResourceHandler.Prefabs.ContainsKey(objectId) && !ResourceHandler.Prefabs[objectId].isDestroyed)
            {
                onComplete.Invoke(ResourceHandler.Prefabs[objectId]);
                return false;
            }

            if (ResourceHandler.Resources.GetValueOrDefault(objectId) is byte[] bytes &&
                ResourceHandler.ScalesFor2dModels.ContainsKey(objectId))
            {
                objectId = "9dccc16d26c1c8a45b129e2a8cbd17ba";
                onComplete = new System.Action<UnityDisplayNode>(node =>
                    {
                        var udn = Object.Instantiate(node, __instance.PrototypeRoot);
                        udn.name = id + "(Clone)";
                        var texture = new Texture2D(2, 2);
                        ImageConversion.LoadImage(texture, bytes);
                        udn.isSprite = true;
                        udn.RecalculateGenericRenderers();
                        var spriteRenderer = udn.genericRenderers.GetItemOfType<Renderer, SpriteRenderer>();
                        var scale = ResourceHandler.ScalesFor2dModels.GetValueOrDefault(id, 10f);
                        spriteRenderer.sprite = Sprite.Create(texture,
                            new Rect(0, 0, texture.width, texture.height),
                            new Vector2(0.5f, 0.5f), scale, 0, SpriteMeshType.Tight);
                        udn.towerPlacementPreCalcOffset = new Vector3(0, 2f, 0);
                        action.Invoke(udn);
                        ResourceHandler.Prefabs[id] = udn;
                    }
                );
                return true;
            }

            if (ModDisplay.Cache.GetValueOrDefault(objectId) is ModDisplay modDisplay)
            {
                try
                {
                    if (modDisplay is ICustomDisplay customDisplay)
                    {
                        var assetBundle = ModContent.GetBundle(modDisplay.mod, customDisplay.AssetBundleName);
                        var udn = Object.Instantiate(assetBundle.LoadAsset(customDisplay.PrefabName).Cast<GameObject>(),
                            __instance.PrototypeRoot).AddComponent<UnityDisplayNode>();
                        udn.Active = false;
                        udn.transform.position = new Vector3(-3000, 0);
                        var material = assetBundle.LoadAsset(customDisplay.MaterialName).Cast<Material>();
                        udn.genericRenderers[0].SetMaterial(material);
                        SetupUDN(udn, modDisplay, onComplete);
                        return false;
                    }

                    objectId = modDisplay.BaseDisplay;
                    onComplete = new System.Action<UnityDisplayNode>(node =>
                    {
                        var udn = Object.Instantiate(node, __instance.PrototypeRoot);
                        SetupUDN(udn, modDisplay, action);
                    });
                }
                catch (Exception e)
                {
                    ModHelper.Error($"Failed to load display for {modDisplay.Name}");
                    ModHelper.Error(e);
                }
            }

            return true;
        }

        private static void SetupUDN(UnityDisplayNode udn, ModDisplay modDisplay, Action<UnityDisplayNode> onComplete)
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
                if (modDisplay.Scale < 1f || modDisplay.Scale > 1f)
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

            onComplete.Invoke(udn);

            ResourceHandler.Prefabs[modDisplay.Id] = udn;
        }
    }
}