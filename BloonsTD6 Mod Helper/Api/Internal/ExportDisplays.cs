using System;
using System.IO;
using BTD_Mod_Helper.Api.Helpers;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppAssets.Scripts.Utils;
using Il2CppTMPro;
using UnityEngine;
namespace BTD_Mod_Helper.Api.Internal;

internal static class ExportDisplays
{
    public static void Prompt()
    {
        PopupScreen.instance.SafelyQueue(screen =>
        {
            screen.ShowSetNamePopup("Export Display",
                "Paste in the GUID for the display you want to export", new Action<string>(guid =>
                {
                    Game.instance.GetDisplayFactory().FindAndSetupPrototypeAsync(new PrefabReference {guidRef = guid},
                        DisplayCategory.None, new Action<UnityDisplayNode>(node =>
                        {
                            if (node == null) return;

                            var displays = Path.Combine(FileIOHelper.sandboxRoot, "Displays");
                            Directory.CreateDirectory(displays);
                            var folder = Path.Combine(displays, node.name.Replace("(Clone)", ""));
                            Directory.CreateDirectory(folder);

                            var i = 0;
                            foreach (var renderer in node.GetRenderers<MeshRenderer>())
                            {
                                renderer.material.mainTexture.TrySaveToPNG(Path.Combine(folder, $"MeshRenderer_{i}.png"));
                                i++;
                            }

                            i = 0;
                            foreach (var renderer in node.GetRenderers<SkinnedMeshRenderer>())
                            {
                                renderer.material.mainTexture.TrySaveToPNG(Path.Combine(folder,
                                    $"SkinnedMeshRenderer_{i}.png"));
                                i++;
                            }

                            i = 0;
                            foreach (var renderer in node.GetRenderers<SpriteRenderer>())
                            {
                                renderer.sprite.texture.TrySaveToPNG(Path.Combine(folder, $"SpriteRenderer_{i}.png"));
                                i++;
                            }

                            ProcessHelper.OpenFolder(folder);
                        }));
                }), "");
            screen.ModifyField(field =>
            {
                field.characterValidation = TMP_InputField.CharacterValidation.Alphanumeric;
                field.characterLimit = 32;
            });
        });
    }
}