using System;
using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Simulation.Towers;
namespace BTD_Mod_Helper.Api.Towers;

/// <summary>
/// Mod Content class to easily save and load data that should persist between sessions. All saved data are strings.
/// </summary>
public abstract class ModTowerSaveData : ModContent
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public override void Register()
    {
    }

    /// <summary>
    /// The associated base tower id of this ModTowerSaveData.
    /// </summary>
    public abstract string TowerBaseId { get; }

    /// <summary>
    /// Returns whether this ModTowerSaveData should save for the provided tower or not.
    /// </summary>
    /// <param name="tower">The tower to save for</param>
    /// <returns>Whether this ModTowerSaveData should save this tower or not.</returns>
    public virtual bool ShouldSave(Tower tower)
    {
        return tower.towerModel.BaseId == TowerBaseId;
    }
    
    /// <summary>
    /// Saves this ModSaveData using the returned encoded string.
    /// </summary>
    /// <returns>The encoded save data.</returns>
    /// <param name="tower">The tower getting saved.</param>
    public abstract string Save(Tower tower);

    /// <summary>
    /// Loads this ModSaveData from the provided encoded string.
    /// </summary>
    /// <param name="data">The encoded save data.</param>
    /// <param name="tower">The tower getting loaded.</param>
    public abstract void Load(string data, Tower tower);

    internal static void LoadAll(Tower tower, TowerSaveDataModel towerData)
    {
        try
        {
            foreach (var saveData in GetContent<ModTowerSaveData>().Where(saveData => saveData.ShouldSave(tower)))
            {
                if (towerData.metaData.TryGetValue(saveData.Id, out string data))
                {
                    try
                    {
                        saveData.Load(data, tower);
                    }
                    catch (Exception e)
                    {
                        ModHelper.Error($"Failed to save {saveData.Id}!");
                        ModHelper.Error(e);
                    }
                }
            }
        }
        catch (Exception e)
        {
            ModHelper.Error($"Failed to load all ModTowerSaveData for tower ${tower.towerModel.name} ({tower.Id})!");
            ModHelper.Error(e);
            throw;
        }
    }
    internal static void SaveAll(Tower tower, TowerSaveDataModel towerData)
    {
        try
        {
            HashSet<string> saved = new HashSet<string>();
            foreach (var saveData in GetContent<ModTowerSaveData>().Where(saveData => saveData.ShouldSave(tower)))
            {
                if (!saved.Add(saveData.Id))
                {
                    ModHelper.Warning($"Mod save data with ID {saveData.Id} is already saved! Skipping.");
                    continue;
                }
                try
                {
                    string data = saveData.Save(tower);
                    towerData.metaData.Add(saveData.Id, data);
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
            ModHelper.Error($"Failed to save all ModTowerSaveData for tower ${tower.towerModel.name} ({tower.Id})!");
            ModHelper.Error(e);
            throw;
        }
    }
}

/// <summary>
/// Generic version of <see cref="ModTowerSaveData"/>.
/// </summary>
public abstract class ModTowerSaveData<T> : ModTowerSaveData where T : ModTower
{
    public override string TowerBaseId => ModContent.TowerID<T>();
}