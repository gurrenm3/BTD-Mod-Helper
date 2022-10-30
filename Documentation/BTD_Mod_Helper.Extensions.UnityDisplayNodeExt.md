#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## UnityDisplayNodeExt Class

Extensions for UnityDisplayNodes

```csharp
public static class UnityDisplayNodeExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; UnityDisplayNodeExt
### Methods

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.DumpTextures(thisAssets.Scripts.Unity.Display.UnityDisplayNode,string)'></a>

## UnityDisplayNodeExt.DumpTextures(this UnityDisplayNode, string) Method

Dumps all textures for every renderer in the node

```csharp
public static void DumpTextures(this Assets.Scripts.Unity.Display.UnityDisplayNode node, string prefix);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.DumpTextures(thisAssets.Scripts.Unity.Display.UnityDisplayNode,string).node'></a>

`node` [Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.DumpTextures(thisAssets.Scripts.Unity.Display.UnityDisplayNode,string).prefix'></a>

`prefix` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.Get3DModels(thisAssets.Scripts.Unity.Display.UnityDisplayNode)'></a>

## UnityDisplayNodeExt.Get3DModels(this UnityDisplayNode) Method

Get all 3D models attached to this UnityDisplayNode.

```csharp
public static System.Collections.Generic.List<UnityEngine.Transform> Get3DModels(this Assets.Scripts.Unity.Display.UnityDisplayNode unityDisplayNode);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.Get3DModels(thisAssets.Scripts.Unity.Display.UnityDisplayNode).unityDisplayNode'></a>

`unityDisplayNode` [Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetBone(thisAssets.Scripts.Unity.Display.UnityDisplayNode,string)'></a>

## UnityDisplayNodeExt.GetBone(this UnityDisplayNode, string) Method

Gets the transform associated with the given bone

```csharp
public static UnityEngine.Transform GetBone(this Assets.Scripts.Unity.Display.UnityDisplayNode unityDisplayNode, string boneName);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetBone(thisAssets.Scripts.Unity.Display.UnityDisplayNode,string).unityDisplayNode'></a>

`unityDisplayNode` [Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetBone(thisAssets.Scripts.Unity.Display.UnityDisplayNode,string).boneName'></a>

`boneName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[UnityEngine.Transform](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Transform 'UnityEngine.Transform')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetMeshRenderer(thisAssets.Scripts.Unity.Display.UnityDisplayNode,int,bool)'></a>

## UnityDisplayNodeExt.GetMeshRenderer(this UnityDisplayNode, int, bool) Method

Gets the first (or an indexed) SkinnedMeshRenderer/MeshRenderer

```csharp
public static UnityEngine.Renderer GetMeshRenderer(this Assets.Scripts.Unity.Display.UnityDisplayNode node, int index=0, bool recalculate=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetMeshRenderer(thisAssets.Scripts.Unity.Display.UnityDisplayNode,int,bool).node'></a>

`node` [Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetMeshRenderer(thisAssets.Scripts.Unity.Display.UnityDisplayNode,int,bool).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetMeshRenderer(thisAssets.Scripts.Unity.Display.UnityDisplayNode,int,bool).recalculate'></a>

`recalculate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetMeshRenderers(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool)'></a>

## UnityDisplayNodeExt.GetMeshRenderers(this UnityDisplayNode, bool) Method

Gets all renderers that are of type SkinnedMeshRenderer or MeshRenderer

```csharp
public static System.Collections.Generic.List<UnityEngine.Renderer> GetMeshRenderers(this Assets.Scripts.Unity.Display.UnityDisplayNode node, bool recalculate=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetMeshRenderers(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool).node'></a>

`node` [Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetMeshRenderers(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool).recalculate'></a>

`recalculate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderer_T_(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool)'></a>

## UnityDisplayNodeExt.GetRenderer<T>(this UnityDisplayNode, bool) Method

Gets the first generic renderer of the specified type, recalculating the renderers if need be

```csharp
public static T GetRenderer<T>(this Assets.Scripts.Unity.Display.UnityDisplayNode node, bool recalculate=true)
    where T : UnityEngine.Renderer;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderer_T_(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool).T'></a>

`T`

The type of Renderer you're looking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderer_T_(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool).node'></a>

`node` [Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')

The UnityDisplayNode

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderer_T_(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool).recalculate'></a>

`recalculate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to recalculate renderers

#### Returns
[T](BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.md#BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderer_T_(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool).T 'BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderer<T>(this Assets.Scripts.Unity.Display.UnityDisplayNode, bool).T')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool)'></a>

## UnityDisplayNodeExt.GetRenderers(this UnityDisplayNode, bool) Method

Gets all generic renderers on this UnityDisplayNode, recalculating the renderers if need be

```csharp
public static System.Collections.Generic.List<UnityEngine.Renderer> GetRenderers(this Assets.Scripts.Unity.Display.UnityDisplayNode node, bool recalculate=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool).node'></a>

`node` [Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')

The UnityDisplayNode

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool).recalculate'></a>

`recalculate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to recalculate renderers

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers_T_(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool)'></a>

## UnityDisplayNodeExt.GetRenderers<T>(this UnityDisplayNode, bool) Method

Gets all generic renderers of the specified type, recalculating the renderers if need be

```csharp
public static System.Collections.Generic.List<T> GetRenderers<T>(this Assets.Scripts.Unity.Display.UnityDisplayNode node, bool recalculate=true)
    where T : UnityEngine.Renderer;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers_T_(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool).T'></a>

`T`

The type of Renderer you're looking for
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers_T_(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool).node'></a>

`node` [Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')

The UnityDisplayNode

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers_T_(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool).recalculate'></a>

`recalculate` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to recalculate renderers

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.md#BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers_T_(thisAssets.Scripts.Unity.Display.UnityDisplayNode,bool).T 'BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.GetRenderers<T>(this Assets.Scripts.Unity.Display.UnityDisplayNode, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.PrintInfo(thisAssets.Scripts.Unity.Display.UnityDisplayNode)'></a>

## UnityDisplayNodeExt.PrintInfo(this UnityDisplayNode) Method

Prints relevant info about this node to the console

```csharp
public static void PrintInfo(this Assets.Scripts.Unity.Display.UnityDisplayNode node);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.PrintInfo(thisAssets.Scripts.Unity.Display.UnityDisplayNode).node'></a>

`node` [Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.RemoveBone(thisAssets.Scripts.Unity.Display.UnityDisplayNode,string,bool)'></a>

## UnityDisplayNodeExt.RemoveBone(this UnityDisplayNode, string, bool) Method

Removes (hides) a given bone

```csharp
public static void RemoveBone(this Assets.Scripts.Unity.Display.UnityDisplayNode unityDisplayNode, string boneName, bool alreadyUnbound=false);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.RemoveBone(thisAssets.Scripts.Unity.Display.UnityDisplayNode,string,bool).unityDisplayNode'></a>

`unityDisplayNode` [Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.RemoveBone(thisAssets.Scripts.Unity.Display.UnityDisplayNode,string,bool).boneName'></a>

`boneName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.RemoveBone(thisAssets.Scripts.Unity.Display.UnityDisplayNode,string,bool).alreadyUnbound'></a>

`alreadyUnbound` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.SaveMeshTexture(thisAssets.Scripts.Unity.Display.UnityDisplayNode,int,string)'></a>

## UnityDisplayNodeExt.SaveMeshTexture(this UnityDisplayNode, int, string) Method

Saves the texture used for this node's mesh renderer   
<br/>  
By default, this saves to local files, aka "C:\Users\...\AppData\LocalLow\Ninja Kiwi\BloonsTD6"

```csharp
public static void SaveMeshTexture(this Assets.Scripts.Unity.Display.UnityDisplayNode node, int index=0, string path=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.SaveMeshTexture(thisAssets.Scripts.Unity.Display.UnityDisplayNode,int,string).node'></a>

`node` [Assets.Scripts.Unity.Display.UnityDisplayNode](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Unity.Display.UnityDisplayNode 'Assets.Scripts.Unity.Display.UnityDisplayNode')

The UnityDisplayNode

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.SaveMeshTexture(thisAssets.Scripts.Unity.Display.UnityDisplayNode,int,string).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.UnityDisplayNodeExt.SaveMeshTexture(thisAssets.Scripts.Unity.Display.UnityDisplayNode,int,string).path'></a>

`path` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Optional path to save to instead