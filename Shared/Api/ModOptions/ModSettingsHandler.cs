using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BTD_Mod_Helper.Api.ModMenu;
using MelonLoader.Utils;
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
                GetModSettings(mod, mod);
            }
            catch (Exception e)
            {
                ModHelper.Warning($"Error initializing ModSettings for {mod.Info.Name}");
                ModHelper.Warning(e);
            }
        }
    }

    internal static void GetModSettings(object obj, BloonsMod mod)
    {
        var fields = obj.GetType()
            .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
            .Where(field => typeof(ModSetting).IsAssignableFrom(field.FieldType));

        foreach (var field in fields)
        {
            var modSetting = (ModSetting) field.GetValue(obj)!;
            mod.ModSettings[field.Name] = modSetting;
            modSetting.displayName ??= field.Name.Spaced();
        }

        LoadModSettings(mod);
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
        }
        catch (Exception e)
        {
            ModHelper.Warning($"Error loading ModSettings for {mod.Info.Name}");
            ModHelper.Warning(e);
        }
    }

    internal static void SaveModSettings(BloonsMod mod, bool initialSave = false)
    {
        Directory.CreateDirectory(ModHelper.ModSettingsDirectory);
        var fileName = mod.SettingsFilePath;

        var json = new JObject();

        foreach (var (key, modSetting) in mod.ModSettings)
        {
            var value = modSetting.GetValue();
            if (value != null)
            {
                try
                {
                    if (initialSave || modSetting.OnSave())
                    {
                        json[key] = JToken.FromObject(value);
                    }
                }
                catch (Exception e)
                {
                    ModHelper.Warning($"Failed to save {key} for {mod.GetModName()}");
                    ModHelper.Warning(e);
                }
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

        if (!initialSave)
        {
            ModHelper.Msg($"Saved to {fileName}");
        }
    }

    internal static void SaveModSettings(bool initialSave = false)
    {
        foreach (var mod in ModHelper.Mods)
        {
            if (mod.ModSettings.Count == 0) continue;

            SaveModSettings(mod, initialSave);
        }

        ModHelper.Msg("Successfully saved mod settings");
    }
}