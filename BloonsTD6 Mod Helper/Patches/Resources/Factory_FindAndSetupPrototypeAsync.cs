using Il2CppAssets.Scripts.Unity.Display;
namespace BTD_Mod_Helper.Patches.Resources;

[HarmonyPatch(typeof(Factory), nameof(Factory.FindAndSetupPrototypeAsync))]
internal class Factory_FindAndSetupPrototypeAsync
{
    /*[HarmonyPrefix]
    internal static bool Prefix(ref Factory __instance, ref string objectId, ref Action<UnityDisplayNode> onComplete)
    {
        var id = objectId;
        var action = onComplete;
        var factory=__instance;
        ModHelper.PerformHook(mod=>mod.OnModelLoaded(factory,id,action));
        if (ResourceHandler.Prefabs.ContainsKey(objectId) && !ResourceHandler.Prefabs[objectId].isDestroyed)
        {
            onComplete.Invoke(ResourceHandler.Prefabs[objectId]);
            return false;
        }

        if (ResourceHandler.Resources.TryGetValue(objectId, out var bytes) &&
            ResourceHandler.ScalesFor2dModels.ContainsKey(objectId))
        {
            objectId = "9dccc16d26c1c8a45b129e2a8cbd17ba";
            onComplete = new System.Action<UnityDisplayNode>(node =>
                {
                    var udn = Object.Instantiate(node, factory.PrototypeRoot);
                    udn.name = id + "(Clone)";
                    var texture = new Texture2D(2, 2);
                    ImageConversion.LoadImage(texture, bytes);
                    udn.isSprite = true;
                    udn.RecalculateGenericRenderers();
                    var spriteRenderer = udn.genericRenderers.GetItemOfType<Renderer, SpriteRenderer>();
                    var scale = ResourceHandler.ScalesFor2dModels.TryGetValue(id, out var f) ? f : 10;
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

        if (ModDisplay.Cache.TryGetValue(objectId, out var modDisplay))
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
                    if (!string.IsNullOrEmpty(customDisplay.MaterialName))
                    {
                        try
                        {
                            var material = assetBundle.LoadAsset(customDisplay.MaterialName).Cast<Material>();
                            udn.genericRenderers[0].SetMaterial(material);
                        }
                        catch (Exception e)
                        {
                            ModHelper.Warning($"Failed to load custom material {customDisplay.MaterialName}");
                            ModHelper.Warning(e);
                        }
                    }
                    SetupUDN(udn, modDisplay, onComplete);
                    return false;
                }
                objectId = modDisplay.BaseDisplay;
                onComplete = new System.Action<UnityDisplayNode>(node =>
                {
                    var udn = Object.Instantiate(node, factory.PrototypeRoot);
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
    }*/
}