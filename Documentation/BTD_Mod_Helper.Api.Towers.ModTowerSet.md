#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModTowerSet Class

A custom collection of ModTowers

```csharp
public abstract class ModTowerSet : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModTowerSet
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.AllowInRestrictedModes'></a>

## ModTowerSet.AllowInRestrictedModes Property

Whether this Tower Set should still be allowed to appear in Primary Only, Military Only, Magic Only

```csharp
public virtual bool AllowInRestrictedModes { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.Button'></a>

## ModTowerSet.Button Property

Name of .png file for the group button used in the Monkeys menu

```csharp
public virtual string Button { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.ButtonReference'></a>

## ModTowerSet.ButtonReference Property

SpriteReference for the button

```csharp
public virtual SpriteReference ButtonReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.Container'></a>

## ModTowerSet.Container Property

Name of .png file for the background for towers in the Monkeys menu and the in game shop

```csharp
public virtual string Container { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.ContainerLarge'></a>

## ModTowerSet.ContainerLarge Property

Name of .png file for the background used for non-paragon upgrades in the Upgrade screen

```csharp
public virtual string ContainerLarge { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.ContainerLargeReference'></a>

## ModTowerSet.ContainerLargeReference Property

SpriteReference for the large container

```csharp
public virtual SpriteReference ContainerLargeReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.ContainerReference'></a>

## ModTowerSet.ContainerReference Property

SpriteReference for the container

```csharp
public virtual SpriteReference ContainerReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.Description'></a>

## ModTowerSet.Description Property

Unused

```csharp
public sealed override string Description { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.DisplayNamePlural'></a>

## ModTowerSet.DisplayNamePlural Property

Unused

```csharp
public sealed override string DisplayNamePlural { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.Portrait'></a>

## ModTowerSet.Portrait Property

Name of .png file for the background for in game portraits

```csharp
public virtual string Portrait { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.PortraitReference'></a>

## ModTowerSet.PortraitReference Property

SpriteReference for the portrait

```csharp
public virtual SpriteReference PortraitReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.Seat'></a>

## ModTowerSet.Seat Property

Name of .png file for the seat to use in Odyssey mode (theoretically)

```csharp
public virtual string Seat { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.SeatReference'></a>

## ModTowerSet.SeatReference Property

SpriteReference for the Seat

```csharp
public virtual SpriteReference SeatReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.Set'></a>

## ModTowerSet.Set Property

TowerSet enum for this modded TowerSet

```csharp
public TowerSet Set { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.TowerSets.TowerSet](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerSet 'Il2CppAssets.Scripts.Models.TowerSets.TowerSet')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.TowerSetInt'></a>

## ModTowerSet.TowerSetInt Property

Internal int enum value used for this ModdedTowerSet

```csharp
public int TowerSetInt { get; set; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.GetTowerSetIndex(System.Collections.Generic.List_TowerSet_)'></a>

## ModTowerSet.GetTowerSetIndex(List<TowerSet>) Method

Where to place this ModTowerSet in relation to other towerSets. By default at the end.  
<br/>

```csharp
public virtual int GetTowerSetIndex(System.Collections.Generic.List<TowerSet> towerSets);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.GetTowerSetIndex(System.Collections.Generic.List_TowerSet_).towerSets'></a>

`towerSets` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.TowerSets.TowerSet](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerSet 'Il2CppAssets.Scripts.Models.TowerSets.TowerSet')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

The current towerSets that already exist

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.GetTowerStartIndex(System.Collections.Generic.List_TowerDetailsModel_)'></a>

## ModTowerSet.GetTowerStartIndex(List<TowerDetailsModel>) Method

The position to start placing ModTowers of this ModTowerSet in relation to other towers  
<br/>  
By default, will determine the position based on GetTowerSetIndex  
<br/>

```csharp
public virtual int GetTowerStartIndex(System.Collections.Generic.List<TowerDetailsModel> towerSet);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.GetTowerStartIndex(System.Collections.Generic.List_TowerDetailsModel_).towerSet'></a>

`towerSet` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel 'Il2CppAssets.Scripts.Models.TowerSets.TowerDetailsModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

The set of all current tower details

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModTowerSet.Load()'></a>

## ModTowerSet.Load() Method

No loading multiple instances of a ModTowerSet

```csharp
public sealed override System.Collections.Generic.IEnumerable<BTD_Mod_Helper.Api.ModContent> Load();
```

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')