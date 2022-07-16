#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Towers](index.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModUpgrade Class

A class used to create an Upgrade for a Tower

```csharp
public abstract class ModUpgrade : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModUpgrade

Derived  
&#8627; [ModHeroLevel](BTD_Mod_Helper.Api.Towers.ModHeroLevel.md 'BTD_Mod_Helper.Api.Towers.ModHeroLevel')  
&#8627; [ModParagonUpgrade](BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModParagonUpgrade')  
&#8627; [ModUpgrade&lt;T&gt;](BTD_Mod_Helper.Api.Towers.ModUpgrade_T_.md 'BTD_Mod_Helper.Api.Towers.ModUpgrade<T>')
### Fields

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.BOTTOM'></a>

## ModUpgrade.BOTTOM Field

Path ID for the Bottom path

```csharp
protected const int BOTTOM = 2;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.MIDDLE'></a>

## ModUpgrade.MIDDLE Field

Path ID for the Middle path

```csharp
protected const int MIDDLE = 1;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.TOP'></a>

## ModUpgrade.TOP Field

Path ID for the Top path

```csharp
protected const int TOP = 0;
```

#### Field Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.ConfirmationBody'></a>

## ModUpgrade.ConfirmationBody Property

The body text for the confirmation popup, if needed

```csharp
public virtual string ConfirmationBody { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.ConfirmationTitle'></a>

## ModUpgrade.ConfirmationTitle Property

The title for the confirmation popup, if needed

```csharp
public virtual string ConfirmationTitle { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.Cost'></a>

## ModUpgrade.Cost Property

How much the upgrade costs on Medium difficulty

```csharp
public abstract int Cost { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.Icon'></a>

## ModUpgrade.Icon Property

The file name without extension for the Icon for this upgrade  
<br/>  
The Tower follows the default Bloons method of picking a Portrait: choose the highest tier upgrade, and if  
there's a tie, choose Mid > Top > Bot (for whatever reason)  
<br/>  
By default is the same file name as the tower followed by -Icon

```csharp
public virtual string Icon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.IconReference'></a>

## ModUpgrade.IconReference Property

If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference

```csharp
public virtual Assets.Scripts.Utils.SpriteReference IconReference { get; }
```

#### Property Value
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.NeedsConfirmation'></a>

## ModUpgrade.NeedsConfirmation Property

Whether this upgrade requires a confirmation popup

```csharp
public virtual bool NeedsConfirmation { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.Path'></a>

## ModUpgrade.Path Property

The upgrade path  
Use [TOP](BTD_Mod_Helper.Api.Towers.ModUpgrade.md#BTD_Mod_Helper.Api.Towers.ModUpgrade.TOP 'BTD_Mod_Helper.Api.Towers.ModUpgrade.TOP'), [MIDDLE](BTD_Mod_Helper.Api.Towers.ModUpgrade.md#BTD_Mod_Helper.Api.Towers.ModUpgrade.MIDDLE 'BTD_Mod_Helper.Api.Towers.ModUpgrade.MIDDLE'), [BOTTOM](BTD_Mod_Helper.Api.Towers.ModUpgrade.md#BTD_Mod_Helper.Api.Towers.ModUpgrade.BOTTOM 'BTD_Mod_Helper.Api.Towers.ModUpgrade.BOTTOM')

```csharp
public abstract int Path { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.Portrait'></a>

## ModUpgrade.Portrait Property

The file name without extension for the Portrait for this upgrade  
<br/>  
By default is the same file name as the tower followed by -Portrait

```csharp
public virtual string Portrait { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.PortraitReference'></a>

## ModUpgrade.PortraitReference Property

If you're not going to use a custom .png for your Portrait, use this to directly control its SpriteReference

```csharp
public virtual Assets.Scripts.Utils.SpriteReference PortraitReference { get; }
```

#### Property Value
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.Priority'></a>

## ModUpgrade.Priority Property

Custom priority to make this upgrade applied sooner (increased priority) or later (decreased priority)  
when the TowerModel is being constructed

```csharp
public virtual int Priority { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.RegistrationPriority'></a>

## ModUpgrade.RegistrationPriority Property

ModUpgrades register second

```csharp
protected sealed override float RegistrationPriority { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.Tier'></a>

## ModUpgrade.Tier Property

The upgrade tier, 1 for Tier 1 Upgrades, 2 for Tier 2, etc...

```csharp
public abstract int Tier { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.Tower'></a>

## ModUpgrade.Tower Property

The tower that this is an upgrade for

```csharp
public abstract BTD_Mod_Helper.Api.Towers.ModTower Tower { get; }
```

#### Property Value
[ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.XpCost'></a>

## ModUpgrade.XpCost Property

Xp Cost for the upgrade. Meaningless usually because custom heroes automatically are automatically unlocked.

```csharp
public virtual int XpCost { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')
### Methods

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.ApplyUpgrade(Assets.Scripts.Models.Towers.TowerModel)'></a>

## ModUpgrade.ApplyUpgrade(TowerModel) Method

Apply the effects that this upgrade has onto a TowerModel  
<br/>  
The TowerModel's tier(s), applied upgrades and other info will already be correct, so this is mostly about  
changing the TowerModel's behavior  
<br/>  
The default ordering of upgrade application is to do them in ascending order of tier, doing Top then Mid  
then Bot at each tier. This can be changed using [Priority](BTD_Mod_Helper.Api.Towers.ModUpgrade.md#BTD_Mod_Helper.Api.Towers.ModUpgrade.Priority 'BTD_Mod_Helper.Api.Towers.ModUpgrade.Priority').

```csharp
public abstract void ApplyUpgrade(Assets.Scripts.Models.Towers.TowerModel towerModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.ApplyUpgrade(Assets.Scripts.Models.Towers.TowerModel).towerModel'></a>

`towerModel` [Assets.Scripts.Models.Towers.TowerModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.TowerModel 'Assets.Scripts.Models.Towers.TowerModel')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.GetUpgradeModel()'></a>

## ModUpgrade.GetUpgradeModel() Method

If you really need to override the way that the ModUpgrade makes its UpgradeModel, go ahead

```csharp
public virtual Assets.Scripts.Models.Towers.Upgrades.UpgradeModel GetUpgradeModel();
```

#### Returns
[Assets.Scripts.Models.Towers.Upgrades.UpgradeModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Upgrades.UpgradeModel 'Assets.Scripts.Models.Towers.Upgrades.UpgradeModel')

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.RestrictUpgrading(Assets.Scripts.Simulation.Towers.Tower)'></a>

## ModUpgrade.RestrictUpgrading(Tower) Method

Allows you to dynamically allow an upgrade to not be purchasable based on the InGame values of a Tower

```csharp
public virtual bool RestrictUpgrading(Assets.Scripts.Simulation.Towers.Tower tower);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade.RestrictUpgrading(Assets.Scripts.Simulation.Towers.Tower).tower'></a>

`tower` [Assets.Scripts.Simulation.Towers.Tower](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Tower 'Assets.Scripts.Simulation.Towers.Tower')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
If