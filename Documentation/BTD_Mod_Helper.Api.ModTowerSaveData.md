#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModTowerSaveData Class

Mod Content class to easily save and load data that should persist between sessions. All saved data are strings.

```csharp
public abstract class ModTowerSaveData : ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](https://github.com/gurrenm3/BTD-Mod-Helper/blob/master/Documentation/BTD_Mod_Helper.Api.ModContent.md 'ModConent') &#129106; ModTowerSaveData

### Properties

<a name='BTD_Mod_Helper.Api.ModTowerSaveData.TowerBaseId'></a>

## ModTowerSaveData.TowerBaseId

The associated base tower id of this ModTowerSaveData.
```cs
public abstract string TowerBaseId { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.Api.ModTowerSaveData.ShouldSave(Tower)'></a>

## ModTowerSaveData.ShouldSave(Tower) Method

Returns whether this ModTowerSaveData should save for the provided tower or not.

```csharp
public virtual bool ShouldSave(Tower tower);
```

#### Parameters

<a name='BTD_Mod_Helper.Api.ModTowerSaveData.ShouldSave(Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')
The tower to save/load for


#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.Boolean') Whether this ModTowerSaveData should save this tower or not.

## ModTowerSaveData.Save(Tower) Method

Saves this ModTowerSaveData using the returned encoded string for the provided tower.

```csharp
public abstract string Save(Tower tower);
```

#### Parameters

<a name='BTD_Mod_Helper.Api.ModTowerSaveData.Save(Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')
The tower getting saved.


#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String') The encoded save data.

<a name='BTD_Mod_Helper.Api.ModTowerSaveData.Load(string, Tower)'></a>

## ModTowerSaveData.Load(string, ModTowerSaveData) Method

Loads this ModTowerSaveData from the provided encoded string for the provided tower.

```csharp
public abstract void Load(string data);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModTowerSaveData.Load(string, Tower).data'></a>

`data` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
The encoded save data.

<a name='BTD_Mod_Helper.Api.ModTowerSaveData.Load(string, Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')
The tower getting loaded.