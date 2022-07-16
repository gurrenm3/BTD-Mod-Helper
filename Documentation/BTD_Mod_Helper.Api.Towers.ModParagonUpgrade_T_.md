#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Towers](index.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModParagonUpgrade<T> Class

A convenient generic class for specifying the ModTower that this ModParagonUpgrade is for

```csharp
public abstract class ModParagonUpgrade<T> : BTD_Mod_Helper.Api.Towers.ModParagonUpgrade
    where T : BTD_Mod_Helper.Api.Towers.ModTower
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModUpgrade](BTD_Mod_Helper.Api.Towers.ModUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModUpgrade') &#129106; [ModParagonUpgrade](BTD_Mod_Helper.Api.Towers.ModParagonUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModParagonUpgrade') &#129106; ModParagonUpgrade<T>
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModParagonUpgrade_T_.Tower'></a>

## ModParagonUpgrade<T>.Tower Property

The tower that this is an upgrade for

```csharp
public override BTD_Mod_Helper.Api.Towers.ModTower Tower { get; }
```

#### Property Value
[ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower')