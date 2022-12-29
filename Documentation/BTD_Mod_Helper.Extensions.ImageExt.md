#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## ImageExt Class

Extensions for Images

```csharp
public static class ImageExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ImageExt
### Methods

<a name='BTD_Mod_Helper.Extensions.ImageExt.LoadSprite(thisImage,SpriteReference)'></a>

## ImageExt.LoadSprite(this Image, SpriteReference) Method

Loads a sprite reference to this image

```csharp
public static void LoadSprite(this Image image, SpriteReference spriteReference);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ImageExt.LoadSprite(thisImage,SpriteReference).image'></a>

`image` [UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.Extensions.ImageExt.LoadSprite(thisImage,SpriteReference).spriteReference'></a>

`spriteReference` [Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Extensions.ImageExt.SaveToPNG(thisImage,string)'></a>

## ImageExt.SaveToPNG(this Image, string) Method

Saves an image as a PNG files  
Coded in a robust manner that should work for all images, including those with multiple sprites on them being used

```csharp
public static void SaveToPNG(this Image image, string filePath);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ImageExt.SaveToPNG(thisImage,string).image'></a>

`image` [UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.Extensions.ImageExt.SaveToPNG(thisImage,string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Absolute file path on the machine to save the file to

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisImage,Sprite)'></a>

## ImageExt.SetSprite(this Image, Sprite) Method

Set the sprite for this image

```csharp
public static void SetSprite(this Image image, Sprite sprite);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisImage,Sprite).image'></a>

`image` [UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisImage,Sprite).sprite'></a>

`sprite` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

Sprite to change image to

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisImage,SpriteReference)'></a>

## ImageExt.SetSprite(this Image, SpriteReference) Method

Set the sprite for this image

```csharp
public static void SetSprite(this Image image, SpriteReference spriteReference);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisImage,SpriteReference).image'></a>

`image` [UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisImage,SpriteReference).spriteReference'></a>

`spriteReference` [Il2CppAssets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Utils.SpriteReference 'Il2CppAssets.Scripts.Utils.SpriteReference')

Sprite to change image to

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisImage,string)'></a>

## ImageExt.SetSprite(this Image, string) Method

Set the sprite for this image

```csharp
public static void SetSprite(this Image image, string guid);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisImage,string).image'></a>

`image` [UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSprite(thisImage,string).guid'></a>

`guid` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Sprite to change image to

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSpriteFromAtlas(thisImage,string,string)'></a>

## ImageExt.SetSpriteFromAtlas(this Image, string, string) Method

Sets the sprite of this image to one with the given name in the named sprite atlas

```csharp
public static void SetSpriteFromAtlas(this Image image, string atlas, string spriteName);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSpriteFromAtlas(thisImage,string,string).image'></a>

`image` [UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSpriteFromAtlas(thisImage,string,string).atlas'></a>

`atlas` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.ImageExt.SetSpriteFromAtlas(thisImage,string,string).spriteName'></a>

`spriteName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')