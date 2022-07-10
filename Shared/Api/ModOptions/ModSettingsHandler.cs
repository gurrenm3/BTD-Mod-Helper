using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace BTD_Mod_Helper.Api.ModOptions;

internal class ModSettingsHandler
{
    internal static void InitializeModSettings()
    {
        if (!Directory.Exists(ModHelper.ModSettingsDirectory))
        {
            Directory.CreateDirectory(ModHelper.ModSettingsDirectory);
        }

        foreach (var mod in ModHelper.Mods)
        {
            mod.ModSettings.Clear();
            try
            {
                foreach (var field in mod.GetType()
                             .GetFields(BindingFlags.Public |
                                        BindingFlags.NonPublic |
                                        BindingFlags.Instance |
                                        BindingFlags.Static)
                             .Where(field => typeof(ModSetting).IsAssignableFrom(field.FieldType)))
                {
                    var modSetting = (ModSetting) field.GetValue(mod)!;
                    mod.ModSettings[field.Name] = modSetting;
                    modSetting.displayName ??= field.Name.Spaced();
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Error initializing ModSettings for {mod.Info.Name}");
                ModHelper.Warning(e);
            }

            if (mod.ModSettings.Any())
            {
                var fileName = mod.SettingsFilePath;
                if (!File.Exists(fileName))
                {
                    SaveModSettings(mod);
                }
            }
        }
    }

    internal static void LoadModSettings()
    {
        foreach (var mod in ModHelper.Mods)
        {
            try
            {
                var fileName = mod.SettingsFilePath;
                if (File.Exists(fileName))
                {
                    using var file = File.OpenText(fileName);
                    using var reader = new JsonTextReader(file);
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
                                    mod.ModSettings[name].Load(reader.Value);
                                }
                                catch (Exception e)
                                {
                                    ModHelper.Warning(
                                        $"Error loading ModSetting {name} of mod {mod.Info.Name}");
                                    ModHelper.Warning(e);
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

    private static void SaveModSettings(BloonsMod mod, bool initialSave = false)
    {
        if (!Directory.Exists(ModHelper.ModSettingsDirectory))
        {
            Directory.CreateDirectory(ModHelper.ModSettingsDirectory);
        }

        var fileName = mod.SettingsFilePath;
        using var file = File.CreateText(fileName);
        using var writer = new JsonTextWriter(file);
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

    internal static void SaveModSettings(bool initialSave = false)
    {
        foreach (var mod in ModHelper.Mods)
        {
            if (!mod.ModSettings.Any()) continue;
            SaveModSettings(mod, initialSave);
        }

        ModHelper.Msg("Successfully saved mod settings");
    }
}