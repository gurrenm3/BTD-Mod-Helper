#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Texture2DExt Class

Extensions for Texture2Ds

```csharp
public static class Texture2DExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Texture2DExt
### Methods

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