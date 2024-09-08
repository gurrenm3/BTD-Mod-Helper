#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModHeroLevel Class

Class representing the UpgradeModel and changes for a particular Level for a ModHero

```csharp
public abstract class ModHeroLevel : BTD_Mod_Helper.Api.Towers.ModUpgrade
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModUpgrade](BTD_Mod_Helper.Api.Towers.ModUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModUpgrade') &#129106; ModHeroLevel

Derived  
&#8627; [ModHeroLevel&lt;T&gt;](BTD_Mod_Helper.Api.Towers.ModHeroLevel_T_.md 'BTD_Mod_Helper.Api.Towers.ModHeroLevel<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.AbilityDescription'></a>

## ModHeroLevel.AbilityDescription Property

Description of the ability added at this level, if any

```csharp
public virtual string AbilityDescription { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.AbilityName'></a>

## ModHeroLevel.AbilityName Property

DisplayName field of the AbilityModel added at this level, if any

```csharp
public virtual string AbilityName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.ConfirmationBody'></a>

## ModHeroLevel.ConfirmationBody Property

No confirmation on hero upgrades

```csharp
public sealed override string ConfirmationBody { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.ConfirmationTitle'></a>

## ModHeroLevel.ConfirmationTitle Property

No confirmation on hero upgrades

```csharp
public sealed override string ConfirmationTitle { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.Cost'></a>

## ModHeroLevel.Cost Property

Hero upgrades have no cost

```csharp
public sealed override int Cost { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.Hero'></a>

## ModHeroLevel.Hero Property

The tower that this is an upgrade for

```csharp
public abstract BTD_Mod_Helper.Api.Towers.ModHero Hero { get; }
```

#### Property Value
[ModHero](BTD_Mod_Helper.Api.Towers.ModHero.md 'BTD_Mod_Helper.Api.Towers.ModHero')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.Icon'></a>

## ModHeroLevel.Icon Property

Hero upgrades don't have individual icons

```csharp
public sealed override string Icon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.IconReference'></a>

## ModHeroLevel.IconReference Property

Hero upgrades don't have individual icons

```csharp
public sealed override SpriteReference IconReference { get; }
```

#### Property Value
[Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference 'Il2CppNinjaKiwi.Common.ResourceUtils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.Level'></a>

## ModHeroLevel.Level Property

What level this

```csharp
public abstract int Level { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.Name'></a>

## ModHeroLevel.Name Property

Internal naming scheme for hero levels

```csharp
public sealed override string Name { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.NeedsConfirmation'></a>

## ModHeroLevel.NeedsConfirmation Property

No confirmation on hero upgrades

```csharp
public sealed override bool NeedsConfirmation { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.Path'></a>

## ModHeroLevel.Path Property

All hero upgrades count as top path

```csharp
public sealed override int Path { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.Portrait'></a>

## ModHeroLevel.Portrait Property

The filename without extension for the portrait this Level should make the hero start using  
<br/>  
By default, the [Portrait](BTD_Mod_Helper.Api.Towers.ModTower.md#BTD_Mod_Helper.Api.Towers.ModTower.Portrait 'BTD_Mod_Helper.Api.Towers.ModTower.Portrait') of the [ModHero](BTD_Mod_Helper.Api.Towers.ModHero.md 'BTD_Mod_Helper.Api.Towers.ModHero') with the [Level](BTD_Mod_Helper.Api.Towers.ModHeroLevel.md#BTD_Mod_Helper.Api.Towers.ModHeroLevel.Level 'BTD_Mod_Helper.Api.Towers.ModHeroLevel.Level') appended,  
e.g. "IndustrialFarmer-Portrait3"

```csharp
public override string Portrait { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.Tier'></a>

## ModHeroLevel.Tier Property

The upgrade's tier is the hero's level.

```csharp
public sealed override int Tier { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.Tower'></a>

## ModHeroLevel.Tower Property

The ModTower is the ModHero

```csharp
public sealed override BTD_Mod_Helper.Api.Towers.ModTower Tower { get; }
```

#### Property Value
[ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower')

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel.XpCost'></a>

## ModHeroLevel.XpCost Property

How much XP the hero needs to get to go from the previous level to this level.  
<br/>  
Default is calculated the same way Ninja Kiwi does it using

```csharp
public override int XpCost { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')