#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Texture2DExt Class

Extensions for Texture2Ds

```csharp
public static class Texture2DExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Texture2DExt
### Methods

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.AdjustHSV(thisTexture,float,float,float,System.Nullable_Color_,float)'></a>

## Texture2DExt.AdjustHSV(this Texture, float, float, float, Nullable<Color>, float) Method

Applies a HSV adjustment, shifting its Hue/Saturation/Value(light)

```csharp
public static RenderTexture AdjustHSV(this Texture texture, float hueAdjust, float saturationAdjust, float valueAdjust, System.Nullable<Color> targetColor=null, float threshold=0.05f);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.AdjustHSV(thisTexture,float,float,float,System.Nullable_Color_,float).texture'></a>

`texture` [UnityEngine.Texture](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture 'UnityEngine.Texture')

this

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.AdjustHSV(thisTexture,float,float,float,System.Nullable_Color_,float).hueAdjust'></a>

`hueAdjust` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Amount between -180 and 180 to add to Hue

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.AdjustHSV(thisTexture,float,float,float,System.Nullable_Color_,float).saturationAdjust'></a>

`saturationAdjust` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Amount between -1 and 1 to add to the saturation

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.AdjustHSV(thisTexture,float,float,float,System.Nullable_Color_,float).valueAdjust'></a>

`valueAdjust` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Amount between -1 and 1 to add to the value (light)

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.AdjustHSV(thisTexture,float,float,float,System.Nullable_Color_,float).targetColor'></a>

