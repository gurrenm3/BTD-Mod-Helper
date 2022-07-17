#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## BloonExt Class

Extensions for Bloons

```csharp
public static class BloonExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BloonExt
### Methods

<a name='BTD_Mod_Helper.Extensions.BloonExt.CreateBloonToSim(thisAssets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonExt.CreateBloonToSim(this Bloon) Method

Creates a new BloonToSimulation based off of this Bloon and stores it for possible later use. It will automatically destroyed when this Bloon is destroyed

```csharp
public static Assets.Scripts.Unity.Bridge.BloonToSimulation CreateBloonToSim(this Assets.Scripts.Simulation.Bloons.Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonExt.CreateBloonToSim(thisAssets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[Assets.Scripts.Unity.Bridge.BloonToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Bridge.BloonToSimulation 'Assets.Scripts.Unity.Bridge.BloonToSimulation')

<a name='BTD_Mod_Helper.Extensions.BloonExt.GetBloonToSim(thisAssets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonExt.GetBloonToSim(this Bloon) Method

Return the existing BloonToSimulation for this specific Bloon.

```csharp
public static Assets.Scripts.Unity.Bridge.BloonToSimulation GetBloonToSim(this Assets.Scripts.Simulation.Bloons.Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonExt.GetBloonToSim(thisAssets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[Assets.Scripts.Unity.Bridge.BloonToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Bridge.BloonToSimulation 'Assets.Scripts.Unity.Bridge.BloonToSimulation')

<a name='BTD_Mod_Helper.Extensions.BloonExt.GetDisplayNode(thisAssets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonExt.GetDisplayNode(this Bloon) Method

Return the DisplayNode for this bloon

```csharp
public static Assets.Scripts.Simulation.Display.DisplayNode GetDisplayNode(this Assets.Scripts.Simulation.Bloons.Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonExt.GetDisplayNode(thisAssets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[Assets.Scripts.Simulation.Display.DisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Display.DisplayNode 'Assets.Scripts.Simulation.Display.DisplayNode')

<a name='BTD_Mod_Helper.Extensions.BloonExt.GetFactory(thisAssets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonExt.GetFactory(this Bloon) Method

Return the Factory that creates Bloons

```csharp
public static Assets.Scripts.Simulation.Factory.Factory<Assets.Scripts.Simulation.Bloons.Bloon> GetFactory(this Assets.Scripts.Simulation.Bloons.Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonExt.GetFactory(thisAssets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[Assets.Scripts.Simulation.Factory.Factory&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Factory.Factory-1 'Assets.Scripts.Simulation.Factory.Factory`1')[Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Factory.Factory-1 'Assets.Scripts.Simulation.Factory.Factory`1')

<a name='BTD_Mod_Helper.Extensions.BloonExt.GetId(thisAssets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonExt.GetId(this Bloon) Method

Return the Id of this Bloon

```csharp
public static int GetId(this Assets.Scripts.Simulation.Bloons.Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonExt.GetId(thisAssets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.BloonExt.GetUnityDisplayNode(thisAssets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonExt.GetUnityDisplayNode(this Bloon) Method

Return the UnityDisplayNode for this bloon. Is apart of DisplayNode. Needed to modify sprites

```csharp
public static Assets.Scripts.Unity.Display.UnityDisplayNode GetUnityDisplayNode(this Assets.Scripts.Simulation.Bloons.Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonExt.GetUnityDisplayNode(thisAssets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.BloonExt.RemoveBloonStatus(thisAssets.Scripts.Simulation.Bloons.Bloon,bool,bool,bool)'></a>

## BloonExt.RemoveBloonStatus(this Bloon, bool, bool, bool) Method

Remove current statuses from bloon

```csharp
public static void RemoveBloonStatus(this Assets.Scripts.Simulation.Bloons.Bloon bloon, bool removeCamo, bool removeFortify, bool removeRegrow);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonExt.RemoveBloonStatus(thisAssets.Scripts.Simulation.Bloons.Bloon,bool,bool,bool).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

the Bloon

<a name='BTD_Mod_Helper.Extensions.BloonExt.RemoveBloonStatus(thisAssets.Scripts.Simulation.Bloons.Bloon,bool,bool,bool).removeCamo'></a>

`removeCamo` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Should remove camo if present?

<a name='BTD_Mod_Helper.Extensions.BloonExt.RemoveBloonStatus(thisAssets.Scripts.Simulation.Bloons.Bloon,bool,bool,bool).removeFortify'></a>

`removeFortify` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Should remove fortify if present?

<a name='BTD_Mod_Helper.Extensions.BloonExt.RemoveBloonStatus(thisAssets.Scripts.Simulation.Bloons.Bloon,bool,bool,bool).removeRegrow'></a>

`removeRegrow` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Should remove regrow if present?

<a name='BTD_Mod_Helper.Extensions.BloonExt.SetBloonStatus(thisAssets.Scripts.Simulation.Bloons.Bloon,bool,bool,bool)'></a>

## BloonExt.SetBloonStatus(this Bloon, bool, bool, bool) Method

Set the statuses of the bloon. Will change bloonModel if one exists with these statuses

```csharp
public static void SetBloonStatus(this Assets.Scripts.Simulation.Bloons.Bloon bloon, bool setCamo, bool setFortified, bool setRegrow);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonExt.SetBloonStatus(thisAssets.Scripts.Simulation.Bloons.Bloon,bool,bool,bool).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

the Bloon

<a name='BTD_Mod_Helper.Extensions.BloonExt.SetBloonStatus(thisAssets.Scripts.Simulation.Bloons.Bloon,bool,bool,bool).setCamo'></a>

`setCamo` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Should have camo?

<a name='BTD_Mod_Helper.Extensions.BloonExt.SetBloonStatus(thisAssets.Scripts.Simulation.Bloons.Bloon,bool,bool,bool).setFortified'></a>

`setFortified` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Should have fortify?

<a name='BTD_Mod_Helper.Extensions.BloonExt.SetBloonStatus(thisAssets.Scripts.Simulation.Bloons.Bloon,bool,bool,bool).setRegrow'></a>

`setRegrow` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Should have regrow?

<a name='BTD_Mod_Helper.Extensions.BloonExt.SetCamo(thisAssets.Scripts.Simulation.Bloons.Bloon,bool)'></a>

## BloonExt.SetCamo(this Bloon, bool) Method

Set bloon to be camo or not. Will change bloonModel to camo version if it exists

```csharp
public static void SetCamo(this Assets.Scripts.Simulation.Bloons.Bloon bloon, bool isCamo);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonExt.SetCamo(thisAssets.Scripts.Simulation.Bloons.Bloon,bool).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

the Bloon

<a name='BTD_Mod_Helper.Extensions.BloonExt.SetCamo(thisAssets.Scripts.Simulation.Bloons.Bloon,bool).isCamo'></a>

`isCamo` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Should bloon be camo

<a name='BTD_Mod_Helper.Extensions.BloonExt.SetFortified(thisAssets.Scripts.Simulation.Bloons.Bloon,bool)'></a>

## BloonExt.SetFortified(this Bloon, bool) Method

Set bloon to be fortified or not. Will change bloonModel to fortified version if it exists

```csharp
public static void SetFortified(this Assets.Scripts.Simulation.Bloons.Bloon bloon, bool isFortified);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonExt.SetFortified(thisAssets.Scripts.Simulation.Bloons.Bloon,bool).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

the Bloon

<a name='BTD_Mod_Helper.Extensions.BloonExt.SetFortified(thisAssets.Scripts.Simulation.Bloons.Bloon,bool).isFortified'></a>

`isFortified` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Should bloon be fortified

<a name='BTD_Mod_Helper.Extensions.BloonExt.SetRegrow(thisAssets.Scripts.Simulation.Bloons.Bloon,bool)'></a>

## BloonExt.SetRegrow(this Bloon, bool) Method

Set bloon to be regrow or not. Will change bloonModel to regrow version if it exists

```csharp
public static void SetRegrow(this Assets.Scripts.Simulation.Bloons.Bloon bloon, bool isRegrow);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonExt.SetRegrow(thisAssets.Scripts.Simulation.Bloons.Bloon,bool).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

the Bloon

<a name='BTD_Mod_Helper.Extensions.BloonExt.SetRegrow(thisAssets.Scripts.Simulation.Bloons.Bloon,bool).isRegrow'></a>

`isRegrow` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Should bloon be regrow

<a name='BTD_Mod_Helper.Extensions.BloonExt.WasBloonPopped(thisAssets.Scripts.Simulation.Bloons.Bloon)'></a>

## BloonExt.WasBloonPopped(this Bloon) Method

Returns whether or not the bloon was popped rather than leaked.

```csharp
public static bool WasBloonPopped(this Assets.Scripts.Simulation.Bloons.Bloon bloon);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonExt.WasBloonPopped(thisAssets.Scripts.Simulation.Bloons.Bloon).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
True if it was popped, false if it was leaked or not destroyed yet

<a name='BTD_Mod_Helper.Extensions.BloonExt.WillPopBloon(thisAssets.Scripts.Simulation.Bloons.Bloon,Assets.Scripts.Simulation.Towers.Projectiles.Projectile)'></a>

## BloonExt.WillPopBloon(this Bloon, Projectile) Method

Tests whether a project will pop this bloon

```csharp
public static bool WillPopBloon(this Assets.Scripts.Simulation.Bloons.Bloon bloon, Assets.Scripts.Simulation.Towers.Projectiles.Projectile projectile);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonExt.WillPopBloon(thisAssets.Scripts.Simulation.Bloons.Bloon,Assets.Scripts.Simulation.Towers.Projectiles.Projectile).bloon'></a>

`bloon` [Assets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Bloons.Bloon 'Assets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Extensions.BloonExt.WillPopBloon(thisAssets.Scripts.Simulation.Bloons.Bloon,Assets.Scripts.Simulation.Towers.Projectiles.Projectile).projectile'></a>

`projectile` [Assets.Scripts.Simulation.Towers.Projectiles.Projectile](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Towers.Projectiles.Projectile 'Assets.Scripts.Simulation.Towers.Projectiles.Projectile')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')