#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## BloonToSimulationExt Class

Extensions for the BloonToSimulation

```csharp
public static class BloonToSimulationExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BloonToSimulationExt
### Methods

<a name='BTD_Mod_Helper.Extensions.BloonToSimulationExt.GetBloon(thisBloonToSimulation)'></a>

## BloonToSimulationExt.GetBloon(this BloonToSimulation) Method

Return the Simulation Bloon for this specific BloonToSimulation. Returns object of class Bloon

```csharp
public static Bloon GetBloon(this BloonToSimulation bloonToSim);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonToSimulationExt.GetBloon(thisBloonToSimulation).bloonToSim'></a>

`bloonToSim` [Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation')

#### Returns
[Il2CppAssets.Scripts.Simulation.Bloons.Bloon](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Bloons.Bloon 'Il2CppAssets.Scripts.Simulation.Bloons.Bloon')

<a name='BTD_Mod_Helper.Extensions.BloonToSimulationExt.GetDisplayNode(thisBloonToSimulation)'></a>

## BloonToSimulationExt.GetDisplayNode(this BloonToSimulation) Method

Return the DisplayNode for this bloon

```csharp
public static DisplayNode GetDisplayNode(this BloonToSimulation bloonToSim);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonToSimulationExt.GetDisplayNode(thisBloonToSimulation).bloonToSim'></a>

`bloonToSim` [Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation')

#### Returns
[Il2CppAssets.Scripts.Simulation.Display.DisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Simulation.Display.DisplayNode 'Il2CppAssets.Scripts.Simulation.Display.DisplayNode')

<a name='BTD_Mod_Helper.Extensions.BloonToSimulationExt.GetDistanceTravelled(thisBloonToSimulation)'></a>

## BloonToSimulationExt.GetDistanceTravelled(this BloonToSimulation) Method

Return the total distance this BloonToSim has travelled

```csharp
public static float GetDistanceTravelled(this BloonToSimulation bloonToSim);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonToSimulationExt.GetDistanceTravelled(thisBloonToSimulation).bloonToSim'></a>

`bloonToSim` [Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation')

#### Returns
[System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Extensions.BloonToSimulationExt.GetId(thisBloonToSimulation)'></a>

## BloonToSimulationExt.GetId(this BloonToSimulation) Method

Return the Id of this BloonToSimulation

```csharp
public static ObjectId GetId(this BloonToSimulation bloonToSim);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonToSimulationExt.GetId(thisBloonToSimulation).bloonToSim'></a>

`bloonToSim` [Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation')

#### Returns
[Il2CppAssets.Scripts.ObjectId](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.ObjectId 'Il2CppAssets.Scripts.ObjectId')

<a name='BTD_Mod_Helper.Extensions.BloonToSimulationExt.GetUnityDisplayNode(thisBloonToSimulation)'></a>

## BloonToSimulationExt.GetUnityDisplayNode(this BloonToSimulation) Method

Return the UnityDisplayNode for this bloon. Is apart of DisplayNode. Needed to modify sprites

```csharp
public static UnityDisplayNode GetUnityDisplayNode(this BloonToSimulation bloonToSim);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.BloonToSimulationExt.GetUnityDisplayNode(thisBloonToSimulation).bloonToSim'></a>

`bloonToSim` [Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation 'Il2CppAssets.Scripts.Unity.Bridge.BloonToSimulation')

#### Returns
[Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')