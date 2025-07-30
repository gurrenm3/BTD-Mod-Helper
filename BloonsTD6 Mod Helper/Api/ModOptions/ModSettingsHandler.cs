using System;
using System.IO;
using System.Linq;
using System.Reflection;
using BTD_Mod_Helper.Api.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace BTD_Mod_Helper.Api.ModOptions;

internal static class ModSettingsHandler
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
                CreateModSettings(mod, mod);
                LoadModSettings(mod);
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Error initializing ModSettings for {mod.Info.Name}");
                ModHelper.Warning(e);
            }
        }
    }

    internal static void CreateModSettings(IModSettings obj, BloonsMod mod)
    {
        var fields = obj.GetType()
            .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
            .Where(field => typeof(ModSetting).IsAssignableFrom(field.FieldType));

        foreach (var field in fields)
        {
            var modSetting = (ModSetting) field.GetValue(obj)!;
            modSetting.Name = field.Name;
            mod.ModSettings[modSetting.Name] = modSetting;
            modSetting.displayName ??= modSetting.Name.Spaced();
            modSetting.source = obj;
            modSetting.mod = mod;
        }
    }

    internal static void LoadModSettings(BloonsMod mod)
    {
        try
        {
            var fileName = mod.SettingsFilePath;
            if (File.Exists(fileName))
            {
                var json = JObject.Parse(File.ReadAllText(fileName));
                foreach (var (name, token) in json)
                {
                    if (mod.ModSettings.ContainsKey(name) && token != null)
                    {
                        try
                        {
                            var modSetting = mod.ModSettings[name];
                            modSetting.Load(token.ToObject(modSetting.GetSettingType()));
                        }
                        catch (Exception e)
                        {
                            ModHelper.Warning($"Error loading ModSetting {name} of mod {mod.Info.Name}");
                            ModHelper.Warning(e);
                        }
                    }
                }
                mod.OnLoadSettings(json);
            }

            foreach (var (key, value) in mod.ModSettings)
            {
                value.displayNameKey = ModContent.Localize(mod, key + " Setting Name", value.displayName);
                if (!string.IsNullOrEmpty(value.description))
                {
                    value.descriptionKey = ModContent.Localize(mod, key + " Setting Description", value.description);
                }
                if (value.category is {displayNameKey: null})
                {
                    value.category.displayNameKey = ModContent.Localize(mod, value.category.displayName + " Category",
                        value.category.displayName);
                }
            }
        }
        catch (Exception e)
        {
            ModHelper.Warning($"Error loading ModSettings for {mod.Info.Name}");
            ModHelper.Warning(e);
        }
    }

    internal static void SaveModSettings(BloonsMod mod, bool runOnSave = true, bool logSuccess = true)
    {
        Directory.CreateDirectory(ModHelper.ModSettingsDirectory);
        var fileName = mod.SettingsFilePath;

        var json = new JObject();

        foreach (var (key, modSetting) in mod.ModSettings)
        {
            if (modSetting.GetValue() == null) continue;

            try
            {
                if (!runOnSave || modSetting.OnSave())
                {
                    json[key] = JToken.FromObject(modSetting.GetValue());
                }
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Failed to save {key} for {mod.GetModName()}");
                ModHelper.Warning(e);
            }
        }

        try
        {
            mod.OnSaveSettings(json);
        }
        catch (Exception e)
        {
            ModHelper.Warning(e);
        }

        File.WriteAllText(fileName, json.ToString(Formatting.Indented));

        // TODO fix the real source of this extremely strange bug
        foreach (var file in Directory.EnumerateFiles(ModHelper.ModSettingsDirectory).Where(s => s.EndsWith("..json")))
        {
            try
            {
                var correctFile = file.Replace("..json", "");
                if (File.Exists(correctFile))
                {
                    File.Delete(file);
                }
                else
                {
                    File.Move(file, correctFile);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        if (logSuccess)
        {
            ModHelper.Msg($"Saved to {fileName}");
        }
    }

    internal static void SaveModSettings(bool runOnSave = true, bool logSuccess = true)
    {
        foreach (var mod in ModHelper.Mods)
        {
            if (!mod.ModSettings.Any()) continue;

            SaveModSettings(mod, runOnSave, logSuccess);
        }

        if (logSuccess)
        {
            ModHelper.Msg("Successfully saved mod settings");
        }
    }

    internal static void LoadModSettings()
    {
        foreach (var mod in ModHelper.Mods)
        {
            if (!mod.ModSettings.Any()) continue;

            LoadModSettings(mod);
        }
    }
}