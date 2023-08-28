#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Bloons.Bosses](README.md#BTD_Mod_Helper.Api.Bloons.Bosses 'BTD_Mod_Helper.Api.Bloons.Bosses')

## ModBossTier Class

Base class for a boss tier

```csharp
public abstract class ModBossTier : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModBossTier

Derived  
&#8627; [ModBossTier&lt;T&gt;](BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier_T_.md 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier<T>')
### Properties

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.Boss'></a>

## ModBossTier.Boss Property

The boss this tier belongs to

```csharp
public abstract BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss Boss { get; }
```

#### Property Value
[ModBoss](BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.md 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.Interval'></a>

## ModBossTier.Interval Property

Interval between ticks for the boss' timer, if null, the timer will not be created

```csharp
public virtual System.Nullable<float> Interval { get; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.PreventFallThrough'></a>

## ModBossTier.PreventFallThrough Property

Determines if the boss's health should go down while it's skull effect is on

```csharp
public virtual bool PreventFallThrough { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.Round'></a>

## ModBossTier.Round Property

The round this tier appears on

```csharp
public abstract int Round { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.SkullPositions'></a>

## ModBossTier.SkullPositions Property

Positions of the skulls as a float from 0 to 1

```csharp
public virtual float[] SkullPositions { get; set; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

### Remarks
If not specified, the skulls' position will be placed evenly (3 skulls => 0.75, 0.5, 0.25)

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.Skulls'></a>

## ModBossTier.Skulls Property

Amount of skulls the boss has

```csharp
public abstract int Skulls { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.TriggerImmediately'></a>

## ModBossTier.TriggerImmediately Property

Determines if the timer starts immediately

```csharp
public virtual bool TriggerImmediately { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.ModifyBaseBoss(BloonModel)'></a>

## ModBossTier.ModifyBaseBoss(BloonModel) Method

Modifies the base boss bloon

```csharp
public abstract void ModifyBaseBoss(BloonModel bossModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.ModifyBaseBoss(BloonModel).bossModel'></a>

`bossModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnDamage(Bloon,float)'></a>

## ModBossTier.OnDamage(Bloon, float) Method

Called when the boss takes damage

```csharp
public virtual void OnDamage(Bloon bloon, float totalAmount);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnDamage(Bloon,float).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnDamage(Bloon,float).totalAmount'></a>

`totalAmount` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnLeak(Bloon)'></a>

## ModBossTier.OnLeak(Bloon) Method

Called when the boss is leaked

```csharp
public virtual void OnLeak(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnLeak(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnPop(Bloon)'></a>

## ModBossTier.OnPop(Bloon) Method

Called when the boss is popped

```csharp
public virtual void OnPop(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnPop(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnSpawn(Bloon)'></a>

## ModBossTier.OnSpawn(Bloon) Method

Called when the boss is spawned

```csharp
public virtual void OnSpawn(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnSpawn(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

### Remarks
Called when loading saves and continuing from checkpoints as well

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.SkullReached(Bloon,int)'></a>

## ModBossTier.SkullReached(Bloon, int) Method

Called when the boss reaches a skull

```csharp
public virtual void SkullReached(Bloon bloon, int skullNumber);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.SkullReached(Bloon,int).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.SkullReached(Bloon,int).skullNumber'></a>

`skullNumber` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.TimerTick(Bloon)'></a>

## ModBossTier.TimerTick(Bloon) Method

Called when the boss timer triggers, only called if [Interval](BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.md#BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.Interval 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.Interval') is not null

```csharp
public virtual void TimerTick(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.TimerTick(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')