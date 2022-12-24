#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## RendererExt Class

Extensions for unity renderers

```csharp
public static class RendererExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RendererExt
### Methods

<a name='BTD_Mod_Helper.Extensions.RendererExt.BakedMesh(thisUnityEngine.SkinnedMeshRenderer)'></a>

## RendererExt.BakedMesh(this SkinnedMeshRenderer) Method

```csharp
public static UnityEngine.Mesh BakedMesh(this UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.BakedMesh(thisUnityEngine.SkinnedMeshRenderer).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

#### Returns
[UnityEngine.Mesh](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Mesh 'UnityEngine.Mesh')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetBoneIndex(thisUnityEngine.SkinnedMeshRenderer,string)'></a>

## RendererExt.GetBoneIndex(this SkinnedMeshRenderer, string) Method

```csharp
public static int GetBoneIndex(this UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer, string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetBoneIndex(thisUnityEngine.SkinnedMeshRenderer,string).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetBoneIndex(thisUnityEngine.SkinnedMeshRenderer,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetTriangles(thisUnityEngine.SkinnedMeshRenderer,int)'></a>

## RendererExt.GetTriangles(this SkinnedMeshRenderer, int) Method

Gets the list of triangles for a Mesh, even if its not marked as isReadable  
<br/>  
Each "triangle" is a set of 3 consecutive ints in the list, where the number is the index in the vertices

```csharp
public static System.Collections.Generic.List<int> GetTriangles(this UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer, int submesh=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetTriangles(thisUnityEngine.SkinnedMeshRenderer,int).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetTriangles(thisUnityEngine.SkinnedMeshRenderer,int).submesh'></a>

`submesh` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetTrianglesAsArrays(thisUnityEngine.SkinnedMeshRenderer,int)'></a>

## RendererExt.GetTrianglesAsArrays(this SkinnedMeshRenderer, int) Method

```csharp
public static System.Collections.Generic.List<int[]> GetTrianglesAsArrays(this UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer, int submesh=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetTrianglesAsArrays(thisUnityEngine.SkinnedMeshRenderer,int).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetTrianglesAsArrays(thisUnityEngine.SkinnedMeshRenderer,int).submesh'></a>

`submesh` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetVertices(thisUnityEngine.SkinnedMeshRenderer)'></a>

## RendererExt.GetVertices(this SkinnedMeshRenderer) Method

```csharp
public static System.Collections.Generic.List<UnityEngine.Vector3> GetVertices(this UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetVertices(thisUnityEngine.SkinnedMeshRenderer).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetVerticesConnectedToBone(thisUnityEngine.SkinnedMeshRenderer,int)'></a>

## RendererExt.GetVerticesConnectedToBone(this SkinnedMeshRenderer, int) Method

Experimental method of messing with mesh renderers at runtime

```csharp
public static System.Collections.Generic.IEnumerable<int> GetVerticesConnectedToBone(this UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer, int boneIndex);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetVerticesConnectedToBone(thisUnityEngine.SkinnedMeshRenderer,int).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetVerticesConnectedToBone(thisUnityEngine.SkinnedMeshRenderer,int).boneIndex'></a>

`boneIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetVerticesConnectedToBoneArray(thisUnityEngine.SkinnedMeshRenderer,int)'></a>

## RendererExt.GetVerticesConnectedToBoneArray(this SkinnedMeshRenderer, int) Method

Experimental method of messing with mesh renderers at runtime

```csharp
public static bool[] GetVerticesConnectedToBoneArray(this UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer, int boneIndex);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetVerticesConnectedToBoneArray(thisUnityEngine.SkinnedMeshRenderer,int).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetVerticesConnectedToBoneArray(thisUnityEngine.SkinnedMeshRenderer,int).boneIndex'></a>

`boneIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetMainTexture(thisIl2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray_UnityEngine.Renderer_,UnityEngine.Texture2D)'></a>

## RendererExt.SetMainTexture(this Il2CppReferenceArray<Renderer>, Texture2D) Method

Set the texture for all renderers in this collection. Equivalent to a "ForEach(render.material.mainTexture = texture2D)"

```csharp
public static void SetMainTexture(this Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<UnityEngine.Renderer> renderers, UnityEngine.Texture2D texture2D);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetMainTexture(thisIl2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray_UnityEngine.Renderer_,UnityEngine.Texture2D).renderers'></a>

`renderers` [Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray&lt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray-1 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray`1')[UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray-1 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray`1')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetMainTexture(thisIl2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray_UnityEngine.Renderer_,UnityEngine.Texture2D).texture2D'></a>

`texture2D` [UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetMainTexture(thisUnityEngine.Renderer,UnityEngine.Texture2D)'></a>

## RendererExt.SetMainTexture(this Renderer, Texture2D) Method

Set the texture for this renderer. Equivalent to "render.material.mainTexture = texture2D"

```csharp
public static void SetMainTexture(this UnityEngine.Renderer renderer, UnityEngine.Texture2D texture2D);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetMainTexture(thisUnityEngine.Renderer,UnityEngine.Texture2D).renderer'></a>

`renderer` [UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetMainTexture(thisUnityEngine.Renderer,UnityEngine.Texture2D).texture2D'></a>

`texture2D` [UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetOutlineColor(thisUnityEngine.Renderer,UnityEngine.Color)'></a>

## RendererExt.SetOutlineColor(this Renderer, Color) Method

Sets the outline color for this renderer

```csharp
public static void SetOutlineColor(this UnityEngine.Renderer renderer, UnityEngine.Color color);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetOutlineColor(thisUnityEngine.Renderer,UnityEngine.Color).renderer'></a>

`renderer` [UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetOutlineColor(thisUnityEngine.Renderer,UnityEngine.Color).color'></a>

`color` [UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetTriangles(thisUnityEngine.SkinnedMeshRenderer,System.Collections.Generic.List_int[]_)'></a>

## RendererExt.SetTriangles(this SkinnedMeshRenderer, List<int[]>) Method

Experimental method of messing with mesh renderers at runtime

```csharp
public static void SetTriangles(this UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer, System.Collections.Generic.List<int[]> trianglesAsArrays);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetTriangles(thisUnityEngine.SkinnedMeshRenderer,System.Collections.Generic.List_int[]_).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetTriangles(thisUnityEngine.SkinnedMeshRenderer,System.Collections.Generic.List_int[]_).trianglesAsArrays'></a>

`trianglesAsArrays` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetTriangles(thisUnityEngine.SkinnedMeshRenderer,System.Collections.Generic.List_int_)'></a>

## RendererExt.SetTriangles(this SkinnedMeshRenderer, List<int>) Method

Experimental method of messing with mesh renderers at runtime

```csharp
public static void SetTriangles(this UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer, System.Collections.Generic.List<int> triangles);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetTriangles(thisUnityEngine.SkinnedMeshRenderer,System.Collections.Generic.List_int_).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetTriangles(thisUnityEngine.SkinnedMeshRenderer,System.Collections.Generic.List_int_).triangles'></a>

`triangles` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.RendererExt.UnbindMesh(thisUnityEngine.SkinnedMeshRenderer)'></a>

## RendererExt.UnbindMesh(this SkinnedMeshRenderer) Method

Unbinds the renderer's sharedMesh, so that changes you make to it don't change the original

```csharp
public static UnityEngine.Mesh UnbindMesh(this UnityEngine.SkinnedMeshRenderer skinnedMeshRenderer);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.UnbindMesh(thisUnityEngine.SkinnedMeshRenderer).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

#### Returns
[UnityEngine.Mesh](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Mesh 'UnityEngine.Mesh')