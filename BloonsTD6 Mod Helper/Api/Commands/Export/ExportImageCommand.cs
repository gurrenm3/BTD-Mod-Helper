using System;
using System.Collections.Generic;
using System.IO;
using BTD_Mod_Helper.Api.Helpers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Api.Commands.Export;

internal class ExportImageCommand : ModCommand<ExportCommand>
{
    public override string Command => "image";
    public override string Help => "Exports UI images raycasted from the current mouse position";

    public override bool Execute(ref string resultText)
    {
        try
        {
            var exported = new List<string>();
            var raycastResults = new Il2CppSystem.Collections.Generic.List<RaycastResult>();
            EventSystem.current.RaycastAll(new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            }, raycastResults);

            var imagesFolder = Path.Combine(FileIOHelper.sandboxRoot, "Images");
            Directory.CreateDirectory(imagesFolder);

            foreach (var result in raycastResults)
            {
                if (result.gameObject.Is(out var gameObject) &&
                    gameObject.HasComponent(out Image image) &&
                    image.sprite != null)
                {
                    var path = Path.Combine(imagesFolder, image.sprite.name + ".png");
                    if (image.sprite.TrySaveToPNG(path))
                    {
                        ModHelper.Msg($"Exported {path}");
                        exported.Add(image.sprite.name);
                    }
                }
            }

            resultText = $"Exported {exported.Join()} to {imagesFolder}";

        }
        catch (Exception e)
        {
            resultText = e.Message;
            ModHelper.Warning(e);
        }

        return true;
    }
}