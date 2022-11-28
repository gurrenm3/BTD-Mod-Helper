#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Display](README.md#BTD_Mod_Helper.Api.Display 'BTD_Mod_Helper.Api.Display')

## ModBuffIcon Class

Class for adding a new buff icon that can be displayed for towers

```csharp
public abstract class ModBuffIcon : BTD_Mod_Helper.Api.NamedModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [NamedModContent](BTD_Mod_Helper.Api.NamedModContent.md 'BTD_Mod_Helper.Api.NamedModContent') &#129106; ModBuffIcon
### Properties

<a name='BTD_Mod_Helper.Api.Display.ModBuffIcon.Description'></a>

## ModBuffIcon.Description Property

The in game description of this

```csharp
public sealed override string Description { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBuffIcon.DisplayName'></a>

## ModBuffIcon.DisplayName Property

The name that will be actually displayed for this in game

```csharp
public sealed override string DisplayName { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBuffIcon.DisplayNamePlural'></a>

## ModBuffIcon.DisplayNamePlural Property

The name that will actually be display when referring to multiple of these

```csharp
public sealed override string DisplayNamePlural { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBuffIcon.GlobalRange'></a>

## ModBuffIcon.GlobalRange Property

Whether the buff affects every tower on screen

```csharp
public virtual bool GlobalRange { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Display.ModBuffIcon.Icon'></a>

## ModBuffIcon.Icon Property

The Icon for to display for the buff  
<br/>  
(Name of .png or .jpg, not including file extension)

```csharp
public virtual string Icon { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Display.ModBuffIcon.IconReference'></a>

## ModBuffIcon.IconReference Property

If you're not going to use a custom .png for your Icon, use this to directly control its SpriteReference

```csharp
public virtual Assets.Scripts.Utils.SpriteReference IconReference { get; }
```

#### Property Value
[Assets.Scripts.Utils.SpriteReference](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Utils.SpriteReference 'Assets.Scripts.Utils.SpriteReference')

<a name='BTD_Mod_Helper.Api.Display.ModBuffIcon.MaxStackSize'></a>

## ModBuffIcon.MaxStackSize Property

If greater than 0, the total number of stacks that a tower can have at one time

```csharp
public virtual int MaxStackSize { get; }
```

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Api.Display.ModBuffIcon.OnlyShowBuffIfMutated'></a>

## ModBuffIcon.OnlyShowBuffIfMutated Property

Controls the OnlyShowBuffIfMutated property on the model

```csharp
public virtual bool OnlyShowBuffIfMutated { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='BTD_Mod_Helper.Api.Display.ModBuffIcon.ApplyTo(Assets.Scripts.Models.Towers.Behaviors.SupportModel)'></a>

## ModBuffIcon.ApplyTo(SupportModel) Method

Makes a support model use this as its buff indicator

```csharp
public void ApplyTo(Assets.Scripts.Models.Towers.Behaviors.SupportModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModBuffIcon.ApplyTo(Assets.Scripts.Models.Towers.Behaviors.SupportModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Behaviors.SupportModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.SupportModel 'Assets.Scripts.Models.Towers.Behaviors.SupportModel')

The support model to apply to

<a name='BTD_Mod_Helper.Api.Display.ModBuffIcon.ApplyTo(Assets.Scripts.Models.Towers.Behaviors.TowerBehaviorBuffModel)'></a>

## ModBuffIcon.ApplyTo(TowerBehaviorBuffModel) Method

Makes a support model use this as its buff indicator

```csharp
public void ApplyTo(Assets.Scripts.Models.Towers.Behaviors.TowerBehaviorBuffModel model);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Display.ModBuffIcon.ApplyTo(Assets.Scripts.Models.Towers.Behaviors.TowerBehaviorBuffModel).model'></a>

`model` [Assets.Scripts.Models.Towers.Behaviors.TowerBehaviorBuffModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.TowerBehaviorBuffModel 'Assets.Scripts.Models.Towers.Behaviors.TowerBehaviorBuffModel')

The support model to apply to