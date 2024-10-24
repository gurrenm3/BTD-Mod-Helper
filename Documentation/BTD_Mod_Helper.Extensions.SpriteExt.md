#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## SpriteExt Class

Extensions for Sprites

```csharp
public static class SpriteExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SpriteExt
### Methods

<a name='BTD_Mod_Helper.Extensions.SpriteExt.SetTexture(thisSprite,Texture2D)'></a>

## SpriteExt.SetTexture(this Sprite, Texture2D) Method

Set this Sprite's texture

```csharp
public static void SetTexture(this Sprite sprite, Texture2D newTexture);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SpriteExt.SetTexture(thisSprite,Texture2D).sprite'></a>

`sprite` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

<a name='BTD_Mod_Helper.Extensions.SpriteExt.SetTexture(thisSprite,Texture2D).newTexture'></a>

`newTexture` [UnityEngine.Texture2D](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Texture2D 'UnityEngine.Texture2D')

<a name='BTD_Mod_Helper.Extensions.SpriteExt.TrySaveToPNG(thisSprite,string)'></a>

## SpriteExt.TrySaveToPNG(this Sprite, string) Method

Attempts to save a Sprite to a PNG at the given filePath, even if it isn't marked as readable

```csharp
public static bool TrySaveToPNG(this Sprite sprite, string filePath);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SpriteExt.TrySaveToPNG(thisSprite,string).sprite'></a>

`sprite` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

<a name='BTD_Mod_Helper.Extensions.SpriteExt.TrySaveToPNG(thisSprite,string).filePath'></a>

`filePath` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')