using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using Il2CppNinjaKiwi.Common.ResourceUtils;
namespace BTD_Mod_Helper.Api.UI;

/// <summary>
/// Registers an image that can be used within hint / event popups
/// </summary>
public abstract class ModPopupImage : ModContent
{
    /// <summary>
    /// The Image to use
    /// <br />
    /// (Name of .png or .jpg, not including file extension)
    /// </summary>
    public virtual string Image => Name;

    /// <summary>
    /// If you're not going to use a custom .png for your Image, use this to directly control its SpriteReference
    /// </summary>
    public virtual SpriteReference ImageReference => GetSpriteReferenceOrNull(Image) ?? new SpriteReference(Image);

    /// <summary>
    /// What should be passed in to methods like <see cref="PopupScreen.QueueHint"/> and <see cref="PopupScreen.ShowEventPopup"/>
    /// </summary>
    public int Index { get; internal set; } = -1;

    /// <inheritdoc />
    public override void Register()
    {
    }

    /// <inheritdoc cref="Index" />
    public static implicit operator int(ModPopupImage image) => image.Index;
}