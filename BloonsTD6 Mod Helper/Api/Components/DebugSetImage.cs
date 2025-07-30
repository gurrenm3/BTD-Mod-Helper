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

    public string SpriteGuid
    {
        get => sprite;
        set
        {
            sprite = value;
            RefreshImage();
        }
    }

    public string SpriteName
    {
        set => SpriteGuid = VanillaSprites.ByName[value];
    }

    public void RefreshImage()
    {
        GetComponent<Image>().SetSprite(sprite);
    }
}