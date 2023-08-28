#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Bloons.Bosses](README.md#BTD_Mod_Helper.Api.Bloons.Bosses 'BTD_Mod_Helper.Api.Bloons.Bosses')

## ModBossTier<T> Class

A convenient generic class for specifying the ModBoss that this ModBossTier uses

```csharp
public abstract class ModBossTier<T> : BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier
    where T : BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModBossTier](BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.md 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier') &#129106; ModBossTier<T>
### Properties

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier_T_.Boss'></a>

## ModBossTier<T>.Boss Property

The boss this tier belongs to

```csharp
public override BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss Boss { get; }
```

#### Property Value
[ModBoss](BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.md 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss')