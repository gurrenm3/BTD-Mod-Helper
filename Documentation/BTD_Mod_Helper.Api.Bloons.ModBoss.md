#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Bloons](README.md#BTD_Mod_Helper.Api.Bloons 'BTD_Mod_Helper.Api.Bloons')

## ModBoss Class

Class for adding a new boss to the game

```csharp
public abstract class ModBoss : BTD_Mod_Helper.Api.Bloons.ModBloon
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModBloon](BTD_Mod_Helper.Api.Bloons.ModBloon.md 'BTD_Mod_Helper.Api.Bloons.ModBloon') &#129106; ModBoss
### Properties

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.AlwaysDefeatOnLeak'></a>

## ModBoss.AlwaysDefeatOnLeak Property

Whether the boss should always cause defeat on leak

```csharp
public virtual bool AlwaysDefeatOnLeak { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.BaseBloon'></a>

## ModBoss.BaseBloon Property

The Bloon in the game that this should copy from as a base. Use BloonType.[Name]

```csharp
public sealed override string BaseBloon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.BlockRounds'></a>

## ModBoss.BlockRounds Property

Whether the boss should block rounds from spawning

```csharp
public virtual bool BlockRounds { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.Health'></a>

## ModBoss.Health Property

The health of the boss

```csharp
public virtual float Health { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.KeepBaseId'></a>

## ModBoss.KeepBaseId Property

Set this to true if you're making another version of the BaseBloon, like a Fortified Red Bloon

```csharp
public sealed override bool KeepBaseId { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.Regrow'></a>

## ModBoss.Regrow Property

Add the necessary properties to make this a Regrow Bloon

```csharp
public sealed override bool Regrow { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.RegrowRate'></a>

## ModBoss.RegrowRate Property

The regrow rate

```csharp
public sealed override float RegrowRate { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.RegrowsTo'></a>

## ModBoss.RegrowsTo Property

The ID of the bloon that this should regrow into

```csharp
public sealed override string RegrowsTo { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.SpawnDelay'></a>

## ModBoss.SpawnDelay Property

The delay(in seconds) before the boss spawns on a round defined in [SpawnRounds](BTD_Mod_Helper.Api.Bloons.ModBoss.md#BTD_Mod_Helper.Api.Bloons.ModBoss.SpawnRounds 'BTD_Mod_Helper.Api.Bloons.ModBoss.SpawnRounds')

```csharp
public virtual float SpawnDelay { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.SpawnRounds'></a>

## ModBoss.SpawnRounds Property

The rounds the boss should spawn on

```csharp
public abstract System.Collections.Generic.IEnumerable<int> SpawnRounds { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.Speed'></a>

## ModBoss.Speed Property

The speed of the boss, 4.5 is the default for a BAD and 25 is the default for a red bloon

```csharp
public virtual float Speed { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.UseIconAsDisplay'></a>

## ModBoss.UseIconAsDisplay Property

Whether this Bloon should use its Icon as its display

```csharp
public sealed override bool UseIconAsDisplay { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.ModifyForRound(BloonModel,int)'></a>

## ModBoss.ModifyForRound(BloonModel, int) Method

Modifies the boss before it is spawned, based on the round

```csharp
public virtual BloonModel ModifyForRound(BloonModel bloonModel, int round);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.ModifyForRound(BloonModel,int).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.ModifyForRound(BloonModel,int).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.OnLeak(Bloon)'></a>

## ModBoss.OnLeak(Bloon) Method

Called when the boss is leaked

```csharp
public virtual void OnLeak(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.OnLeak(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.OnPop(Bloon)'></a>

## ModBoss.OnPop(Bloon) Method

Called when the boss is popped

```csharp
public virtual void OnPop(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.OnPop(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.OnSpawn(Bloon)'></a>

## ModBoss.OnSpawn(Bloon) Method

Called when the boss is spawned

```csharp
public virtual void OnSpawn(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.ModBoss.OnSpawn(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')