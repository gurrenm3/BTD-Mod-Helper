#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModTowerSaveData<T> Class

Generic version of [ModTowerSaveData](BTD_Mod_Helper.Api.Towers.ModTowerSaveData.md 'BTD_Mod_Helper.Api.Towers.ModTowerSaveData').

```csharp
public abstract class ModTowerSaveData<T> : BTD_Mod_Helper.Api.Towers.ModTowerSaveData
    where T : BTD_Mod_Helper.Api.Towers.ModTower
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSaveData_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModTowerSaveData](BTD_Mod_Helper.Api.Towers.ModTowerSaveData.md 'BTD_Mod_Helper.Api.Towers.ModTowerSaveData') &#129106; ModTowerSaveData<T>
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSaveData_T_.TowerBaseId'></a>

## ModTowerSaveData<T>.TowerBaseId Property

The associated base tower id of this ModTowerSaveData.

```csharp
public override string TowerBaseId { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')