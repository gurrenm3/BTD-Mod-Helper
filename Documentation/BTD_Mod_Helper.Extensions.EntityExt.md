#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## EntityExt Class

Extensions for Entities

```csharp
public static class EntityExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntityExt
### Methods

<a name='BTD_Mod_Helper.Extensions.EntityExt.GetDisplayNode(thisEntity)'></a>

## EntityExt.GetDisplayNode(this Entity) Method

Get the DisplayNode for this Entity

```csharp
public static DisplayNode GetDisplayNode(this Entity entity);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EntityExt.GetDisplayNode(thisEntity).entity'></a>

`entity` [Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')

#### Returns
[Il2CppAssets.Scripts.Simulation.Display.DisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Display.DisplayNode 'Il2CppAssets.Scripts.Simulation.Display.DisplayNode')

<a name='BTD_Mod_Helper.Extensions.EntityExt.GetFactory(thisEntity)'></a>

## EntityExt.GetFactory(this Entity) Method

Return the Factory that creates Entities

```csharp
public static Factory<Entity> GetFactory(this Entity entity);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EntityExt.GetFactory(thisEntity).entity'></a>

`entity` [Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')

#### Returns
[Il2CppAssets.Scripts.Simulation.Factory.Factory](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Factory.Factory 'Il2CppAssets.Scripts.Simulation.Factory.Factory')

<a name='BTD_Mod_Helper.Extensions.EntityExt.GetUnityDisplayNode(thisEntity)'></a>

## EntityExt.GetUnityDisplayNode(this Entity) Method

Get the UnityDisplayNode for this Entity

```csharp
public static UnityDisplayNode GetUnityDisplayNode(this Entity entity);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.EntityExt.GetUnityDisplayNode(thisEntity).entity'></a>

`entity` [Il2CppAssets.Scripts.Simulation.Objects.Entity](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Objects.Entity 'Il2CppAssets.Scripts.Simulation.Objects.Entity')

#### Returns
[Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')