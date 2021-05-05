using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Harmony;
using MelonLoader;
using Newtonsoft.Json;

namespace BTD_Mod_Helper.Api.InGame_Mod_Options
{
    internal class ModSettingsHandler
    {
        internal static void InitializeModSettings(string modSettingsDir)
        {
            if (!Directory.Exists(modSettingsDir))
            {
                Directory.CreateDirectory(modSettingsDir);
            }
            foreach (var mod in MelonHandler.Mods.OfType<BloonsMod>())
            {
                mod.ModSettings = new Dictionary<string, ModSetting>();
                try
                {
                    foreach (var field in mod.GetType()
                        .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
                        .Where(field => typeof(ModSetting).IsAssignableFrom(field.FieldType)))
                    {
                        var modSetting = (ModSetting) field.GetValue(mod);
                        mod.ModSettings[field.Name] = modSetting;
                        if (modSetting.GetName() == default)
                        {
                            modSetting.SetName(field.Name);
                        }
                    }
                }
                catch (Exception e)
                {
                    MelonLogger.Warning($"Error initializing ModSettings for {mod.Info.Name}");
                    MelonLogger.Warning(e);
                }

                if (mod.ModSettings.Any())
                {
                    var fileName = $"{modSettingsDir}\\{mod.Info.Name}.json";
                    if (!File.Exists(fileName))
                    {
                        SaveModSettings(mod, modSettingsDir);
                    }
                }
            }
        }

        internal static void LoadModSettings(string modSettingsDir)
        {
            Directory.CreateDirectory(modSettingsDir);
            foreach (var mod in MelonHandler.Mods.OfType<BloonsMod>())
            {
                try
                {
                    var fileName = $"{modSettingsDir}\\{mod.Info.Name}.json";
                    if (File.Exists(fileName))
                    {
                        using (var file = File.OpenText(fileName))
                        using (var reader = new JsonTextReader(file))
                        {
                            while (reader.Read())
                            {
                                if (reader.Value != null && reader.TokenType == JsonToken.PropertyName)
                                {
                                    var name = (string) reader.Value;
                                    if (mod.ModSettings.ContainsKey(name))
                                    {
                                        reader.Read();
                                        try
                                        {
                                            mod.ModSettings[name].SetValue(reader.Value);
                                        }
                                        catch (Exception e)
                                        {
                                            MelonLogger.Warning($"Error loading ModSetting {name} of mod {mod.Info.Name}");
                                            MelonLogger.Warning(e);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MelonLogger.Warning($"Error loading ModSettings for {mod.Info.Name}");
                    MelonLogger.Warning(e);
                }
            }
        }

        private static void SaveModSettings(BloonsMod mod, string modSettingsDir)
        {
            if (!Directory.Exists(modSettingsDir))
            {
                Directory.CreateDirectory(modSettingsDir);
            }
            var fileName = $"{modSettingsDir}\\{mod.Info.Name}.json";
            using (var file = File.CreateText(fileName))
            using (var writer = new JsonTextWriter(file))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                foreach (var item in mod.ModSettings)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteValue(item.Value.GetValue());
                }
                writer.WriteEndObject();
            }
        }

        internal static void SaveModSettings(string modSettingsDir)
        {
            foreach (var mod in MelonHandler.Mods.OfType<BloonsMod>())
            {
                if (!mod.ModSettings.Any()) continue;
                SaveModSettings(mod, modSettingsDir);
            }
        }
        
    }
}