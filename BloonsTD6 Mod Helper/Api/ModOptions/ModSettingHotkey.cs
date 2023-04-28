using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.Menu;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.Settings;
using UnityEngine;
namespace BTD_Mod_Helper.Api.ModOptions;

/// <summary>
/// ModSetting for a customizable Hotkey
/// </summary>
public class ModSettingHotkey : ModSetting<string>
{
    private HotKey hotKey;
    private HotkeysScreenField currentField;

    /// <inheritdoc />
    public ModSettingHotkey(KeyCode key, HotkeyModifier modifier = HotkeyModifier.None)
        : base(key.GetPath() + "-" + modifier)
    {
        hotKey = new HotKey(modifier, key.GetPath());
    }

    internal override void Load(object val)
    {
        base.Load(val);
        UpdateHotkeyFromValue();
    }

    /// <inheritdoc />
    public override void SetValue(object val)
    {
        base.SetValue(val);
        UpdateHotkeyFromValue();
    }

    private void UpdateHotkeyFromValue()
    {
        var array = value.Split('-');
        hotKey.path = array[0];
        hotKey.modifierKey = Enum.TryParse(array[1], out HotkeyModifier m) ? m : default;
    }

    private bool Modifier(Func<KeyCode, bool> func)
    {
        switch (hotKey.modifierKey)
        {
            case HotkeyModifier.Shift:
                return func(KeyCode.LeftShift) || func(KeyCode.RightShift);
            case HotkeyModifier.Ctrl:
                return func(KeyCode.LeftControl) || func(KeyCode.RightControl);
            case HotkeyModifier.Alt:
                return func(KeyCode.LeftAlt) || func(KeyCode.RightAlt);
            default:
            case HotkeyModifier.None:
                return true;
        }
    }

    /// <summary>
    /// Returns whether the Hotkey was pressed down on this frame
    /// </summary>
    public bool JustPressed() => Modifier(Input.GetKey) && Input.GetKeyDown(hotKey.path.GetKeyCode());

    /// <summary>
    /// Returns whether the Hotkey is currently being pressed / held
    /// </summary>
    public bool IsPressed() => Modifier(Input.GetKey) && Input.GetKey(hotKey.path.GetKeyCode());

    /// <summary>
    /// Returns whether the Hotkey just went from being pressed to not being pressed on this frame
    /// </summary>
    public bool JustReleased() => Modifier(Input.GetKey) && Input.GetKeyUp(hotKey.path.GetKeyCode()) ||
                                  Modifier(Input.GetKeyUp) && Input.GetKey(hotKey.path.GetKeyCode());

    /// <inheritdoc />
    internal override bool OnSave()
    {
        if (currentField != null)
        {
            hotKey = currentField.CurrentHotkey;
        }

        value = hotKey.path + "-" + hotKey.modifierKey;
        return base.OnSave();
    }

    /// <inheritdoc />
    internal override ModHelperOption CreateComponent()
    {
        var option = CreateBaseOption();

        var buttonComponent = option.BottomRow.AddButton(
            new Info("Button", width: 562, height: 200), VanillaSprites.GreenBtnLong, null
        );
        var text = buttonComponent.AddText(new Info("Text", InfoPreset.FillParent), "", 69f);

        var changedHighlight = option.AddPanel(new Info("ChangedHighlight"));
        changedHighlight.LayoutElement.ignoreLayout = true;

        var hotkey = currentField = option.AddComponent<HotkeysScreenField>();

        hotkey.button = buttonComponent.Button;
        buttonComponent.Button.SetOnClick(hotkey.OnUiButtonPressed);
        hotkey.changedHighlight = changedHighlight;
        hotkey.commandNameText = option.Name.Text;
        hotkey.keyText = text.Text;

        if (MenuManager.instance.GetCurrentMenu().IsType(out HotkeysScreen screen))
        {
            hotkey.Initialise(displayName, hotKey, screen);
        }


        return option;
    }

    /// <summary>
    /// Creates a new ModSettingHotkey from a KeyCode
    /// </summary>
    public static implicit operator ModSettingHotkey(KeyCode key) => new(key);
}