using System;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Components;

namespace BTD_Mod_Helper.Api.ModOptions
{
    /// <summary>
    /// (Cross-Game compatible) Class for keeping track of a variable for a Mod that can be changed in game via the Mod Settings menu
    /// </summary>
    /// <typeparam name="T">The type that this ModSetting holds</typeparam>
    public abstract class ModSetting<T> : IModSetting
    {
        internal T value;
        internal readonly T defaultValue;

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
        public SpriteReference icon;

        /// <summary>
        /// Action to call when the value changes. NOTE: is no longer applies to manual calls to SetValue
        /// </summary>
        public Action<T> onValueChanged;

        /// <summary>
        /// Action to modify the ModHelperOption after it's created
        /// </summary>
        public Action<ModHelperOption> modifyOption;

        /// <summary>
        /// Constructs a new ModSetting for the given value
        /// </summary>
        /// <param name="value"></param>
        protected ModSetting(T value)
        {
            this.value = value;
            defaultValue = value;
        }

        /// <inheritdoc />
        public virtual object GetValue()
        {
            return value;
        }

        /// <inheritdoc />
        public virtual object GetDefaultValue()
        {
            return defaultValue;
        }

        /// <inheritdoc />
        public virtual void SetValue(object val)
        {
            if (val is T v)
            {
                value = v;
                // onValueChanged?.Invoke(v);
            }
            else
            {
                ModHelper.Warning(
                    $"Error: ModSetting type mismatch between {typeof(T).Name} and {val.GetType().Name} for {displayName}");
            }
        }

        /// <inheritdoc />
        public string GetName()
        {
            return displayName;
        }

        /// <inheritdoc />
        public void SetName(string name)
        {
            displayName = name;
        }

        /// <inheritdoc />
        public abstract ModHelperComponent CreateComponent();

        /// <summary>
        /// Creates a base ModHelperOption component based on the name, description and icon of this
        /// </summary>
        protected ModHelperOption CreateBaseOption()
        {
            var modHelperOption = ModHelperOption.Create(displayName, description, icon);
            modifyOption?.Invoke(modHelperOption);
            return modHelperOption;
        }
    }
}