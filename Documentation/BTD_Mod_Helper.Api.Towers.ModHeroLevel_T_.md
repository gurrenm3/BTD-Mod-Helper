#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModHeroLevel<T> Class

Convenient generic class for specifying the ModHero that this ModHeroLevel is for

```csharp
public abstract class ModHeroLevel<T> : BTD_Mod_Helper.Api.Towers.ModHeroLevel
    where T : BTD_Mod_Helper.Api.Towers.ModHero, new()
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModUpgrade](BTD_Mod_Helper.Api.Towers.ModUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModUpgrade') &#129106; [ModHeroLevel](BTD_Mod_Helper.Api.Towers.ModHeroLevel.md 'BTD_Mod_Helper.Api.Towers.ModHeroLevel') &#129106; ModHeroLevel<T>
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModHeroLevel_T_.Hero'></a>

## ModHeroLevel<T>.Hero Property

The tower that this is an upgrade for

```csharp
public override BTD_Mod_Helper.Api.Towers.ModHero Hero { get; }
```

#### Property Value
[ModHero](BTD_Mod_Helper.Api.Towers.ModHero.md 'BTD_Mod_Helper.Api.Towers.ModHero')