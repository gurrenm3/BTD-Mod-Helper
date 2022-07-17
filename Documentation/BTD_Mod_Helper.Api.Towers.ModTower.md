#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModTower Class

Class for adding a custom Tower to the game. Use alongside [ModUpgrade](BTD_Mod_Helper.Api.Towers.ModUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModUpgrade') to define its upgrades,  
and optionally [ModTowerDisplay](BTD_Mod_Helper.Api.Display.ModTowerDisplay.md 'BTD_Mod_Helper.Api.Display.ModTowerDisplay') to define custom displays for it.

```csharp
public abstract class ModTower : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModTower

Derived  
&#8627; [ModHero](BTD_Mod_Helper.Api.Towers.ModHero.md 'BTD_Mod_Helper.Api.Towers.ModHero')  
&#8627; [ModTower&lt;T&gt;](BTD_Mod_Helper.Api.Towers.ModTower_T_.md 'BTD_Mod_Helper.Api.Towers.ModTower<T>')  
&#8627; [ModVanillaParagon](BTD_Mod_Helper.Api.Towers.ModVanillaParagon.md 'BTD_Mod_Helper.Api.Towers.ModVanillaParagon')
### Fields

<a name='BTD_Mod_Helper.Api.Towers.ModTower.MAGIC'></a>

## ModTower.MAGIC Field

The string to use for the Magic tower set

```csharp
protected const string MAGIC = "Magic";
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.MILITARY'></a>

## ModTower.MILITARY Field

The string to use for the Military tower set

```csharp
protected const string MILITARY = "Military";
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.PRIMARY'></a>

## ModTower.PRIMARY Field

The string to use for the Primary tower set

```csharp
protected const string PRIMARY = "Primary";
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.SUPPORT'></a>

## ModTower.SUPPORT Field

The string to use for the Support tower set

```csharp
protected const string SUPPORT = "Support";
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModTower.AlwaysIncludeInChallenge'></a>

## ModTower.AlwaysIncludeInChallenge Property

Whether to always make this tower be included in challenges / Bosses / Odysseys etc

```csharp
public virtual bool AlwaysIncludeInChallenge { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.BaseTower'></a>

## ModTower.BaseTower Property

The id of the default BTD Tower that your Tower is going to be copied from by default.

```csharp
public abstract string BaseTower { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.BottomPathUpgrades'></a>

## ModTower.BottomPathUpgrades Property

The number of upgrades the tower has in it's 3rd / bottom path

```csharp
public abstract int BottomPathUpgrades { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.Cost'></a>

## ModTower.Cost Property

The in game cost of this tower (on Medium difficulty)

```csharp
public abstract int Cost { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.DontAddToShop'></a>

## ModTower.DontAddToShop Property

Makes this Tower not actually add itself to the shop, useful for making subtowers

```csharp
public virtual bool DontAddToShop { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.Icon'></a>

## ModTower.Icon Property

The Icon for the Tower's purchase button, by default "[Name]-Icon"  
<br/>  
(Name of .png or .jpg, not including file extension)

```csharp
public virtual string Icon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.IconReference'></a>

## ModTower.IconReference Property

If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference

```csharp
public virtual Assets.Scripts.Utils.SpriteReference IconReference { get; }
```

#### Property Value
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.MiddlePathUpgrades'></a>

## ModTower.MiddlePathUpgrades Property

The number of upgrades the tower has in it's 2nd / middle path

```csharp
public abstract int MiddlePathUpgrades { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.ParagonMode'></a>

## ModTower.ParagonMode Property

Defines whether / how this ModTower has a Paragon

```csharp
public virtual BTD_Mod_Helper.Api.Towers.ParagonMode ParagonMode { get; }
```

#### Property Value
[ParagonMode](BTD_Mod_Helper.Api.Towers.ParagonMode.md 'BTD_Mod_Helper.Api.Towers.ParagonMode')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.PixelsPerUnit'></a>

## ModTower.PixelsPerUnit Property

For 2D towers, the ratio between pixels and display units. Higher number -> smaller tower.  
<seealso cref="P:BTD_Mod_Helper.Api.Towers.ModTower.Use2DModel"/><seealso cref="M:BTD_Mod_Helper.Api.Towers.ModTower.Get2DTexture(System.Int32[])"/>

```csharp
public virtual float PixelsPerUnit { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.Portrait'></a>

## ModTower.Portrait Property

The Portrait for the 0-0-0 tower, by default "[Name]-Portrait"  
<br/>  
(Name of .png or .jpg, not including file extension)

```csharp
public virtual string Portrait { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.PortraitReference'></a>

## ModTower.PortraitReference Property

If you're not going to use a custom .png for your Portrait, use this to directly control its SpriteReference

```csharp
public virtual Assets.Scripts.Utils.SpriteReference PortraitReference { get; }
```

#### Property Value
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.TopPathUpgrades'></a>

## ModTower.TopPathUpgrades Property

The number of upgrades the tower has in it's 1st / top path

```csharp
public abstract int TopPathUpgrades { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.TowerSet'></a>

## ModTower.TowerSet Property

The family of Monkeys that your Tower should be put in.  
<br/>  
For now, just use one of the default constants provided of PRIMARY, MILITARY, MAGIC, or SUPPORT.

```csharp
public abstract string TowerSet { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.Use2DModel'></a>

## ModTower.Use2DModel Property

Whether this Tower should display 2-dimensionally, and search for png images  
<br/><seealso cref="P:BTD_Mod_Helper.Api.Towers.ModTower.PixelsPerUnit"/><seealso cref="M:BTD_Mod_Helper.Api.Towers.ModTower.Get2DTexture(System.Int32[])"/>

```csharp
public virtual bool Use2DModel { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModTower.Get2DTexture(int[])'></a>

## ModTower.Get2DTexture(int[]) Method

If this is a 2D tower, gets the name of the .png to use for a given set of tiers  
<br/>  
Default Behavior Example: For CardMonkey with tiers 2-3-0, it would try (in order):  
CardMonkey-230, CardMonkey-X3X, CardMonkey-2XX, CardMonkey

```csharp
public virtual string Get2DTexture(int[] tiers);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModTower.Get2DTexture(int[]).tiers'></a>

`tiers` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.GetTowerIndex(System.Collections.Generic.List_Assets.Scripts.Models.TowerSets.TowerDetailsModel_)'></a>

## ModTower.GetTowerIndex(List<TowerDetailsModel>) Method

When adding this tower to the shop, gets the index at which to add the tower relative to the existing ones.  
<br/>  
By default, the tower will be put at the end of the TowerSet category that it's in.

```csharp
public virtual int GetTowerIndex(System.Collections.Generic.List<Assets.Scripts.Models.TowerSets.TowerDetailsModel> towerSet);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModTower.GetTowerIndex(System.Collections.Generic.List_Assets.Scripts.Models.TowerSets.TowerDetailsModel_).towerSet'></a>

`towerSet` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[Assets.Scripts.Models.TowerSets.TowerDetailsModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.TowerSets.TowerDetailsModel 'Assets.Scripts.Models.TowerSets.TowerDetailsModel')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModTower.ModifyBaseTowerModel(Assets.Scripts.Models.Towers.TowerModel)'></a>

## ModTower.ModifyBaseTowerModel(TowerModel) Method

Implemented by a ModTower to modify the base tower model before applying any/all ModUpgrades  
<br/>  
Things like the TowerModel's name, cost, tier, and upgrades are already taken care of before this point

```csharp
public abstract void ModifyBaseTowerModel(Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModTower.ModifyBaseTowerModel(Assets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

The Base Tower Model

<a name='BTD_Mod_Helper.Api.Towers.ModTower.TowerTiers()'></a>

## ModTower.TowerTiers() Method

Returns all the valid tiers for the TowerModels of this Tower

```csharp
public virtual System.Collections.Generic.IEnumerable<int[]> TowerTiers();
```

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')