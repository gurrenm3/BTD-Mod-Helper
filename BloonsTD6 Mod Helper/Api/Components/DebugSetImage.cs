using System;
using BTD_Mod_Helper.Api.Enums;
using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Api.Components;

[RegisterTypeInIl2Cpp(false)]
internal class DebugSetImage : MonoBehaviour
{
    public DebugSetImage(IntPtr pointer) : base(pointer)
    {
    }

    private string sprite;
    private Image Image => field ??= GetComponent<Image>();

    public string SpriteGuid
    {
        get => sprite;
        set
        {
            sprite = value;
            RefreshImage();
        }
    }

    public bool Sliced
    {
        get => Image.type == Image.Type.Sliced;
        set => Image.type = value ? Image.Type.Sliced : Image.Type.Simple;
    }

    public float PixelsPerUnit
    {
        get => Image.pixelsPerUnitMultiplier;
        set => Image.pixelsPerUnitMultiplier = value;
    }

    public string SpriteName
    {
        set => SpriteGuid = VanillaSprites.ByName[value];
    }

    public void RefreshImage()
    {
        Image.SetSprite(sprite);
    }
}