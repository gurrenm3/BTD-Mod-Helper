using UnityEngine;
using UnityEngine.UI;
namespace BTD_Mod_Helper.Extensions;

/// <summary>
/// Extensions for Buttons
/// </summary>
public static class ButtonExt
{
    /// <summary>
    /// Adds an onclick function to a button
    /// </summary>
    public static void AddOnClick(this Button button, Function funcToExecute)
    {
        button.onClick.AddListener(funcToExecute);
    }

    /// <summary>
    /// Sets the onclick function of a button
    /// </summary>
    public static void SetOnClick(this Button button, Function funcToExecute)
    {
        button.onClick.SetListener(funcToExecute);
    }

    /// <summary>
    /// Removes the onclick function of a button
    /// </summary>
    public static void RemoveOnClickAction(this Button button, int actionIndex)
    {
        button.onClick.RemovePersistantCall(actionIndex);
    }

    /// <summary>
    /// Set the sprite for this button.
    /// </summary>
    /// <param name="button"></param>
    /// <param name="sprite">Sprite to change to</param>
    /// <param name="newSpriteName">Optionally provide a new name for the sprite</param>
    public static void SetSprite(this Button button, Sprite sprite, string newSpriteName = "")
    {
        button.image.sprite = sprite;
        if (!string.IsNullOrEmpty(newSpriteName))
            button.image.sprite.name = newSpriteName;
    }
}