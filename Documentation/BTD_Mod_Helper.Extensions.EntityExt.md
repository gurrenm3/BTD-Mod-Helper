#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## EntityExt Class

Extensions for Entities

```csharp
public static class EntityExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntityExt
### Methods

<a name='BTD_Mod_Helper.Extensions.EntityExt.GetDisplayNode(thisAssets.Scripts.Simulation.Objects.Entity)'></a>

## EntityExt.GetDisplayNode(this Entity) Method

Get the DisplayNode for this Entity

```csharp
public static Assets.Scripts.Simulation.Display.DisplayNode GetDisplayNode(this Assets.Scripts.Simulation.Objects.Entity entity);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EntityExt.GetDisplayNode(thisAssets.Scripts.Simulation.Objects.Entity).entity'></a>

`entity` [Assets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Objects.Entity 'Assets.Scripts.Simulation.Objects.Entity')

#### Returns
[Assets.Scripts.Simulation.Display.DisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Display.DisplayNode 'Assets.Scripts.Simulation.Display.DisplayNode')

<a name='BTD_Mod_Helper.Extensions.EntityExt.GetFactory(thisAssets.Scripts.Simulation.Objects.Entity)'></a>

## EntityExt.GetFactory(this Entity) Method

(Cross-Game compatible) Return the Factory that creates Entities

```csharp
public static Assets.Scripts.Simulation.Factory.Factory<Assets.Scripts.Simulation.Objects.Entity> GetFactory(this Assets.Scripts.Simulation.Objects.Entity entity);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EntityExt.GetFactory(thisAssets.Scripts.Simulation.Objects.Entity).entity'></a>

`entity` [Assets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Objects.Entity 'Assets.Scripts.Simulation.Objects.Entity')

#### Returns
[Assets.Scripts.Simulation.Factory.Factory&lt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Factory.Factory-1 'Assets.Scripts.Simulation.Factory.Factory`1')[Assets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Objects.Entity 'Assets.Scripts.Simulation.Objects.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Factory.Factory-1 'Assets.Scripts.Simulation.Factory.Factory`1')

<a name='BTD_Mod_Helper.Extensions.EntityExt.GetUnityDisplayNode(thisAssets.Scripts.Simulation.Objects.Entity)'></a>

## EntityExt.GetUnityDisplayNode(this Entity) Method

Get the UnityDisplayNode for this Entity

```csharp
public static Assets.Scripts.Unity.Display.UnityDisplayNode GetUnityDisplayNode(this Assets.Scripts.Simulation.Objects.Entity entity);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EntityExt.GetUnityDisplayNode(thisAssets.Scripts.Simulation.Objects.Entity).entity'></a>

`entity` [Assets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Simulation.Objects.Entity 'Assets.Scripts.Simulation.Objects.Entity')

#### Returns
[Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')