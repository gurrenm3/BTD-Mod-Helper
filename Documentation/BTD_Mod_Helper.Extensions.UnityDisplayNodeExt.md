#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## UnityDisplayNodeExt Class

Extensions for UnityDisplayNodes

```csharp
public static class UnityDisplayNodeExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; UnityDisplayNodeExt
### Methods

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.DumpTextures(thisUnityDisplayNode,string)'></a>

## UnityDisplayNodeExt.DumpTextures(this UnityDisplayNode, string) Method

Dumps all textures for every renderer in the node

```csharp
public static void DumpTextures(this UnityDisplayNode node, string prefix);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.DumpTextures(thisUnityDisplayNode,string).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.DumpTextures(thisUnityDisplayNode,string).prefix'></a>

`prefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.Get3DModels(thisUnityDisplayNode)'></a>

## UnityDisplayNodeExt.Get3DModels(this UnityDisplayNode) Method

Get all 3D models attached to this UnityDisplayNode.

```csharp
public static System.Collections.Generic.List<Transform> Get3DModels(this UnityDisplayNode unityDisplayNode);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.Get3DModels(thisUnityDisplayNode).unityDisplayNode'></a>

`unityDisplayNode` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetBone(thisUnityDisplayNode,string)'></a>

## UnityDisplayNodeExt.GetBone(this UnityDisplayNode, string) Method

Gets the transform associated with the given bone

```csharp
public static Transform GetBone(this UnityDisplayNode unityDisplayNode, string boneName);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetBone(thisUnityDisplayNode,string).unityDisplayNode'></a>

`unityDisplayNode` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetBone(thisUnityDisplayNode,string).boneName'></a>

`boneName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetMeshRenderer(thisUnityDisplayNode,int,bool)'></a>

## UnityDisplayNodeExt.GetMeshRenderer(this UnityDisplayNode, int, bool) Method

Gets the first (or an indexed) SkinnedMeshRenderer/MeshRenderer

```csharp
public static Renderer GetMeshRenderer(this UnityDisplayNode node, int index=0, bool recalculate=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetMeshRenderer(thisUnityDisplayNode,int,bool).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetMeshRenderer(thisUnityDisplayNode,int,bool).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetMeshRenderer(thisUnityDisplayNode,int,bool).recalculate'></a>

`recalculate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetMeshRenderers(thisUnityDisplayNode,bool)'></a>

## UnityDisplayNodeExt.GetMeshRenderers(this UnityDisplayNode, bool) Method

Gets all renderers that are of type SkinnedMeshRenderer or MeshRenderer

```csharp
public static System.Collections.Generic.List<Renderer> GetMeshRenderers(this UnityDisplayNode node, bool recalculate=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetMeshRenderers(thisUnityDisplayNode,bool).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetMeshRenderers(thisUnityDisplayNode,bool).recalculate'></a>

`recalculate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderer_T_(thisUnityDisplayNode,bool)'></a>

## UnityDisplayNodeExt.GetRenderer<T>(this UnityDisplayNode, bool) Method

Gets the first generic renderer of the specified type, recalculating the renderers if need be

```csharp
public static T GetRenderer<T>(this UnityDisplayNode node, bool recalculate=true)
    where T : Renderer;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderer_T_(thisUnityDisplayNode,bool).T'></a>

`T`

The type of Renderer you're looking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderer_T_(thisUnityDisplayNode,bool).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

The UnityDisplayNode

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderer_T_(thisUnityDisplayNode,bool).recalculate'></a>

`recalculate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to recalculate renderers

#### Returns
[T](BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.md#BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderer_T_(thisUnityDisplayNode,bool).T 'BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderer<T>(this UnityDisplayNode, bool).T')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers(thisUnityDisplayNode,bool)'></a>

## UnityDisplayNodeExt.GetRenderers(this UnityDisplayNode, bool) Method

Gets all generic renderers on this UnityDisplayNode, recalculating the renderers if need be

```csharp
public static System.Collections.Generic.List<Renderer> GetRenderers(this UnityDisplayNode node, bool recalculate=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers(thisUnityDisplayNode,bool).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

The UnityDisplayNode

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers(thisUnityDisplayNode,bool).recalculate'></a>

`recalculate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to recalculate renderers

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers_T_(thisUnityDisplayNode,bool)'></a>

## UnityDisplayNodeExt.GetRenderers<T>(this UnityDisplayNode, bool) Method

Gets all generic renderers of the specified type, recalculating the renderers if need be

```csharp
public static System.Collections.Generic.List<T> GetRenderers<T>(this UnityDisplayNode node, bool recalculate=true)
    where T : Renderer;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers_T_(thisUnityDisplayNode,bool).T'></a>

`T`

The type of Renderer you're looking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers_T_(thisUnityDisplayNode,bool).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

The UnityDisplayNode

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers_T_(thisUnityDisplayNode,bool).recalculate'></a>

`recalculate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to recalculate renderers

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.md#BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers_T_(thisUnityDisplayNode,bool).T 'BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers<T>(this UnityDisplayNode, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.PrintInfo(thisUnityDisplayNode)'></a>

## UnityDisplayNodeExt.PrintInfo(this UnityDisplayNode) Method

Prints relevant info about this node to the console

```csharp
public static void PrintInfo(this UnityDisplayNode node);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.PrintInfo(thisUnityDisplayNode).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.RemoveBone(thisUnityDisplayNode,string,bool)'></a>

## UnityDisplayNodeExt.RemoveBone(this UnityDisplayNode, string, bool) Method

Removes (hides) a given bone

```csharp
public static void RemoveBone(this UnityDisplayNode unityDisplayNode, string boneName, bool alreadyUnbound=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.RemoveBone(thisUnityDisplayNode,string,bool).unityDisplayNode'></a>

`unityDisplayNode` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.RemoveBone(thisUnityDisplayNode,string,bool).boneName'></a>

`boneName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.RemoveBone(thisUnityDisplayNode,string,bool).alreadyUnbound'></a>

`alreadyUnbound` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.SaveMeshTexture(thisUnityDisplayNode,int,string)'></a>

## UnityDisplayNodeExt.SaveMeshTexture(this UnityDisplayNode, int, string) Method

Saves the texture used for this node's mesh renderer  
<br/>  
By default, this saves to local files, aka "C:\Users\...\AppData\LocalLow\Ninja Kiwi\BloonsTD6"

```csharp
public static void SaveMeshTexture(this UnityDisplayNode node, int index=0, string path=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.SaveMeshTexture(thisUnityDisplayNode,int,string).node'></a>

`node` [Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode 'Il2CppAssets.Scripts.Unity.Display.UnityDisplayNode')

The UnityDisplayNode

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.SaveMeshTexture(thisUnityDisplayNode,int,string).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.SaveMeshTexture(thisUnityDisplayNode,int,string).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional path to save to instead