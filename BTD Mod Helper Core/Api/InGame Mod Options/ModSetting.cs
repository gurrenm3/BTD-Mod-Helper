using MelonLoader;
using UnityEngine;

namespace BTD_Mod_Helper.Api.InGame_Mod_Options
{
    public abstract class ModSetting<T> : ModSetting
    {
        internal T value;
        private readonly T defaultValue;
        public string displayName;

        protected ModSetting(T value)
        {
            this.value = value;
            defaultValue = value;
        }

        public virtual object GetValue()
        {
            return value;
        }

        public virtual object GetDefaultValue()
        {
            return defaultValue;
        }

        public virtual void SetValue(object value)
        {
            if (value is T v)
            {
                this.value = v;
            }
            else
            {
                MelonLogger.Warning($"Error: ModSetting type mismatch between {typeof(T).Name} and {value.GetType().Name}");
            }
        }

        public string GetName()
        {
            return displayName;
        }

        public void SetName(string name)
        {
            displayName = name;
        }

        public abstract ModOption ConstructModOption(GameObject parent);
    }

    public interface ModSetting
    {
        object GetValue();
        
        object GetDefaultValue();

        void SetValue(object value);

        string GetName();

        void SetName(string name);

        ModOption ConstructModOption(GameObject parent);
    }
}