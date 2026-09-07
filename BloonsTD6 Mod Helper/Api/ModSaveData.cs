using System;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Models.Profile;
namespace BTD_Mod_Helper.Api;

/// <summary>
/// Mod Content class to easily save and load data that should persist between sessions. All saved data are strings.
/// </summary>
public abstract class ModSaveData : ModContent
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override void Register()
    {
        
    }

    /// <summary>
    /// Saves this ModSaveData using the returned encoded string.
    /// </summary>
    /// <returns>The encoded save data.</returns>
    public abstract string Save();
    /// <summary>
    /// Loads this ModSaveData from the provided encoded string.
    /// </summary>
    /// <param name="data">The encoded save data.</param>
    public abstract void Load(string data);
    
    internal static void SaveAll(MapSaveDataModel save)
    {
        try
        {
            HashSet<string> saved = new HashSet<string>();
            foreach (var saveData in GetContent<ModSaveData>())
            {
                try
                {
                    if (!saved.Add(saveData.Id))
                    {
                        ModHelper.Warning($"Mod save data with ID {saveData.Id} is already saved! Skipping.");
                        continue;
                    }

                    string data = saveData.Save();
                    save.metaData.Add(saveData.Id, data);
                }
                catch (Exception e)
                {
                    ModHelper.Error($"Failed to save {saveData.Id}!");
                    ModHelper.Error(e);
                }
            }
        }
        catch (Exception e)
        {
            ModHelper.Error("Error saving mod data!");
            ModHelper.Error(e);
            throw;
        }
    }

    internal static void LoadAll(MapSaveDataModel save)
    {
        try
        {
            foreach (var saveData in GetContent<ModSaveData>())
            {
                try
                {
                    if (!save.metaData.TryGetValue(saveData.Id, out string data))
                    {
                        continue;
                    }
                    
                    saveData.Load(data);
                }
                catch (Exception e)
                {
                    ModHelper.Error($"Failed to load {saveData.Id}!");
                    ModHelper.Error(e);
                }
            }
        }
        catch (Exception e)
        {
            ModHelper.Error("Error loading mod data!");
            ModHelper.Error(e);
            throw;
        }
    }
}