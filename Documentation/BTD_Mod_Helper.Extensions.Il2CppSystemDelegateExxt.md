#### [BloonsTD6 Mod Helper](index.md 'index')
### [BTD_Mod_Helper.Extensions](index.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## Il2CppSystemDelegateExxt Class

Extensions for Il2cpp delegates

```csharp
public static class Il2CppSystemDelegateExxt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Il2CppSystemDelegateExxt
### Methods

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDelegateExxt.Duplicate_T_(thisIl2CppSystem.Delegate)'></a>

## Il2CppSystemDelegateExxt.Duplicate<T>(this Delegate) Method

(Cross-Game compatible) Create a new and seperate copy of this object. Same as using:  .Clone().Cast();

```csharp
public static T Duplicate<T>(this Il2CppSystem.Delegate del)
    where T : UnhollowerBaseLib.Il2CppObjectBase;
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDelegateExxt.Duplicate_T_(thisIl2CppSystem.Delegate).T'></a>

`T`

Type of object you want to cast to when duplicating. Done automatically
#### Parameters

<a name='BTD_Mod_Helper.Extensions.Il2CppSystemDelegateExxt.Duplicate_T_(thisIl2CppSystem.Delegate).del'></a>

`del` [Il2CppSystem.Delegate](https://docs.microsoft.com/en-us/dotnet/api/Il2CppSystem.Delegate 'Il2CppSystem.Delegate')

#### Returns
[T](BTD_Mod_Helper.Extensions.Il2CppSystemDelegateExxt.md#BTD_Mod_Helper.Extensions.Il2CppSystemDelegateExxt.Duplicate_T_(thisIl2CppSystem.Delegate).T 'BTD_Mod_Helper.Extensions.Il2CppSystemDelegateExxt.Duplicate<T>(this Il2CppSystem.Delegate).T')