#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## SupportModelExt Class

Extension methods for support models

```csharp
public static class SupportModelExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; SupportModelExt
### Methods

<a name='BTD_Mod_Helper.Extensions.SupportModelExt.ApplyBuffIcon_T_(thisSupportModel)'></a>

## SupportModelExt.ApplyBuffIcon<T>(this SupportModel) Method

Makes a support model use a particular ModBuffIcon as its display

```csharp
public static SupportModel ApplyBuffIcon<T>(this SupportModel supportModel)
    where T : BTD_Mod_Helper.Api.Display.ModBuffIcon, new();
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.SupportModelExt.ApplyBuffIcon_T_(thisSupportModel).T'></a>

`T`

The ModBuffIcon type
#### Parameters

<a name='BTD_Mod_Helper.Extensions.SupportModelExt.ApplyBuffIcon_T_(thisSupportModel).supportModel'></a>

`supportModel` [Il2CppAssets.Scripts.Models.Towers.Behaviors.SupportModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.SupportModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.SupportModel')

The support model to apply to

#### Returns
[Il2CppAssets.Scripts.Models.Towers.Behaviors.SupportModel](https://docs.microsoft.com/en-us/dotnet/api/Il2CppAssets.Scripts.Models.Towers.Behaviors.SupportModel 'Il2CppAssets.Scripts.Models.Towers.Behaviors.SupportModel')