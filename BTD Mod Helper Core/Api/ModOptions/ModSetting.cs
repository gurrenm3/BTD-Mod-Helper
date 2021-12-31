using MelonLoader;
using System.Collections.Generic;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using System;

namespace BTD_Mod_Helper.Api.ModOptions
{
    /// <summary>
    /// (Cross-Game compatible) Class for keeping track of a variable for a Mod that can be changed in game via the Mod Setings menu
    /// </summary>
    /// <typeparam name="T">The type that this ModSetting holds</typeparam>
    public abstract class ModSetting<T> : ModSetting
    {
        internal T value;
        private readonly T defaultValue;
        
        /// <summary>
        /// The display name for the mod setting.
        /// <br/>
        /// Needs to be public to allow for object initializing
        /// </summary>
        public string displayName;

        /// <summary>
        /// Actions to call when the value changes. NOTE: Only works when using SetValue to change the value
        /// </summary>
        public List<Action<T>> OnValueChanged { get; set; } = new List<Action<T>>();

        /// <summary>
        /// Actions to call when this OptionUI element is initialized
        /// </summary>
        public List<Action<ModOption>> OnInitialized { get; set; } = new List<Action<ModOption>>();

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
                OnValueChanged.InvokeAll(v);
            }
            else
            {
                ModHelper.Warning($"Error: ModSetting type mismatch between {typeof(T).Name} and {val.GetType().Name}");
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
        public abstract ModOption ConstructModOption(GameObject parent);
    }

    
    /// <summary>
    /// 
    /// </summary>
    public interface ModSetting
    {
        /// <summary>
        /// Gets the current value that this ModSetting holds
        /// </summary>
        /// <returns>The value</returns>
        object GetValue();
        
        /// <summary>
        /// Gets the default value for this ModSetting
        /// </summary>
        /// <returns>The default value</returns>
        object GetDefaultValue();

        
        /// <summary>
        /// Sets the current value of this ModSetting
        /// </summary>
        /// <param name="val">The new value</param>
        void SetValue(object val);

        /// <summary>
        /// Gets the Display name for this ModSetting
        /// </summary>
        /// <returns>The display name</returns>
        string GetName();

        /// <summary>
        /// Sets the Display name for this ModSetting
        /// </summary>
        /// <param name="name">The display name</param>
        void SetName(string name);

        /// <summary>
        /// Constructs a visual ModOption for this ModSetting
        /// </summary>
        /// <param name="parent">The parent GameObject to attach to</param>
        /// <returns>The constructed ModOption</returns>
        ModOption ConstructModOption(GameObject parent);
    }
}