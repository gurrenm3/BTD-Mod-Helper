#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## RendererExt Class

Extensions for unity renderers

```csharp
public static class RendererExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RendererExt
### Methods

<a name='BTD_Mod_Helper.Extensions.RendererExt.ApplyOutlineShader(thisRenderer)'></a>

## RendererExt.ApplyOutlineShader(this Renderer) Method

Gives this renderer the default outline for towers, also making them glow white when selected  
<seealso cref="M:BTD_Mod_Helper.Extensions.RendererExt.SetOutlineColor(UnityEngine.Renderer,UnityEngine.Color)"/>

```csharp
public static void ApplyOutlineShader(this Renderer renderer);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.ApplyOutlineShader(thisRenderer).renderer'></a>

`renderer` [UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.BakedMesh(thisSkinnedMeshRenderer)'></a>

## RendererExt.BakedMesh(this SkinnedMeshRenderer) Method

```csharp
public static Mesh BakedMesh(this SkinnedMeshRenderer skinnedMeshRenderer);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.BakedMesh(thisSkinnedMeshRenderer).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

#### Returns
[UnityEngine.Mesh](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Mesh 'UnityEngine.Mesh')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetBoneIndex(thisSkinnedMeshRenderer,string)'></a>

## RendererExt.GetBoneIndex(this SkinnedMeshRenderer, string) Method

```csharp
public static int GetBoneIndex(this SkinnedMeshRenderer skinnedMeshRenderer, string name);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetBoneIndex(thisSkinnedMeshRenderer,string).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetBoneIndex(thisSkinnedMeshRenderer,string).name'></a>

`name` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetTriangles(thisSkinnedMeshRenderer,int)'></a>

## RendererExt.GetTriangles(this SkinnedMeshRenderer, int) Method

Gets the list of triangles for a Mesh, even if its not marked as isReadable  
<br/>  
Each "triangle" is a set of 3 consecutive ints in the list, where the number is the index in the vertices

```csharp
public static System.Collections.Generic.List<int> GetTriangles(this SkinnedMeshRenderer skinnedMeshRenderer, int submesh=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetTriangles(thisSkinnedMeshRenderer,int).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetTriangles(thisSkinnedMeshRenderer,int).submesh'></a>

`submesh` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetTrianglesAsArrays(thisSkinnedMeshRenderer,int)'></a>

## RendererExt.GetTrianglesAsArrays(this SkinnedMeshRenderer, int) Method

```csharp
public static System.Collections.Generic.List<int[]> GetTrianglesAsArrays(this SkinnedMeshRenderer skinnedMeshRenderer, int submesh=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetTrianglesAsArrays(thisSkinnedMeshRenderer,int).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetTrianglesAsArrays(thisSkinnedMeshRenderer,int).submesh'></a>

`submesh` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetVertices(thisSkinnedMeshRenderer)'></a>

## RendererExt.GetVertices(this SkinnedMeshRenderer) Method

```csharp
public static System.Collections.Generic.List<Vector3> GetVertices(this SkinnedMeshRenderer skinnedMeshRenderer);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.GetVertices(thisSkinnedMeshRenderer).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[UnityEngine.Vector3](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector3 'UnityEngine.Vector3')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetMainTexture(thisIl2CppReferenceArray_Renderer_,Texture2D)'></a>

## RendererExt.SetMainTexture(this Il2CppReferenceArray<Renderer>, Texture2D) Method

Set the texture for all renderers in this collection. Equivalent to a "ForEach(render.material.mainTexture =  
texture2D)"

```csharp
public static void SetMainTexture(this Il2CppReferenceArray<Renderer> renderers, Texture2D texture2D);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetMainTexture(thisIl2CppReferenceArray_Renderer_,Texture2D).renderers'></a>

`renderers` [Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray](https://docs.microsoft.com/en-us/dotnet/api/Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray 'Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetMainTexture(thisIl2CppReferenceArray_Renderer_,Texture2D).texture2D'></a>

`texture2D` [UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetMainTexture(thisRenderer,Texture2D)'></a>

## RendererExt.SetMainTexture(this Renderer, Texture2D) Method

Set the texture for this renderer. Equivalent to "render.material.mainTexture = texture2D"

```csharp
public static void SetMainTexture(this Renderer renderer, Texture2D texture2D);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetMainTexture(thisRenderer,Texture2D).renderer'></a>

`renderer` [UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetMainTexture(thisRenderer,Texture2D).texture2D'></a>

`texture2D` [UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetOutlineColor(thisRenderer,Color)'></a>

## RendererExt.SetOutlineColor(this Renderer, Color) Method

Sets the outline color for this renderer

```csharp
public static void SetOutlineColor(this Renderer renderer, Color color);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetOutlineColor(thisRenderer,Color).renderer'></a>

`renderer` [UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.SetOutlineColor(thisRenderer,Color).color'></a>

`color` [UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')

<a name='BTD_Mod_Helper.Extensions.RendererExt.UnbindMesh(thisSkinnedMeshRenderer)'></a>

## RendererExt.UnbindMesh(this SkinnedMeshRenderer) Method

Unbinds the renderer's sharedMesh, so that changes you make to it don't change the original

```csharp
public static Mesh UnbindMesh(this SkinnedMeshRenderer skinnedMeshRenderer);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.UnbindMesh(thisSkinnedMeshRenderer).skinnedMeshRenderer'></a>

`skinnedMeshRenderer` [UnityEngine.SkinnedMeshRenderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.SkinnedMeshRenderer 'UnityEngine.SkinnedMeshRenderer')

#### Returns
[UnityEngine.Mesh](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Mesh 'UnityEngine.Mesh')