using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using Newtonsoft.Json;

namespace BTD_Mod_Helper.Api.ModOptions
{
    internal class ModSettingsHandler
    {
        internal static void InitializeModSettings(string modSettingsDir)
        {
            if (!Directory.Exists(modSettingsDir))
            {
                Directory.CreateDirectory(modSettingsDir);
            }
            foreach (var mod in ModHelper.Mods)
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
                        if (modSetting.displayName == default)
                        {
                            modSetting.displayName = Regex.Replace(field.Name, "(\\B[A-Z])", " $1");
                        }
                    }
                }
                catch (Exception e)
                {
                    ModHelper.Warning($"Error initializing ModSettings for {mod.Info.Name}");
                    ModHelper.Warning(e);
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
            foreach (var mod in ModHelper.Mods)
            {
                try
                {
                    var fileName = $"{modSettingsDir}\\{mod.GetModName()}.json";
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
                                            ModHelper.Warning($"Error loading ModSetting {name} of mod {mod.Info.Name}");
                                            ModHelper.Warning(e);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    ModHelper.Warning($"Error loading ModSettings for {mod.Info.Name}");
                    ModHelper.Warning(e);
                }
            }
        }

        private static void SaveModSettings(BloonsMod mod, string modSettingsDir, bool initialSave = false)
        {
            if (!Directory.Exists(modSettingsDir))
            {
                Directory.CreateDirectory(modSettingsDir);
            }
            var fileName = $"{modSettingsDir}\\{mod.GetModName()}.json";
            using (var file = File.CreateText(fileName))
            using (var writer = new JsonTextWriter(file))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                foreach (var (key, modSetting) in mod.ModSettings)
                {
                    if (!initialSave)
                    {
                        try
                        {
                            if (modSetting.OnSave())
                            {
                                writer.WritePropertyName(key);
                                writer.WriteValue(modSetting.GetValue());
                            }
                        }
                        catch (Exception e)
                        {
                            ModHelper.Warning($"Failed onSave action for setting {key}");
                            ModHelper.Warning(e);
                        }
                        modSetting.currentOption = null;
                    }
                    else
                    {
                        writer.WritePropertyName(key);
                        writer.WriteValue(modSetting.GetValue());
                    }
                }
                writer.WriteEndObject();
            }
        }

        internal static void SaveModSettings(string modSettingsDir, bool initialSave = false)
        {
            foreach (var mod in ModHelper.Mods)
            {
                if (!mod.ModSettings.Any()) continue;
                SaveModSettings(mod, modSettingsDir, initialSave);
            }
            ModHelper.Msg("Successfully saved mod settings");
        }
        
    }
}