#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ImageExt Class

Extensions for Images

```csharp
public static class ImageExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ImageExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ImageExt.GetBytes(thisSystem.Drawing.Image)'></a>

## ImageExt.GetBytes(this Image) Method

Returns the Bytes of this Image.

```csharp
public static byte[] GetBytes(this System.Drawing.Image image);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ImageExt.GetBytes(thisSystem.Drawing.Image).image'></a>

`image` [System.Drawing.Image](https://docs.microsoft.com/en-us/dotnet/api/System.Drawing.Image 'System.Drawing.Image')

#### Returns
[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

<a name='BTD_Mod_Helper.Extensions.ImageExt.LoadSprite(thisUnityEngine.UI.Image,Assets.Scripts.Utils.SpriteReference)'></a>

## ImageExt.LoadSprite(this Image, SpriteReference) Method

Loads a sprite reference to this image

```csharp
public static void LoadSprite(this UnityEngine.UI.Image image, Assets.Scripts.Utils.SpriteReference spriteReference);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ImageExt.LoadSprite(thisUnityEngine.UI.Image,Assets.Scripts.Utils.SpriteReference).image'></a>

`image` [UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.Extensions.ImageExt.LoadSprite(thisUnityEngine.UI.Image,Assets.Scripts.Utils.SpriteReference).spriteReference'></a>

`spriteReference` [Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Extensions.ImageExt.Resize(thisSystem.Drawing.Image,int,int)'></a>

## ImageExt.Resize(this Image, int, int) Method

Returns a new image that is a resized version of this one.

```csharp
public static System.Drawing.Bitmap Resize(this System.Drawing.Image image, int width, int height);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ImageExt.Resize(thisSystem.Drawing.Image,int,int).image'></a>

`image` [System.Drawing.Image](https://docs.microsoft.com/en-us/dotnet/api/System.Drawing.Image 'System.Drawing.Image')

<a name='BTD_Mod_Helper.Extensions.ImageExt.Resize(thisSystem.Drawing.Image,int,int).width'></a>

`width` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.ImageExt.Resize(thisSystem.Drawing.Image,int,int).height'></a>

`height` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

#### Returns
[System.Drawing.Bitmap](https://docs.microsoft.com/en-us/dotnet/api/System.Drawing.Bitmap 'System.Drawing.Bitmap')

<a name='BTD_Mod_Helper.Extensions.ImageExt.SaveToPNG(thisUnityEngine.UI.Image,string)'></a>

## ImageExt.SaveToPNG(this Image, string) Method

Saves an image as a PNG files  
Coded in a robust manner that should work for all images, including those with multiple sprites on them being used

```csharp
public static void SaveToPNG(this UnityEngine.UI.Image image, string filePath);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ImageExt.SaveToPNG(thisUnityEngine.UI.Image,string).image'></a>

`image` [UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.Extensions.ImageExt.SaveToPNG(thisUnityEngine.UI.Image,string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Absolute file path on the machine to save the file to

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisUnityEngine.UI.Image,Assets.Scripts.Utils.SpriteReference)'></a>

## ImageExt.SetSprite(this Image, SpriteReference) Method

Set the sprite for this image

```csharp
public static void SetSprite(this UnityEngine.UI.Image image, Assets.Scripts.Utils.SpriteReference spriteReference);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisUnityEngine.UI.Image,Assets.Scripts.Utils.SpriteReference).image'></a>

`image` [UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisUnityEngine.UI.Image,Assets.Scripts.Utils.SpriteReference).spriteReference'></a>

`spriteReference` [Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

Sprite to change image to

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisUnityEngine.UI.Image,string)'></a>

## ImageExt.SetSprite(this Image, string) Method

Set the sprite for this image

```csharp
public static void SetSprite(this UnityEngine.UI.Image image, string guid);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisUnityEngine.UI.Image,string).image'></a>

`image` [UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisUnityEngine.UI.Image,string).guid'></a>

`guid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Sprite to change image to

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisUnityEngine.UI.Image,UnityEngine.Sprite)'></a>

## ImageExt.SetSprite(this Image, Sprite) Method

Set the sprite for this image

```csharp
public static void SetSprite(this UnityEngine.UI.Image image, UnityEngine.Sprite sprite);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisUnityEngine.UI.Image,UnityEngine.Sprite).image'></a>

`image` [UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisUnityEngine.UI.Image,UnityEngine.Sprite).sprite'></a>

`sprite` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

Sprite to change image to

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSpriteFromAtlas(thisUnityEngine.UI.Image,string,string)'></a>

## ImageExt.SetSpriteFromAtlas(this Image, string, string) Method

Sets the sprite of this image to one with the given name in the named sprite atlas

```csharp
public static void SetSpriteFromAtlas(this UnityEngine.UI.Image image, string atlas, string spriteName);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSpriteFromAtlas(thisUnityEngine.UI.Image,string,string).image'></a>

`image` [UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSpriteFromAtlas(thisUnityEngine.UI.Image,string,string).atlas'></a>

`atlas` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSpriteFromAtlas(thisUnityEngine.UI.Image,string,string).spriteName'></a>

`spriteName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')