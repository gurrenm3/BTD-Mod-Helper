#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModTowerSaveData Class

Mod Content class to easily save and load data that should persist between sessions. All saved data are strings.

```csharp
public abstract class ModTowerSaveData<T> : ModTowerSaveData 
    where T : ModTower
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.ModTowerSaveData_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](https://github.com/gurrenm3/BTD-Mod-Helper/blob/master/Documentation/BTD_Mod_Helper.Api.ModContent.md 'ModConent') &#129106; [ModTowerSaveData](https://github.com/gurrenm3/BTD-Mod-Helper/blob/master/Documentation/BTD_Mod_Helper.Api.ModTowerSaveData.md) &#129106; ModTowerSaveData

### Properties

<a name='BTD_Mod_Helper.Api.ModTowerSaveData.TowerBaseId'></a>

## ModTowerSaveData.TowerBaseId

The associated base tower id of this ModTowerSaveData.
```cs
public override string TowerBaseId { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')