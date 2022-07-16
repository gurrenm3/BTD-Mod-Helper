#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModUpgrade<T> Class

A convenient generic class for specifying the ModTower that this ModUpgrade is for

```csharp
public abstract class ModUpgrade<T> : BTD_Mod_Helper.Api.Towers.ModUpgrade
    where T : BTD_Mod_Helper.Api.Towers.ModTower
```
#### Type parameters

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade_T_.T'></a>

`T`

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModUpgrade](BTD_Mod_Helper.Api.Towers.ModUpgrade.md 'BTD_Mod_Helper.Api.Towers.ModUpgrade') &#129106; ModUpgrade<T>
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModUpgrade_T_.Tower'></a>

## ModUpgrade<T>.Tower Property

The tower that this is an upgrade for

```csharp
public override BTD_Mod_Helper.Api.Towers.ModTower Tower { get; }
```

#### Property Value
[ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower')