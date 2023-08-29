**This guide assumes that you already have at least a basic knowledge of C#, and have set up a modding environment as explained on this wiki.**

Creating custom Bosses comes in the form of creating classes that extend `ModBoss`. `ModBoss` itself inherits from `ModBloon`, so you can use almost all of the same methods and properties as you would for a ModBloon. The main difference is that you need to override `ModifyBaseBloon` instead of `ModifyBaseBloonModel` and you cannot make it `Regrow` or override `KeepBaseId`. A roundset is automatically generated for your Boss, spawning the correct tiers at the correct round.

# [ModBoss](/docs/BTD_Mod_Helper.Api.Bloons.Bosses.ModBosses)

## Required Overrides

`ModifyBaseBloon(BloonModel bloonModel)` is the only required method for you to override, and it's the most important. Here you will handle actually making your Boss different from the base Bloon, which is a BAD.

## Optional Overrides

`OnSpawn`: Called when the boss is spawned, it will be called before the current tier's `OnSpawn` method.

`OnLeak`: Called when the boss is leaked, it will be called before the current tier's `OnLeak` method.

`OnPop`: Called when the boss is popped, it will be called before the current tier's `OnPop` method.

`OnDamage`: Called when the boss takes damage, it will be called before the current tier's `OnDamage` method.

`SkullReached`: Called when the boss reaches a skull, it will be called before the current tier's `SkullReached` method.

`TimerTick`: Called when the boss timer triggers, only called if `CurrentTier.Interval` is not null. Will be called before the current tier's `TimerTick` method.

`Description`: The description of the boss, used in the roundset select screen.

`BossMusic`: The music that plays when the Boss appears, and loops until its defeated. This is an `AudioClip` object, which you can get using the `ModContent.GetAudioClip<T>()` method.

`BossMusicName`: The display name of `BossMusic`, will be shown in the pause menu

`ModifyRoundModels`: Called to modify individual rounds for the boss roundset. It is the equivalent of [ModRoundSet.ModifyRoundModels](Making-a-Custom-Round-Set#modifying-rounds).

## Visuals

You can use a `ModBloonDisplay` to set the default visuals for your Boss, which will the base display applied to every tier.

If you would like to modify the visuals for specific tiers, you can use the `ModBossTierDisplay<BossClass>` class, where `BossClass` is your `ModBoss` extending class, and override `Tiers`.

`HudIcon`: The icon used for the "Boss Appears in X rounds" panel and health bar, if not set, `Icon` will be used instead.

`AlivePortrait`: The portrait used in the game over screen when the boss defeats the player.

`DefeatedPortrait`: The portrait used in the game over screen after the boss has been defeated.

# ModBossTier(s)

Allows you to determine what rounds a boss spawns on, and stats for each specific round. There is no hardcoded limit to the amount of tiers a boss can have.
For every tier you want to add, you need to create a class that extends `ModBossTier<BossClass>`, where `BossClass` is your `ModBoss` extending class that this upgrade is for. When you do, you'll have to override the following:

## Required Properties

`Skulls`: The amount of skulls the boss has on the tier.

`Round`: The round that the tier spawns on.

`ModifyBaseBoss`: The method that will be called to modify the boss for the tier. This is the equivalent of `ModifyBaseBloon` for `ModBoss`.

## Optional Properties

`OnSpawn`: Called when the tier is spawned, it will be called after the boss's `OnSpawn` method.

`OnLeak`: Called when the tier is leaked, it will be called after the boss's `OnLeak` method.

`OnPop`: Called when the tier is popped, it will be called after the boss's `OnPop` method.

`OnDamage`: Called when the tier takes damage, it will be called after the boss's `OnDamage` method.

`SkullReached`: Called when the tier reaches a skull, it will be called after the boss's `SkullReached` method.

`TimerTick`: Called when the tier's timer triggers, only called if `Interval` is not null. Will be called after the boss's `TimerTick` method.

`Interval`: The amount of time in seconds between each `TimerTick` call, if set to null, the timer will not be created.

`SkullPositions`: The positions of the skulls on the boss's health bar, as a float from 0 to 1, if not set, the skulls will be evenly spaced out.

`PreventFallThrough`: Determines if the boss's health should go down while it's skull effect is active (only applicable to existing, ingame actions).

`TriggerImmediately`: Determines if the timer triggers when the boss is spawned (only applicable to existing, ingame actions)

# Example

```cs
coming soon
```
