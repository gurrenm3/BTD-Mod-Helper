#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModFakeTower Class

Defines a "fake" tower that will be added as an entry to the shop but instead of placing down as normal, will just show its  
icon being placed with custom conditions and an action upon placement

```csharp
public abstract class ModFakeTower : BTD_Mod_Helper.Api.Towers.ModTower
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower') &#129106; ModFakeTower

Derived  
&#8627; [ModFakeTower&lt;T&gt;](BTD_Mod_Helper.Api.Towers.ModFakeTower_T_.md 'BTD_Mod_Helper.Api.Towers.ModFakeTower<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.BaseTower'></a>

## ModFakeTower.BaseTower Property

No base tower

```csharp
public sealed override string BaseTower { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.BottomPathUpgrades'></a>

## ModFakeTower.BottomPathUpgrades Property

The number of upgrades the tower has in it's 3rd / bottom path

```csharp
public sealed override int BottomPathUpgrades { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.HighlightTowers'></a>

## ModFakeTower.HighlightTowers Property

Set to true to be highlighting towers while placing the fake tower if placement is valid

```csharp
public virtual bool HighlightTowers { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.IncludeInMonkeyTeams'></a>

## ModFakeTower.IncludeInMonkeyTeams Property

Whether this tower should be allowed to be included in Monkey Teams

```csharp
public override bool IncludeInMonkeyTeams { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.IncludeInRogueLegends'></a>

## ModFakeTower.IncludeInRogueLegends Property

Whether this tower should be allowed to show up as an insta in Rogue Legends

```csharp
public override bool IncludeInRogueLegends { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.MiddlePathUpgrades'></a>

## ModFakeTower.MiddlePathUpgrades Property

The number of upgrades the tower has in it's 2nd / middle path

```csharp
public sealed override int MiddlePathUpgrades { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.ParagonMode'></a>

## ModFakeTower.ParagonMode Property

Defines whether / how this ModTower has a Paragon

```csharp
public sealed override BTD_Mod_Helper.Api.Towers.ParagonMode ParagonMode { get; }
```

#### Property Value
[ParagonMode](BTD_Mod_Helper.Api.Towers.ParagonMode.md 'BTD_Mod_Helper.Api.Towers.ParagonMode')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.PlacementEffect'></a>

## ModFakeTower.PlacementEffect Property

Effect to spawn on successful placement

```csharp
public virtual EffectModel PlacementEffect { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.Effects.EffectModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Effects.EffectModel 'Il2CppAssets.Scripts.Models.Effects.EffectModel')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.PlacementSound'></a>

## ModFakeTower.PlacementSound Property

Sound to play on successful placement

```csharp
public virtual AudioClipReference PlacementSound { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.AudioClipReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.AudioClipReference 'Il2CppNinjaKiwi.Common.ResourceUtils.AudioClipReference')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.PlacementSprite'></a>

## ModFakeTower.PlacementSprite Property

The sprite to show hovering in the world while placing the fake tower

```csharp
public virtual Sprite PlacementSprite { get; }
```

#### Property Value
[UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.Portrait'></a>

## ModFakeTower.Portrait Property

The Portrait for the 0-0-0 tower, by default "[Name]-Portrait"  
<br/>  
(Name of .png or .jpg, not including file extension)

```csharp
public override string Portrait { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.PortraitReference'></a>

## ModFakeTower.PortraitReference Property

If you're not going to use a custom .png for your Portrait, use this to directly control its SpriteReference

```csharp
public override SpriteReference PortraitReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.TopPathUpgrades'></a>

## ModFakeTower.TopPathUpgrades Property

The number of upgrades the tower has in it's 1st / top path

```csharp
public sealed override int TopPathUpgrades { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.TowerInventoryEnabled'></a>

## ModFakeTower.TowerInventoryEnabled Property

Enables tracking placements of these fake towers in the tower inventory

```csharp
public virtual bool TowerInventoryEnabled { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.CanPlaceAt(Vector2,Tower,string)'></a>

## ModFakeTower.CanPlaceAt(Vector2, Tower, string) Method

Controls whether the fake tower can be placed at a particular location

```csharp
public virtual bool CanPlaceAt(Vector2 at, Tower hoveredTower, ref string helperMessage);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.CanPlaceAt(Vector2,Tower,string).at'></a>

`at` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

location

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.CanPlaceAt(Vector2,Tower,string).hoveredTower'></a>

`hoveredTower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

tower being hovered, or null if none

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.CanPlaceAt(Vector2,Tower,string).helperMessage'></a>

`helperMessage` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

message that, if not null, will be shown to the user to explain why the spot they just tried to place in is not valid

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
if its a valid placement

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.IsValidCrosspath(int[])'></a>

## ModFakeTower.IsValidCrosspath(int[]) Method

Another way to modify the allowable crosspaths for your tower. By default, checks that the highest tier is at  
most 5, the next highest is at most 2, and the last one is 0  
<br/>  
Used in the default implementation of [TowerTiers()](BTD_Mod_Helper.Api.Towers.ModTower.md#BTD_Mod_Helper.Api.Towers.ModTower.TowerTiers() 'BTD_Mod_Helper.Api.Towers.ModTower.TowerTiers()')

```csharp
public sealed override bool IsValidCrosspath(params int[] tiers);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.IsValidCrosspath(int[]).tiers'></a>

`tiers` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.ModifyBaseTowerModel(TowerModel)'></a>

## ModFakeTower.ModifyBaseTowerModel(TowerModel) Method

Implemented by a ModTower to modify the base tower model before applying any/all ModUpgrades  
<br/>  
Things like the TowerModel's name, cost, tier, and upgrades are already taken care of before this point

```csharp
public override void ModifyBaseTowerModel(TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.ModifyBaseTowerModel(TowerModel).towerModel'></a>

`towerModel` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

The Base Tower Model

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.OnPlace(Vector2,TowerModel,Tower,float)'></a>

## ModFakeTower.OnPlace(Vector2, TowerModel, Tower, float) Method

Defines the actions that will be performed when this fake tower model is placed

```csharp
public abstract void OnPlace(Vector2 at, TowerModel towerModelFake, Tower hoveredTower, float cost);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.OnPlace(Vector2,TowerModel,Tower,float).at'></a>

`at` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.OnPlace(Vector2,TowerModel,Tower,float).towerModelFake'></a>

`towerModelFake` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

fake towermodel, will not actually place

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.OnPlace(Vector2,TowerModel,Tower,float).hoveredTower'></a>

`hoveredTower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

tower being hovered, or null if none

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.OnPlace(Vector2,TowerModel,Tower,float).cost'></a>

`cost` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.PlacementSideEffects(Vector3,IRootBehavior)'></a>

## ModFakeTower.PlacementSideEffects(Vector3, IRootBehavior) Method

Runs side effects like the placement effect and placement sound

```csharp
public void PlacementSideEffects(Vector3 position, IRootBehavior root=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.PlacementSideEffects(Vector3,IRootBehavior).position'></a>

`position` [Il2CppAssets.Scripts.Simulation.SMath.Vector3](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.SMath.Vector3 'Il2CppAssets.Scripts.Simulation.SMath.Vector3')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.PlacementSideEffects(Vector3,IRootBehavior).root'></a>

`root` [Il2CppAssets.Scripts.Simulation.Objects.IRootBehavior](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.IRootBehavior 'Il2CppAssets.Scripts.Simulation.Objects.IRootBehavior')

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.Purchase(Vector2,TowerModel,Tower)'></a>

## ModFakeTower.Purchase(Vector2, TowerModel, Tower) Method

Purchases this fake tower at a specific spot

```csharp
public void Purchase(Vector2 at, TowerModel towerModelFake, Tower hoveredTower);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.Purchase(Vector2,TowerModel,Tower).at'></a>

`at` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

position

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.Purchase(Vector2,TowerModel,Tower).towerModelFake'></a>

`towerModelFake` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

fake towermodel, will not actually place

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.Purchase(Vector2,TowerModel,Tower).hoveredTower'></a>

`hoveredTower` [Il2CppAssets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Towers.Tower 'Il2CppAssets.Scripts.Simulation.Towers.Tower')

tower being hovered, or null if none

<a name='BTD_Mod_Helper.Api.Towers.ModFakeTower.TowerTiers()'></a>

## ModFakeTower.TowerTiers() Method

Returns all the valid tiers for the TowerModels of this Tower

```csharp
public sealed override System.Collections.Generic.IEnumerable<int[]> TowerTiers();
```

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')