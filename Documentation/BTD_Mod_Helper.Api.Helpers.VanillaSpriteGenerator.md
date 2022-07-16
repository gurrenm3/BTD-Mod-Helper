#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Api.Helpers](index.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## VanillaSpriteGenerator Class

```csharp
internal class VanillaSpriteGenerator
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; VanillaSpriteGenerator
### Methods

<a name='BTD_Mod_Helper.Api.Helpers.VanillaSpriteGenerator.GenerateVanillaSprites(string,string)'></a>

## VanillaSpriteGenerator.GenerateVanillaSprites(string, string) Method

Generate the VanillaSprites.cs file  
<br/>  
To get the necessary files, from the "...\BloonsTD6\BloonsTD6_Data\StreamingAssets\aa\StandaloneWindows64\Full\" folder, choose:  
  
in Asset Studio. Then, select all assets of type Sprite, and in the menu do Export -> Dump -> Selected assets

```csharp
internal static void GenerateVanillaSprites(string vanillaSpritesCs, string folder);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.VanillaSpriteGenerator.GenerateVanillaSprites(string,string).vanillaSpritesCs'></a>

`vanillaSpritesCs` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Helpers.VanillaSpriteGenerator.GenerateVanillaSprites(string,string).folder'></a>

`folder` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')