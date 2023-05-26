using System;
using UnityEngine;
using UnityEngine.UI;
using Action = Il2CppSystem.Action;
namespace BTD_Mod_Helper.Api.Components;

/// <summary>
/// ModHelperComponent for a background panel
/// </summary>
[RegisterTypeInIl2Cpp(false)]
public class ModHelperButton : ModHelperComponent
{
    /// <summary>
    /// The aspect ratio of LongBtn sprites, since they aren't sliced for some reason lol
    /// </summary>
    public const float LongBtnRatio = 2.81f;

    /// <summary>
    /// The displayed image of the button
    /// </summary>
    public Image Image => GetComponent<Image>();

    /// <summary>
    /// The actual button component
    /// </summary>
    public Button Button => GetComponent<Button>();

    /// <inheritdoc />
    public ModHelperButton(IntPtr ptr) : base(ptr)
    {
    }


    /// <summary>
    /// Creates a new ModHelperButton
    /// </summary>
    /// <param name="info">The name/position/size info</param>
    /// <param name="sprite">The button's visuals</param>
    /// <param name="onClick">What should happen when the button is clicked</param>
    /// <returns></returns>
    public static ModHelperButton Create(Info info, string sprite, Action onClick)
    {
        var modHelperButton = Create<ModHelperButton>(info);

        var image = modHelperButton.AddComponent<Image>();
        image.type = Image.Type.Sliced;
        image.SetSprite(sprite);

        var button = modHelperButton.AddComponent<Button>();
        if (onClick != null)
        {
            button.onClick.AddListener(onClick.Invoke);
        }

        button.transition = Selectable.Transition.Animation;

        var animator = modHelperButton.AddComponent<Animator>();
        animator.runtimeAnimatorController = Animations.GlobalButtonAnimation;
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;

        return modHelperButton;
    }
}