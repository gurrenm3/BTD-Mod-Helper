using System;
using System.Collections.Generic;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Data;
using Il2CppNinjaKiwi.Common;
namespace BTD_Mod_Helper.Api.ModOptions;

/// <summary>
/// Class for keeping track of a variable for a Mod that can be changed in game via the Mod Settings menu
/// </summary>
/// <typeparam name="T">The type that this ModSetting holds</typeparam>
public abstract class ModSetting<T> : ModSetting
{
    /// <summary>
    /// Will only save the result and run onSave if this custom function validates the value
    /// </summary>
    public Func<T, bool> customValidation;
    internal T defaultValue;
    internal T lastSavedValue;

    /// <summary>
    /// Action to call when the value is saved, i.e. once they actually close the menu
    /// </summary>
    public Action<T> onSave;

    /// <summary>
    /// Action to call when the value changes within the menu
    /// </summary>
    public Action<T> onValueChanged;
    internal T value;

    /// <summary>
    /// Constructs a new ModSetting for the given value
    /// </summary>
    /// <param name="value"></param>
    protected ModSetting(T value)
    {
        this.value = defaultValue = lastSavedValue = value;
    }


    /// <summary>
    /// Old onValueChanged.
    /// </summary>
    [Obsolete("Use onSave or onValueChanged instead")]
    public List<Action<T>> OnValueChanged { get; set; } = new();

    /// <inheritdoc />
    public override object GetValue() => value;

    /// <inheritdoc />
    public override object GetDefaultValue() => defaultValue;

    /// <inheritdoc />
    public override object GetLastSavedValue() => lastSavedValue;

    /// <inheritdoc />
    public override void SetValue(object val)
    {
        if (val is T v)
        {
            value = v;
            onValueChanged?.Invoke(v);
            if (requiresRestart && currentOption != null)
            {
                currentOption.RestartIcon.SetActive(lastSavedValue?.Equals(value) != true || needsRestartRightNow);
            }
        }
        else
        {
            ModHelper.Warning(
                $"Error: ModSetting type mismatch between {typeof(T).Name} and {val.GetType().Name} for {displayName}");
        }
    }

    /// <inheritdoc />
    public override void SetValueAndSave(object val, bool logSuccess = false)
    {
        SetValue(val);
        ModSettingsHandler.SaveModSettings(mod, true, logSuccess);
    }

    /// <inheritdoc />
    internal override bool OnSave()
    {
        if (customValidation != null && !customValidation(value))
        {
            value = lastSavedValue;
            return false;
        }

        if (value?.Equals(lastSavedValue) != true && requiresRestart)
        {
            needsRestartRightNow = true;
        }

        lastSavedValue = value;
        onSave?.Invoke(value);
        return true;
    }

    internal override void Load(object val)
    {
        if (val is T v)
        {
            value = v;
            lastSavedValue = value;
        }
        else
        {
            ModHelper.Warning(
                $"Error: ModSetting type mismatch between {typeof(T).Name} and {val.GetType().Name} for {displayName}");
        }
    }

    internal override Type GetSettingType() => typeof(T);
}

/// <summary>
/// Base class for a ModSetting without the generics
/// </summary>
public abstract class ModSetting
{
    /// <summary>
    /// The category that this is part of, or null
    /// </summary>
    public ModSettingCategory category;

    internal ModHelperOption currentOption;

    internal BloonsMod mod;

    /// <summary>
    /// The name of this mod setting, gotten from the field name
    /// </summary>
    public string Name { get; internal set; }

    /// <summary>
    /// The description / explanation of this mod setting
    /// </summary>
    public string description;
    /// <summary>
    /// The exact name displayed for this mod setting. If unset, will use the variable name.
    /// </summary>
    public string displayName;

    internal string displayNameKey;
    internal string descriptionKey;

    /// <summary>
    /// Icon to display alongside the setting
    /// </summary>
    public string icon;

    /// <summary>
    /// Action to modify the ModHelperOption after it's created
    /// </summary>
    public Action<ModHelperOption> modifyOption;
    internal bool needsRestartRightNow;

    /// <summary>
    /// Indicates to players that the effects of changing this setting will only take place after a restart
    /// </summary>
    public bool requiresRestart;

    /// <summary>
    /// The type where this ModSettings was defined
    /// </summary>
    public IModSettings source;

    /// <summary>
    /// Gets the current value that this ModSetting holds
    /// </summary>
    /// <returns>The value</returns>
    public virtual object GetValue() => null;

    /// <summary>
    /// Gets the default value for this ModSetting
    /// </summary>
    /// <returns>The default value</returns>
    public virtual object GetDefaultValue() => null;

    /// <summary>
    /// Gets the last saved value for this ModSetting
    /// </summary>
    /// <returns>The last saved value</returns>
    public virtual object GetLastSavedValue() => null;

    /// <summary>
    /// Sets the current value of this ModSetting
    /// </summary>
    /// <param name="val">The new value</param>
    public virtual void SetValue(object val)
    {
    }

    /// <summary>
    /// Sets the current value of this ModSetting, and immediately saves the settings for the mod
    /// </summary>
    /// <param name="val">The new value</param>
    /// <param name="logSuccess">Whether to log the message success for when mod settings are saved</param>
    public virtual void SetValueAndSave(object val, bool logSuccess = false)
    {
    }

    /// <summary>
    /// Constructs a visual ModHelperComponent for this ModSetting
    /// </summary>
    /// <returns>The created ModHelperComponent</returns>
    internal abstract ModHelperOption CreateComponent();

    /// <summary>
    /// Validates the current value using the customValidation function, if there is one.
    /// If there were no issues, performs the onSave action
    /// </summary>
    internal virtual bool OnSave() => true;

    internal virtual void Load(object value)
    {

    }

    internal virtual Type GetSettingType() => typeof(object);

    /// <summary>
    /// Creates a base ModHelperOption component based on the name, description and icon of this
    /// </summary>
    protected ModHelperOption CreateBaseOption()
    {
        var modHelperOption = ModHelperOption.Create(displayNameKey ?? displayName, descriptionKey ?? description, icon);
        modifyOption?.Invoke(modHelperOption);
        modHelperOption.RestartIcon.SetActive(needsRestartRightNow);
        return modHelperOption;
    }
}