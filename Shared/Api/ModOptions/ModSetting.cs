using System;
using System.Collections.Generic;
using BTD_Mod_Helper.Api.Components;
namespace BTD_Mod_Helper.Api.ModOptions;

/// <summary>
/// Class for keeping track of a variable for a Mod that can be changed in game via the Mod Settings menu
/// </summary>
/// <typeparam name="T">The type that this ModSetting holds</typeparam>
public abstract class ModSetting<T> : ModSetting
{
    internal T value;
    internal T defaultValue;
    internal T lastSavedValue;

    /// <summary>
    /// Action to call when the value changes within the menu
    /// </summary>
    public Action<T> onValueChanged;

    /// <summary>
    /// Action to call when the value is saved, i.e. once they actually close the menu
    /// </summary>
    public Action<T> onSave;


    /// <summary>
    /// Will only save the result and run onSave if this custom function validates the value
    /// </summary>
    public Func<T, bool> customValidation;


    /// <summary>
    /// Old onValueChanged. 
    /// </summary>
    [Obsolete("Use onSave or onValueChanged instead")]
    public List<Action<T>> OnValueChanged { get; set; } = new();

    /// <summary>
    /// Constructs a new ModSetting for the given value
    /// </summary>
    /// <param name="value"></param>
    protected ModSetting(T value)
    {
        this.value = defaultValue = lastSavedValue = value;
    }

    /// <inheritdoc />
    public override object GetValue()
    {
        return value;
    }

    /// <inheritdoc />
    public override object GetDefaultValue()
    {
        return defaultValue;
    }

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
    /// The exact name displayed for this mod setting. If unset, will use the variable name.
    /// </summary>
    public string displayName;

    /// <summary>
    /// The description / explanation of this mod setting
    /// </summary>
    public string description;

    /// <summary>
    /// Icon to display alongside the setting
    /// </summary>
    public string icon;

    /// <summary>
    /// Action to modify the ModHelperOption after it's created
    /// </summary>
    public Action<ModHelperOption> modifyOption;

    /// <summary>
    /// The category that this is part of, or null
    /// </summary>
    public ModSettingCategory category;

    /// <summary>
    /// Indicates to players that the effects of changing this setting will only take place after a restart
    /// </summary>
    public bool requiresRestart;

    internal ModHelperOption currentOption;
    internal bool needsRestartRightNow;

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
    /// Sets the current value of this ModSetting
    /// </summary>
    /// <param name="val">The new value</param>
    public virtual void SetValue(object val)
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
        var modHelperOption = ModHelperOption.Create(displayName, description, icon);
        modifyOption?.Invoke(modHelperOption);
        modHelperOption.RestartIcon.SetActive(needsRestartRightNow);
        return modHelperOption;
    }
}