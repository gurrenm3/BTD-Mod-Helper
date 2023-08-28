#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Bloons.Bosses](README.md#BTD_Mod_Helper.Api.Bloons.Bosses 'BTD_Mod_Helper.Api.Bloons.Bosses')

## ModBoss Class

Class for adding a new boss to the game

```csharp
public abstract class ModBoss : BTD_Mod_Helper.Api.Bloons.ModBloon
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; [ModBloon](BTD_Mod_Helper.Api.Bloons.ModBloon.md 'BTD_Mod_Helper.Api.Bloons.ModBloon') &#129106; ModBoss
### Properties

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.AlivePortrait'></a>

## ModBoss.AlivePortrait Property

The Portrait used in the game over screen when the boss defeats the player  
<br/>  
(Name of .png or .jpg, not including file extension)

```csharp
public virtual string AlivePortrait { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.AlivePortraitReference'></a>

## ModBoss.AlivePortraitReference Property

If you're not going to use a custom .png for your AlivePortrait, use this to directly control its SpriteReference

```csharp
public virtual SpriteReference AlivePortraitReference { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.AmbientMapFX'></a>

## ModBoss.AmbientMapFX Property

The object that will be placed on the boss' spawn point on the track

```csharp
public virtual string AmbientMapFX { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.AmbientMapFXReference'></a>

## ModBoss.AmbientMapFXReference Property

If you're not going to use a custom display for your TrackFX, use this to directly control its SpriteReference

```csharp
public virtual PrefabReference AmbientMapFXReference { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Utils.PrefabReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.PrefabReference 'Il2CppAssets.Scripts.Utils.PrefabReference')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.BaseBloon'></a>

## ModBoss.BaseBloon Property

The Bloon in the game that this should copy from as a base. Use BloonType.[Name]

```csharp
public sealed override string BaseBloon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.BossMusic'></a>

## ModBoss.BossMusic Property

The sound played when the boss spawns

```csharp
public virtual AudioClip BossMusic { get; }
```

#### Property Value
[UnityEngine.AudioClip](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.AudioClip 'UnityEngine.AudioClip')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.BossMusicName'></a>

## ModBoss.BossMusicName Property

The display name of [BossMusic](BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.md#BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.BossMusic 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.BossMusic'), will be shown in the pause menu

```csharp
public virtual string BossMusicName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.CurrentTier'></a>

## ModBoss.CurrentTier Property

The current spawned tier of the boss, may be null

```csharp
public BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier CurrentTier { get; set; }
```

#### Property Value
[ModBossTier](BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.md 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.DefeatedPortrait'></a>

## ModBoss.DefeatedPortrait Property

The Portrait used in the game over screen when the boss has been defeated  
<br/>  
(Name of .png or .jpg, not including file extension)

```csharp
public virtual string DefeatedPortrait { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.DefeatedPortraitReference'></a>

## ModBoss.DefeatedPortraitReference Property

If you're not going to use a custom .png for your DefeatedPortrait, use this to directly control its SpriteReference

```csharp
public virtual SpriteReference DefeatedPortraitReference { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.HudIcon'></a>

## ModBoss.HudIcon Property

The icon used for the "Boss Appears in X rounds" panel and health bar  
<br/>  
(Name of .png or .jpg, not including file extension)

```csharp
public virtual string HudIcon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.HudIconReference'></a>

## ModBoss.HudIconReference Property

If you're not going to use a custom .png for your HudIcon, use this to directly control its SpriteReference

```csharp
public virtual SpriteReference HudIconReference { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.KeepBaseId'></a>

## ModBoss.KeepBaseId Property

Set this to true if you're making another version of the BaseBloon, like a Fortified Red Bloon

```csharp
public sealed override bool KeepBaseId { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.Regrow'></a>

## ModBoss.Regrow Property

Add the necessary properties to make this a Regrow Bloon

```csharp
public sealed override bool Regrow { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.RegrowRate'></a>

## ModBoss.RegrowRate Property

The regrow rate

```csharp
public sealed override float RegrowRate { get; }
```

#### Property Value
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.RegrowsTo'></a>

## ModBoss.RegrowsTo Property

The ID of the bloon that this should regrow into

```csharp
public sealed override string RegrowsTo { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.TrackFX'></a>

## ModBoss.TrackFX Property

The object that will be placed on the boss' spawn point on the track

```csharp
public virtual string TrackFX { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.TrackFXReference'></a>

## ModBoss.TrackFXReference Property

If you're not going to use a custom display for your TrackFX, use this to directly control its SpriteReference

```csharp
public virtual PrefabReference TrackFXReference { get; }
```

#### Property Value
[Il2CppAssets.Scripts.Utils.PrefabReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.PrefabReference 'Il2CppAssets.Scripts.Utils.PrefabReference')
### Methods

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.ModifyBaseBloon(BloonModel)'></a>

## ModBoss.ModifyBaseBloon(BloonModel) Method

Apply your custom modifications to the base bloonModel

```csharp
public abstract void ModifyBaseBloon(BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.ModifyBaseBloon(BloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.ModifyBaseBloonModel(BloonModel)'></a>

## ModBoss.ModifyBaseBloonModel(BloonModel) Method

Apply your custom modifications to the base bloon

```csharp
public sealed override void ModifyBaseBloonModel(BloonModel bloonModel);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.ModifyBaseBloonModel(BloonModel).bloonModel'></a>

`bloonModel` [Il2CppAssets.Scripts.Models.Bloons.BloonModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Bloons.BloonModel 'Il2CppAssets.Scripts.Models.Bloons.BloonModel')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.ModifyRoundModels(RoundModel,int)'></a>

## ModBoss.ModifyRoundModels(RoundModel, int) Method

Called to modify rounds for the boss roundset

```csharp
public virtual void ModifyRoundModels(RoundModel roundModel, int round);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.ModifyRoundModels(RoundModel,int).roundModel'></a>

`roundModel` [Il2CppAssets.Scripts.Models.Rounds.RoundModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Rounds.RoundModel 'Il2CppAssets.Scripts.Models.Rounds.RoundModel')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.ModifyRoundModels(RoundModel,int).round'></a>

`round` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

### Remarks
Used in the same way as [ModifyRoundModels(RoundModel, int)](BTD_Mod_Helper.Api.Bloons.ModRoundSet.md#BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyRoundModels(RoundModel,int) 'BTD_Mod_Helper.Api.Bloons.ModRoundSet.ModifyRoundModels(RoundModel, int)')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.OnDamage(Bloon,float)'></a>

## ModBoss.OnDamage(Bloon, float) Method

Called when the boss takes damage, will be called before the current tier's [OnDamage(Bloon, float)](BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.md#BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnDamage(Bloon,float) 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnDamage(Bloon, float)')

```csharp
public virtual void OnDamage(Bloon bloon, float totalAmount);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.OnDamage(Bloon,float).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.OnDamage(Bloon,float).totalAmount'></a>

`totalAmount` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.OnLeak(Bloon)'></a>

## ModBoss.OnLeak(Bloon) Method

Called when the boss is leaked, will be called before the current tier's [OnLeak(Bloon)](BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.md#BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnLeak(Bloon) 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnLeak(Bloon)')

```csharp
public virtual void OnLeak(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.OnLeak(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.OnPop(Bloon)'></a>

## ModBoss.OnPop(Bloon) Method

Called when the boss is popped, will be called before the current tier's [OnPop(Bloon)](BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.md#BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnPop(Bloon) 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnPop(Bloon)')

```csharp
public virtual void OnPop(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.OnPop(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.OnSpawn(Bloon)'></a>

## ModBoss.OnSpawn(Bloon) Method

Called when the boss is spawned, will be called before the current tier's [OnSpawn(Bloon)](BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.md#BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnSpawn(Bloon) 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.OnSpawn(Bloon)')

```csharp
public virtual void OnSpawn(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.OnSpawn(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

### Remarks
Called when loading saves and continuing from checkpoints as well

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.SkullReached(Bloon,int)'></a>

## ModBoss.SkullReached(Bloon, int) Method

Called when the boss reaches a skull, will be called before the current tier's [SkullReached(Bloon, int)](BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.md#BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.SkullReached(Bloon,int) 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.SkullReached(Bloon, int)')

```csharp
public virtual void SkullReached(Bloon bloon, int skullNumber);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.SkullReached(Bloon,int).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.SkullReached(Bloon,int).skullNumber'></a>

`skullNumber` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.TimerTick(Bloon)'></a>

## ModBoss.TimerTick(Bloon) Method

Called when the boss timer triggers, only called if [Interval](BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.md#BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.Interval 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.Interval') is not null. Will be called before the current tier's [TimerTick(Bloon)](BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.md#BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.TimerTick(Bloon) 'BTD_Mod_Helper.Api.Bloons.Bosses.ModBossTier.TimerTick(Bloon)')

```csharp
public virtual void TimerTick(Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Bloons.Bosses.ModBoss.TimerTick(Bloon).bloon'></a>

`bloon` [Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')