using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Harmony;
using Il2CppSystem;
using MelonLoader;
using UnityEngine;
using Exception = System.Exception;
using Object = UnityEngine.Object;

namespace BTD_Mod_Helper.Patches
{
    [HarmonyPatch(typeof(Factory), nameof(Factory.FindAndSetupPrototypeAsync))]
    internal class Factory_FindAndSetupPrototypeAsync
    {

        [HarmonyPrefix]
        internal static bool Prefix(Factory __instance, string objectId, Action<UnityDisplayNode> onComplete)
        {
            if (ResourceHandler.Prefabs.ContainsKey(objectId) && !ResourceHandler.Prefabs[objectId].isDestroyed)
            {
                onComplete.Invoke(ResourceHandler.Prefabs[objectId]);
                return false;
            }

            if (ResourceHandler.resources.GetValueOrDefault(objectId) is byte[] bytes &&
                ModTowerHandler.Tower2DScales.ContainsKey(objectId))
            {
                __instance.FindAndSetupPrototypeAsync("9dccc16d26c1c8a45b129e2a8cbd17ba", // road spikes
                    new System.Action<UnityDisplayNode>(node =>
                        {
                            var udn = Object.Instantiate(node, __instance.PrototypeRoot);
                            udn.name = objectId + "(Clone)";
                            var texture = new Texture2D(2, 2);
                            ImageConversion.LoadImage(texture, bytes);
                            udn.isSprite = true;
                            udn.RecalculateGenericRenderers();
                            var spriteRenderer = udn.genericRenderers.GetItemOfType<Renderer, SpriteRenderer>();
                            var scale = ModTowerHandler.Tower2DScales.GetValueOrDefault(objectId, 5f);
                            spriteRenderer.sprite = Sprite.Create(texture,
                                new Rect(0, 0, texture.width, texture.height),
                                new Vector2(0.5f, 0.5f), scale, 0, SpriteMeshType.Tight);
                            udn.towerPlacementPreCalcOffset = new Vector3(0, 2f, 0);
                            onComplete.Invoke(udn);
                            ResourceHandler.Prefabs[objectId] = udn;
                            //__instance.active.Add(udn);
                        }
                    ));
                return false;
            }

            if (ModDisplayHandler.ModDisplays.GetValueOrDefault(objectId) is ModDisplay modDisplay)
            {
                try
                {
                    __instance.FindAndSetupPrototypeAsync(modDisplay.BaseDisplay,
                        new System.Action<UnityDisplayNode>(node =>
                        {
                            var udn = Object.Instantiate(node, __instance.PrototypeRoot);
                            udn.name = objectId + "(Clone)";
                            udn.RecalculateGenericRenderers();
                            try
                            {
                                modDisplay.ModifyDisplayNode(udn);
                            }
                            catch (Exception e)
                            {
                                MelonLogger.Error($"Failed to modify DisplayNode for {modDisplay.Name}");
                                MelonLogger.Error(e);
                            }
                            udn.RecalculateGenericRenderers();

                            onComplete.Invoke(udn);
                            ResourceHandler.Prefabs[objectId] = udn;
                            //__instance.active.Add(udn);
                        }));
                    return false;
                }
                catch (Exception e)
                {
                    MelonLogger.Error($"Failed to load display for {modDisplay.Name}");
                    MelonLogger.Error(e);
                }
            }

            return true;
        }
    }
}