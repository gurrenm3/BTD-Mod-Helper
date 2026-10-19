#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModTowerSaveData Class

Mod Content class to easily save and load data that should persist between sessions. All saved data are strings.

```csharp
public abstract class ModTowerSaveData : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModTowerSaveData

Derived  
&#8627; [ModTowerSaveData&lt;T&gt;](BTD_Mod_Helper.Api.Towers.ModTowerSaveData_T_.md 'BTD_Mod_Helper.Api.Towers.ModTowerSaveData<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSaveData.TowerBaseId'></a>

## ModTowerSaveData.TowerBaseId Property

The associated base tower id of this ModTowerSaveData.

```csharp
public abstract string TowerBaseId { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSaveData.Load(string,Tower)'></a>

## ModTowerSaveData.Load(string, Tower) Method

Loads this ModSaveData from the provided encoded string.

```csharp
public abstract void Load(string data, Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSaveData.Load(string,Tower).data'></a>

`data` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The encoded save data.

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSaveData.Load(string,Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

The tower getting loaded.

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSaveData.Register()'></a>

## ModTowerSaveData.Register() Method

<inheritdoc/>

```csharp
public override void Register();
```

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSaveData.Save(Tower)'></a>

## ModTowerSaveData.Save(Tower) Method

Saves this ModSaveData using the returned encoded string.

```csharp
public abstract string Save(Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSaveData.Save(Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

The tower getting saved.

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The encoded save data.

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSaveData.ShouldSave(Tower)'></a>

## ModTowerSaveData.ShouldSave(Tower) Method

Returns whether this ModTowerSaveData should save for the provided tower or not.

```csharp
public virtual bool ShouldSave(Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSaveData.ShouldSave(Tower).tower'></a>

`tower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

The tower to save for

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether this ModTowerSaveData should save this tower or not.