`targetColor` [System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

If specified, only affect this color within the image

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.AdjustHSV(thisTexture,float,float,float,System.Nullable_Color_,float).threshold'></a>

`threshold` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

If specified, only match the color within this threshold, 0 is exact, 1 will match anything

#### Returns
[UnityEngine.RenderTexture](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RenderTexture 'UnityEngine.RenderTexture')

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.ApplyCustomShader(thisTexture,BTD_Mod_Helper.Api.Enums.CustomShader,System.Action_Material_)'></a>

## Texture2DExt.ApplyCustomShader(this Texture, CustomShader, Action<Material>) Method

Applies a custom Mod Helper shader, creating a new Texture with its effects baked in

```csharp
public static RenderTexture ApplyCustomShader(this Texture texture, BTD_Mod_Helper.Api.Enums.CustomShader customShader, System.Action<Material> modifyMaterial=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.ApplyCustomShader(thisTexture,BTD_Mod_Helper.Api.Enums.CustomShader,System.Action_Material_).texture'></a>

`texture` [UnityEngine.Texture](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture 'UnityEngine.Texture')

this

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.ApplyCustomShader(thisTexture,BTD_Mod_Helper.Api.Enums.CustomShader,System.Action_Material_).customShader'></a>

`customShader` [CustomShader](BTD_Mod_Helper.Api.Enums.CustomShader.md 'BTD_Mod_Helper.Api.Enums.CustomShader')

Mod Helper custom shader

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.ApplyCustomShader(thisTexture,BTD_Mod_Helper.Api.Enums.CustomShader,System.Action_Material_).modifyMaterial'></a>

`modifyMaterial` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[UnityEngine.Material](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Material 'UnityEngine.Material')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

changes to make to the material

#### Returns
[UnityEngine.RenderTexture](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RenderTexture 'UnityEngine.RenderTexture')

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.ApplyCustomShader(thisTexture,Shader,System.Action_Material_)'></a>

## Texture2DExt.ApplyCustomShader(this Texture, Shader, Action<Material>) Method

Applies a custom shader, creating a new Texture with its effects baked in

```csharp
public static RenderTexture ApplyCustomShader(this Texture texture, Shader shader, System.Action<Material> modifyMaterial=null);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.ApplyCustomShader(thisTexture,Shader,System.Action_Material_).texture'></a>

`texture` [UnityEngine.Texture](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture 'UnityEngine.Texture')

this

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.ApplyCustomShader(thisTexture,Shader,System.Action_Material_).shader'></a>

`shader` [UnityEngine.Shader](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Shader 'UnityEngine.Shader')

Mod Helper custom shader

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.ApplyCustomShader(thisTexture,Shader,System.Action_Material_).modifyMaterial'></a>

`modifyMaterial` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[UnityEngine.Material](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Material 'UnityEngine.Material')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

changes to make to the material

#### Returns
[UnityEngine.RenderTexture](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RenderTexture 'UnityEngine.RenderTexture')

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.CreateFromColor(thisTexture2D,Color)'></a>

## Texture2DExt.CreateFromColor(this Texture2D, Color) Method

Create Texture2D from a unity Color. Texture will only be this color

```csharp
public static Texture2D CreateFromColor(this Texture2D texture2D, Color color);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.CreateFromColor(thisTexture2D,Color).texture2D'></a>

`texture2D` [UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.CreateFromColor(thisTexture2D,Color).color'></a>

`color` [UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')

Color to make new texture

#### Returns
[UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.CreateSpriteFromTexture(thisTexture2D,float,Vector2)'></a>

## Texture2DExt.CreateSpriteFromTexture(this Texture2D, float, Vector2) Method

Create a Sprite from this Texture2D

```csharp
public static Sprite CreateSpriteFromTexture(this Texture2D texture2D, float pixelsPerUnit, Vector2 pivot);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.CreateSpriteFromTexture(thisTexture2D,float,Vector2).texture2D'></a>

`texture2D` [UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.CreateSpriteFromTexture(thisTexture2D,float,Vector2).pixelsPerUnit'></a>

`pixelsPerUnit` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Number of pixels you want in each unit. More pixels means bigger sprite in game

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.CreateSpriteFromTexture(thisTexture2D,float,Vector2).pivot'></a>

`pivot` [UnityEngine.Vector2](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Vector2 'UnityEngine.Vector2')

#### Returns
[UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.CreateSpriteFromTexture(thisTexture2D,float)'></a>

## Texture2DExt.CreateSpriteFromTexture(this Texture2D, float) Method

Create a Sprite from this Texture2D

```csharp
public static Sprite CreateSpriteFromTexture(this Texture2D texture2D, float pixelsPerUnit);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.CreateSpriteFromTexture(thisTexture2D,float).texture2D'></a>

`texture2D` [UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.CreateSpriteFromTexture(thisTexture2D,float).pixelsPerUnit'></a>

`pixelsPerUnit` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

Number of pixels you want in each unit. More pixels means bigger sprite in game

#### Returns
[UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.LoadFromFile(thisTexture2D,string)'></a>

## Texture2DExt.LoadFromFile(this Texture2D, string) Method

Create Texture2D from a file on local PC

```csharp
public static Texture2D LoadFromFile(this Texture2D texture, string filePath);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.LoadFromFile(thisTexture2D,string).texture'></a>

`texture` [UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.LoadFromFile(thisTexture2D,string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

path of file on PC

#### Returns
[UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.ReplaceColor(thisTexture,Color,Color,float)'></a>

## Texture2DExt.ReplaceColor(this Texture, Color, Color, float) Method

Replaces all the usage of a target color (within a certain threshold) with a replacement color

```csharp
public static RenderTexture ReplaceColor(this Texture texture, Color targetColor, Color replacementColor, float threshold=0.05f);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.ReplaceColor(thisTexture,Color,Color,float).texture'></a>

`texture` [UnityEngine.Texture](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture 'UnityEngine.Texture')

this

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.ReplaceColor(thisTexture,Color,Color,float).targetColor'></a>

`targetColor` [UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')

The color to find

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.ReplaceColor(thisTexture,Color,Color,float).replacementColor'></a>

`replacementColor` [UnityEngine.Color](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Color 'UnityEngine.Color')

The new color

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.ReplaceColor(thisTexture,Color,Color,float).threshold'></a>

`threshold` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

The threshold for matching the target color, 0 is exact, 1 will match anything

#### Returns
[UnityEngine.RenderTexture](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.RenderTexture 'UnityEngine.RenderTexture')

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.SaveToPNG(thisTexture2D,string)'></a>

## Texture2DExt.SaveToPNG(this Texture2D, string) Method

Save Texture2D as a png to file.

```csharp
public static void SaveToPNG(this Texture2D texture, string filePath);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.SaveToPNG(thisTexture2D,string).texture'></a>

`texture` [UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.SaveToPNG(thisTexture2D,string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

File path to save texture to

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.TrySaveToPNG(thisTexture,string)'></a>

## Texture2DExt.TrySaveToPNG(this Texture, string) Method

Attempts to save a Texture to a png at the given filePath, even if it isn't marked as readable

```csharp
public static void TrySaveToPNG(this Texture texture, string filePath);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.TrySaveToPNG(thisTexture,string).texture'></a>

`texture` [UnityEngine.Texture](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture 'UnityEngine.Texture')

<a name='BTD_Mod_Helper.Extensions.Texture2DExt.TrySaveToPNG(thisTexture,string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')