#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Towers](README.md#BTD_Mod_Helper.Api.Towers 'BTD_Mod_Helper.Api.Towers')

## ModSubTower Class

Helper class for making a subtower

```csharp
public abstract class ModSubTower : BTD_Mod_Helper.Api.Towers.ModTower
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModTower](BTD_Mod_Helper.Api.Towers.ModTower.md 'BTD_Mod_Helper.Api.Towers.ModTower') &#129106; ModSubTower

Derived  
&#8627; [ModSubTower&lt;T&gt;](BTD_Mod_Helper.Api.Towers.ModSubTower_T_.md 'BTD_Mod_Helper.Api.Towers.ModSubTower<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Towers.ModSubTower.BottomPathUpgrades'></a>

## ModSubTower.BottomPathUpgrades Property

The number of upgrades the tower has in it's 3rd / bottom path

```csharp
public sealed override int BottomPathUpgrades { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModSubTower.Cost'></a>

## ModSubTower.Cost Property

The in game cost of this tower (on Medium difficulty)

```csharp
public override int Cost { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModSubTower.DontAddToShop'></a>

## ModSubTower.DontAddToShop Property

Makes this Tower not actually add itself to the shop, useful for making subtowers

```csharp
public sealed override bool DontAddToShop { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Towers.ModSubTower.MiddlePathUpgrades'></a>

## ModSubTower.MiddlePathUpgrades Property

The number of upgrades the tower has in it's 2nd / middle path

```csharp
public sealed override int MiddlePathUpgrades { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModSubTower.Order'></a>

## ModSubTower.Order Property

The order that this ModContent will be loaded/registered in by Mod Helper.  
Useful for changing the ordering that it will appear in in-game relative to other content of this type in your mod,  
or for making certain content load before others like may be necessary for sub-towers.  
Default/0 will use arbitrary ordering.

```csharp
protected override int Order { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Towers.ModSubTower.TopPathUpgrades'></a>

## ModSubTower.TopPathUpgrades Property

The number of upgrades the tower has in it's 1st / top path

```csharp
public sealed override int TopPathUpgrades { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')