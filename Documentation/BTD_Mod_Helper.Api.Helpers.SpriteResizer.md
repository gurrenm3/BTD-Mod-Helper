#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## SpriteResizer Class

Helper class for getting resized versions of Sprites

```csharp
public static class SpriteResizer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SpriteResizer
### Methods

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.PadSpriteToScale(thisSprite,float,float)'></a>

## SpriteResizer.PadSpriteToScale(this Sprite, float, float) Method

Create a new Sprite that appears scaled by (scaleX, scaleY) inside a fixed UI rect  
by adding transparent padding around the original sprite.  
Works even if src.texture is not readable.

```csharp
public static Sprite PadSpriteToScale(this Sprite src, float scaleX, float scaleY);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.PadSpriteToScale(thisSprite,float,float).src'></a>

`src` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.PadSpriteToScale(thisSprite,float,float).scaleX'></a>

`scaleX` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.PadSpriteToScale(thisSprite,float,float).scaleY'></a>

`scaleY` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.PadSpriteToScale(thisSprite,float)'></a>

## SpriteResizer.PadSpriteToScale(this Sprite, float) Method

Create a new Sprite that appears scaled by (scaleX, scaleY) inside a fixed UI rect  
by adding transparent padding around the original sprite.  
Works even if src.texture is not readable.

```csharp
public static Sprite PadSpriteToScale(this Sprite src, float uniformScale);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.PadSpriteToScale(thisSprite,float).src'></a>

`src` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.PadSpriteToScale(thisSprite,float).uniformScale'></a>

`uniformScale` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

#### Returns
[UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.PadSpriteToSquare(thisSprite)'></a>

## SpriteResizer.PadSpriteToSquare(this Sprite) Method

Returns a new Sprite with a square texture by padding the shorter axis  
with transparent pixels so that width and height are equal.

```csharp
public static Sprite PadSpriteToSquare(this Sprite src);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.PadSpriteToSquare(thisSprite).src'></a>

`src` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

The source sprite to pad.

#### Returns
[UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')  
A new square Sprite instance if padding was needed, or the original sprite if already square.

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.Scaled(string,float,bool)'></a>

## SpriteResizer.Scaled(string, float, bool) Method

Returns a modified Sprite GUID that will create a reference to a resized version of this Vanilla Sprite.  
<br/>

```csharp
public static string Scaled(string spriteGuid, float scale, bool square=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.Scaled(string,float,bool).spriteGuid'></a>

`spriteGuid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Vanilla Sprite guid

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.Scaled(string,float,bool).scale'></a>

`scale` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.Scaled(string,float,bool).square'></a>

`square` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

also make the final image a square shape

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
new sprite guid

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.Scaled(string,float,float,bool)'></a>

## SpriteResizer.Scaled(string, float, float, bool) Method

Returns a modified Sprite GUID that will create a reference to a resized version of this Vanilla Sprite.  
<br/>

```csharp
public static string Scaled(string spriteGuid, float scaleX, float scaleY, bool square=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.Scaled(string,float,float,bool).spriteGuid'></a>

`spriteGuid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Vanilla Sprite guid

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.Scaled(string,float,float,bool).scaleX'></a>

`scaleX` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

scale

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.Scaled(string,float,float,bool).scaleY'></a>

`scaleY` [System.Single](https://docs.microsoft.com/en-us/dotnet/api/System.Single 'System.Single')

scale

<a name='BTD_Mod_Helper.Api.Helpers.SpriteResizer.Scaled(string,float,float,bool).square'></a>

`square` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

also make the final image a square shape

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
new sprite guid