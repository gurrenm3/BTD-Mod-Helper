#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## SupportModelExt Class

Extension methods for support models

```csharp
public static class SupportModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SupportModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.SupportModelExt.ApplyBuffIcon_T_(thisAssets.Scripts.Models.Towers.Behaviors.SupportModel)'></a>

## SupportModelExt.ApplyBuffIcon<T>(this SupportModel) Method

Makes a support model use a particular ModBuffIcon as its display

```csharp
public static Assets.Scripts.Models.Towers.Behaviors.SupportModel ApplyBuffIcon<T>(this Assets.Scripts.Models.Towers.Behaviors.SupportModel supportModel)
    where T : BTD_Mod_Helper.Api.Display.ModBuffIcon;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SupportModelExt.ApplyBuffIcon_T_(thisAssets.Scripts.Models.Towers.Behaviors.SupportModel).T'></a>

`T`

The ModBuffIcon type
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SupportModelExt.ApplyBuffIcon_T_(thisAssets.Scripts.Models.Towers.Behaviors.SupportModel).supportModel'></a>

`supportModel` [Assets.Scripts.Models.Towers.Behaviors.SupportModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.SupportModel 'Assets.Scripts.Models.Towers.Behaviors.SupportModel')

The support model to apply to

#### Returns
[Assets.Scripts.Models.Towers.Behaviors.SupportModel](https://docs.microsoft.com/en-us/dotnet/api/Assets.Scripts.Models.Towers.Behaviors.SupportModel 'Assets.Scripts.Models.Towers.Behaviors.SupportModel')