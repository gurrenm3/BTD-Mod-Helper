#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModTowerDisplay Class

A ModDisplay that will automatically apply to a ModTower for specific tiers

```csharp
public abstract class ModTowerDisplay : BTD_Mod_Helper.Api.Display.ModDisplay
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md 'BTD_Mod_Helper.Api.Display.ModDisplay') &#129106; ModTowerDisplay

Derived  
&#8627; [ModTowerCustomDisplay](BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay.md 'BTD_Mod_Helper.Api.Display.ModTowerCustomDisplay')  
&#8627; [ModTowerDisplay&lt;T&gt;](BTD_Mod_Helper.Api.Display.ModTowerDisplay_T_.md 'BTD_Mod_Helper.Api.Display.ModTowerDisplay<T>')
### Fields

<a name='BTD_Mod_Helper.Api.Display.ModTowerDisplay.TotalParagonDisplays'></a>

## ModTowerDisplay.TotalParagonDisplays Field

Number of different Paragon displays that are used by default

```csharp
protected const int TotalParagonDisplays = 5;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModTowerDisplay.DisplayCategory'></a>

## ModTowerDisplay.DisplayCategory Property

The DisplayCategory to use for the DisplayModel

```csharp
public override DisplayCategory DisplayCategory { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayCategory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayCategory 'Il2CppAssets.Scripts.Models.GenericBehaviors.DisplayCategory')

<a name='BTD_Mod_Helper.Api.Display.ModTowerDisplay.ParagonDisplayIndex'></a>

## ModTowerDisplay.ParagonDisplayIndex Property

A number between 0 and 4 (inclusive) representing which set of paragon degrees this display applies to  
<br/>  
0: Degree 1 - 20  
<br/>  
1: Degree 21 - 40  
<br/>  
2: Degree 41 - 60  
<br/>  
3: Degree 61 - 80  
<br/>  
4: Degree 81 - 100  
<br/>  
If you don't have one for every index, then the next highest one will be used

```csharp
public virtual int ParagonDisplayIndex { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Display.ModTowerDisplay.Tower'></a>

## ModTowerDisplay.Tower Property

The ModTower that this ModDisplay is used for

```csharp
public abstract BTD_Mod_Helper.Api.Towers.ModTower Tower { get; }
```

#### Property Value
[ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower')
### Methods

<a name='BTD_Mod_Helper.Api.Display.ModTowerDisplay.ApplyToTower(TowerModel)'></a>

## ModTowerDisplay.ApplyToTower(TowerModel) Method

Applies this ModTowerDisplay to the towerModel. Override to change how this applies, i.e. making it  
apply to an AttackModel instead

```csharp
public virtual void ApplyToTower(TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModTowerDisplay.ApplyToTower(TowerModel).towerModel'></a>

`towerModel` [Il2CppAssets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.TowerModel 'Il2CppAssets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Api.Display.ModTowerDisplay.IsParagon(int[])'></a>

## ModTowerDisplay.IsParagon(int[]) Method

If the tower tiers make it count as a Paragon

```csharp
protected bool IsParagon(int[] tiers);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModTowerDisplay.IsParagon(int[]).tiers'></a>

`tiers` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Display.ModTowerDisplay.ModifyDisplayNode(UnityDisplayNode)'></a>

## ModTowerDisplay.ModifyDisplayNode(UnityDisplayNode) Method

Alters the UnityDisplayNode that was copied from the one used by [BaseDisplay](BTD_Mod_Helper.Api.Display.ModDisplay.md#BTD_Mod_Helper.Api.Display.ModDisplay.BaseDisplay 'BTD_Mod_Helper.Api.Display.ModDisplay.BaseDisplay')<br/>  
By default, this will change the main texture of the first SkinnedMeshRenderer of the node to that of a  
png with the same name as the class

```csharp
public override void ModifyDisplayNode(UnityDisplayNode node);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModTowerDisplay.ModifyDisplayNode(UnityDisplayNode).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

The UnityDisplayNode

<a name='BTD_Mod_Helper.Api.Display.ModTowerDisplay.UseForTower(int[])'></a>

## ModTowerDisplay.UseForTower(int[]) Method

Returns true if this display should be used by its Tower for the given tiers

```csharp
public abstract bool UseForTower(int[] tiers);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModTowerDisplay.UseForTower(int[]).tiers'></a>

`tiers` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The potential tiers of the tower

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If the Tower should have this display