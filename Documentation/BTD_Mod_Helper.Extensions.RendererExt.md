#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## RendererExt Class

Extensions for unity renderers

```csharp
public static class RendererExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RendererExt
### Methods

<a name='BTD_Mod_Helper.Extensions.RendererExt.AdjustHSV(thisRenderer,float,float,float,System.Nullable_Color_,float)'></a>

## RendererExt.AdjustHSV(this Renderer, float, float, float, Nullable<Color>, float) Method

Applies a HSV adjustment, shifting its Hue/Saturation/Value(light)

```csharp
public static void AdjustHSV(this Renderer renderer, float hueAdjust, float saturationAdjust, float valueAdjust, System.Nullable<Color> targetColor=null, float threshold=0.05f);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.AdjustHSV(thisRenderer,float,float,float,System.Nullable_Color_,float).renderer'></a>

`renderer` [UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.AdjustHSV(thisRenderer,float,float,float,System.Nullable_Color_,float).hueAdjust'></a>

`hueAdjust` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Amount between -180 and 180 to add to Hue

<a name='BTD_Mod_Helper.Extensions.RendererExt.AdjustHSV(thisRenderer,float,float,float,System.Nullable_Color_,float).saturationAdjust'></a>

`saturationAdjust` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Amount between -1 and 1 to add to the saturation

<a name='BTD_Mod_Helper.Extensions.RendererExt.AdjustHSV(thisRenderer,float,float,float,System.Nullable_Color_,float).valueAdjust'></a>

`valueAdjust` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Amount between -1 and 1 to add to the value (light)

<a name='BTD_Mod_Helper.Extensions.RendererExt.AdjustHSV(thisRenderer,float,float,float,System.Nullable_Color_,float).targetColor'></a>

`targetColor` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

If specified, only affect this color within the image

<a name='BTD_Mod_Helper.Extensions.RendererExt.AdjustHSV(thisRenderer,float,float,float,System.Nullable_Color_,float).threshold'></a>

`threshold` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

If specified, only match the color within this threshold, 0 is exact, 1 will match anything

<a name='BTD_Mod_Helper.Extensions.RendererExt.ApplyCustomShader(thisRenderer,BTD_Mod_Helper.Api.Enums.CustomShader,System.Action_Material_)'></a>

## RendererExt.ApplyCustomShader(this Renderer, CustomShader, Action<Material>) Method

Applies a custom Mod Helper shader, creating a new Texture with its effects baked in

```csharp
public static void ApplyCustomShader(this Renderer renderer, BTD_Mod_Helper.Api.Enums.CustomShader customShader, System.Action<Material> modifyMaterial=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.ApplyCustomShader(thisRenderer,BTD_Mod_Helper.Api.Enums.CustomShader,System.Action_Material_).renderer'></a>

`renderer` [UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.ApplyCustomShader(thisRenderer,BTD_Mod_Helper.Api.Enums.CustomShader,System.Action_Material_).customShader'></a>

`customShader` [CustomShader](BTD_Mod_Helper.Api.Enums.CustomShader.md 'BTD_Mod_Helper.Api.Enums.CustomShader')

Mod Helper custom shader

<a name='BTD_Mod_Helper.Extensions.RendererExt.ApplyCustomShader(thisRenderer,BTD_Mod_Helper.Api.Enums.CustomShader,System.Action_Material_).modifyMaterial'></a>

`modifyMaterial` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[UnityEngine.Material](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Material 'UnityEngine.Material')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

changes to make to the material

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

<a name='BTD_Mod_Helper.Extensions.RendererExt.ReplaceColor(thisRenderer,Color,Color,float)'></a>

## RendererExt.ReplaceColor(this Renderer, Color, Color, float) Method

Replaces all the usage of a target color (within a certain threshold) with a replacement color

```csharp
public static void ReplaceColor(this Renderer renderer, Color targetColor, Color replacementColor, float threshold=0.05f);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.RendererExt.ReplaceColor(thisRenderer,Color,Color,float).renderer'></a>

`renderer` [UnityEngine.Renderer](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Renderer 'UnityEngine.Renderer')

<a name='BTD_Mod_Helper.Extensions.RendererExt.ReplaceColor(thisRenderer,Color,Color,float).targetColor'></a>

`targetColor` [UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')

The color to find

<a name='BTD_Mod_Helper.Extensions.RendererExt.ReplaceColor(thisRenderer,Color,Color,float).replacementColor'></a>

`replacementColor` [UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')

The new color

<a name='BTD_Mod_Helper.Extensions.RendererExt.ReplaceColor(thisRenderer,Color,Color,float).threshold'></a>

`threshold` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The threshold for matching the target color, 0 is exact, 1 will match anything

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