#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Vector3Ext Class

Extensions for Vectors

```csharp
public static class Vector3Ext
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Vector3Ext
### Methods

<a name='BTD_Mod_Helper.Extensions.Vector3Ext.Raycast(thisVector3)'></a>

## Vector3Ext.Raycast(this Vector3) Method

Raycasts this screen point

```csharp
public static List<RaycastResult> Raycast(this Vector3 vector);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Vector3Ext.Raycast(thisVector3).vector'></a>

`vector` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

screen point

#### Returns
[Il2CppSystem.Collections.Generic.List](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Collections.Generic.List 'Il2CppSystem.Collections.Generic.List')  
raycast results

<a name='BTD_Mod_Helper.Extensions.Vector3Ext.ToSMathVector(thisVector3)'></a>

## Vector3Ext.ToSMathVector(this Vector3) Method

Convert UnityEngine.Vector3 to NinjaKiwi's SMath.Vector3

```csharp
public static Vector3 ToSMathVector(this Vector3 vector3);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Vector3Ext.ToSMathVector(thisVector3).vector3'></a>

`vector3` [UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')

#### Returns
[Il2CppAssets.Scripts.Simulation.SMath.Vector3](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.SMath.Vector3 'Il2CppAssets.Scripts.Simulation.SMath.Vector3')