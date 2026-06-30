#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Components](README.md#BTD_Mod_Helper.Api.Components 'BTD_Mod_Helper.Api.Components')

## ModHelperImage Class

ModHelperComponent for an image element

```csharp
public class ModHelperImage : BTD_Mod_Helper.Api.Components.ModHelperComponent
```

Inheritance [UnityEngine.MonoBehaviour](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.MonoBehaviour 'UnityEngine.MonoBehaviour') &#129106; [ModHelperComponent](BTD_Mod_Helper.Api.Components.ModHelperComponent.md 'BTD_Mod_Helper.Api.Components.ModHelperComponent') &#129106; ModHelperImage
### Properties

<a name='BTD_Mod_Helper.Api.Components.ModHelperImage.Image'></a>

## ModHelperImage.Image Property

The Image being displayed

```csharp
public Image Image { get; }
```

#### Property Value
[UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')
### Methods

<a name='BTD_Mod_Helper.Api.Components.ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,Sprite)'></a>

## ModHelperImage.Create(Info, Sprite) Method

Creates a new ModHelperImage

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperImage Create(BTD_Mod_Helper.Api.Components.Info info, Sprite sprite);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,Sprite).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,Sprite).sprite'></a>

`sprite` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

The sprite to display

#### Returns
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')  
The created ModHelperImage

<a name='BTD_Mod_Helper.Api.Components.ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,string)'></a>

## ModHelperImage.Create(Info, string) Method

Creates a new ModHelperImage

```csharp
public static BTD_Mod_Helper.Api.Components.ModHelperImage Create(BTD_Mod_Helper.Api.Components.Info info, string sprite);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,string).info'></a>

`info` [Info](BTD_Mod_Helper.Api.Components.Info.md 'BTD_Mod_Helper.Api.Components.Info')

The name/position/size info

<a name='BTD_Mod_Helper.Api.Components.ModHelperImage.Create(BTD_Mod_Helper.Api.Components.Info,string).sprite'></a>

`sprite` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The sprite to display

#### Returns
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')  
The created ModHelperImage

<a name='BTD_Mod_Helper.Api.Components.ModHelperImage.Init(Sprite)'></a>

## ModHelperImage.Init(Sprite) Method

Initializes this ModHelperImage

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperImage Init(Sprite sprite);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperImage.Init(Sprite).sprite'></a>

`sprite` [UnityEngine.Sprite](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.Sprite 'UnityEngine.Sprite')

The sprite to display

#### Returns
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')  
the ModHelperImage

<a name='BTD_Mod_Helper.Api.Components.ModHelperImage.Init(string)'></a>

## ModHelperImage.Init(string) Method

Initializes this ModHelperImage

```csharp
public BTD_Mod_Helper.Api.Components.ModHelperImage Init(string sprite);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperImage.Init(string).sprite'></a>

`sprite` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The sprite to display

#### Returns
[ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')  
the ModHelperImage
### Operators

<a name='BTD_Mod_Helper.Api.Components.ModHelperImage.op_ImplicitImage(BTD_Mod_Helper.Api.Components.ModHelperImage)'></a>

## ModHelperImage.implicit operator Image(ModHelperImage) Operator

Implicitly get the Image

```csharp
public static Image implicit operator Image(BTD_Mod_Helper.Api.Components.ModHelperImage component);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Components.ModHelperImage.op_ImplicitImage(BTD_Mod_Helper.Api.Components.ModHelperImage).component'></a>

`component` [ModHelperImage](BTD_Mod_Helper.Api.Components.ModHelperImage.md 'BTD_Mod_Helper.Api.Components.ModHelperImage')

#### Returns
[UnityEngine.UI.Image](https://docs.microsoft.com/en-us/dotnet/api/UnityEngine.UI.Image 'UnityEngine.UI.Image')