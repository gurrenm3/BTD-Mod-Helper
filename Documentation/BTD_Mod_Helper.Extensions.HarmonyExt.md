#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Extensions](README.md#BTD_Mod_Helper.Extensions 'BTD_Mod_Helper.Extensions')

## HarmonyExt Class

Extensions for Harmony stuff

```csharp
public static class HarmonyExt
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HarmonyExt
### Methods

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Reflection.MethodInfo)'></a>

## HarmonyExt.PatchPostfix(this Harmony, MethodInfo, MethodInfo) Method

Add a postfix patch

```csharp
public static void PatchPostfix(this HarmonyLib.Harmony harmonyInstance, System.Reflection.MethodInfo methodToPatch, System.Reflection.MethodInfo myPatchMethod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Reflection.MethodInfo).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Reflection.MethodInfo).methodToPatch'></a>

`methodToPatch` [System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Reflection.MethodInfo).myPatchMethod'></a>

`myPatchMethod` [System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Type,string)'></a>

## HarmonyExt.PatchPostfix(this Harmony, MethodInfo, Type, string) Method

Add a postfix patch

```csharp
public static void PatchPostfix(this HarmonyLib.Harmony harmonyInstance, System.Reflection.MethodInfo methodToPatch, System.Type myPatchClass, string myPatchMethod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Type,string).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Type,string).methodToPatch'></a>

`methodToPatch` [System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Type,string).myPatchClass'></a>

`myPatchClass` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Type,string).myPatchMethod'></a>

`myPatchMethod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,int,System.Type,string)'></a>

## HarmonyExt.PatchPostfix(this Harmony, Type, int, Type, string) Method

Add a postfix patch

```csharp
public static void PatchPostfix(this HarmonyLib.Harmony harmonyInstance, System.Type classToPatch, int constructorIndex, System.Type myPatchClass, string myPatchMethod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,int,System.Type,string).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,int,System.Type,string).classToPatch'></a>

`classToPatch` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,int,System.Type,string).constructorIndex'></a>

`constructorIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,int,System.Type,string).myPatchClass'></a>

`myPatchClass` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,int,System.Type,string).myPatchMethod'></a>

`myPatchMethod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,string,int,System.Type,string)'></a>

## HarmonyExt.PatchPostfix(this Harmony, Type, string, int, Type, string) Method

Add a postfix patch

```csharp
public static void PatchPostfix(this HarmonyLib.Harmony harmonyInstance, System.Type classToPatch, string methodToPatch, int methodOverloadIndex, System.Type myPatchClass, string myPatchMethod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,string,int,System.Type,string).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,string,int,System.Type,string).classToPatch'></a>

`classToPatch` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,string,int,System.Type,string).methodToPatch'></a>

`methodToPatch` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,string,int,System.Type,string).methodOverloadIndex'></a>

`methodOverloadIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,string,int,System.Type,string).myPatchClass'></a>

`myPatchClass` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,string,int,System.Type,string).myPatchMethod'></a>

`myPatchMethod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,string,System.Type,string)'></a>

## HarmonyExt.PatchPostfix(this Harmony, Type, string, Type, string) Method

Add a postfix patch

```csharp
public static void PatchPostfix(this HarmonyLib.Harmony harmonyInstance, System.Type classToPatch, string methodToPatch, System.Type myPatchClass, string myPatchMethod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,string,System.Type,string).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,string,System.Type,string).classToPatch'></a>

`classToPatch` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,string,System.Type,string).methodToPatch'></a>

`methodToPatch` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,string,System.Type,string).myPatchClass'></a>

`myPatchClass` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix(thisHarmonyLib.Harmony,System.Type,string,System.Type,string).myPatchMethod'></a>

`myPatchMethod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,int,string)'></a>

## HarmonyExt.PatchPostfix<TClassToPatch,TMyPatchClass>(this Harmony, int, string) Method

Add a postfix patch

```csharp
public static void PatchPostfix<TClassToPatch,TMyPatchClass>(this HarmonyLib.Harmony harmonyInstance, int constructorIndex, string myPatchMethod);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,int,string).TClassToPatch'></a>

`TClassToPatch`

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,int,string).TMyPatchClass'></a>

`TMyPatchClass`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,int,string).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,int,string).constructorIndex'></a>

`constructorIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,int,string).myPatchMethod'></a>

`myPatchMethod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,int,string)'></a>

## HarmonyExt.PatchPostfix<TClassToPatch,TMyPatchClass>(this Harmony, string, int, string) Method

Add a postfix patch

```csharp
public static void PatchPostfix<TClassToPatch,TMyPatchClass>(this HarmonyLib.Harmony harmonyInstance, string methodToPatch, int methodOverloadIndex, string myPatchMethod);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,int,string).TClassToPatch'></a>

`TClassToPatch`

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,int,string).TMyPatchClass'></a>

`TMyPatchClass`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,int,string).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,int,string).methodToPatch'></a>

`methodToPatch` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,int,string).methodOverloadIndex'></a>

`methodOverloadIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,int,string).myPatchMethod'></a>

`myPatchMethod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,string)'></a>

## HarmonyExt.PatchPostfix<TClassToPatch,TMyPatchClass>(this Harmony, string, string) Method

Add a postfix patch

```csharp
public static void PatchPostfix<TClassToPatch,TMyPatchClass>(this HarmonyLib.Harmony harmonyInstance, string methodToPatch, string myPatchMethod);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,string).TClassToPatch'></a>

`TClassToPatch`

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,string).TMyPatchClass'></a>

`TMyPatchClass`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,string).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,string).methodToPatch'></a>

`methodToPatch` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPostfix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,string).myPatchMethod'></a>

`myPatchMethod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Reflection.MethodInfo)'></a>

## HarmonyExt.PatchPrefix(this Harmony, MethodInfo, MethodInfo) Method

Add a prefix patch

```csharp
public static void PatchPrefix(this HarmonyLib.Harmony harmonyInstance, System.Reflection.MethodInfo methodToPatch, System.Reflection.MethodInfo myPatchMethod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Reflection.MethodInfo).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Reflection.MethodInfo).methodToPatch'></a>

`methodToPatch` [System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Reflection.MethodInfo).myPatchMethod'></a>

`myPatchMethod` [System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Type,string)'></a>

## HarmonyExt.PatchPrefix(this Harmony, MethodInfo, Type, string) Method

Add a prefix patch

```csharp
public static void PatchPrefix(this HarmonyLib.Harmony harmonyInstance, System.Reflection.MethodInfo methodToPatch, System.Type myPatchClass, string myPatchMethod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Type,string).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Type,string).methodToPatch'></a>

`methodToPatch` [System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Type,string).myPatchClass'></a>

`myPatchClass` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Reflection.MethodInfo,System.Type,string).myPatchMethod'></a>

`myPatchMethod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,int,System.Type,string)'></a>

## HarmonyExt.PatchPrefix(this Harmony, Type, int, Type, string) Method

Add a prefix patch

```csharp
public static void PatchPrefix(this HarmonyLib.Harmony harmonyInstance, System.Type classToPatch, int constructorIndex, System.Type myPatchClass, string myPatchMethod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,int,System.Type,string).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,int,System.Type,string).classToPatch'></a>

`classToPatch` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,int,System.Type,string).constructorIndex'></a>

`constructorIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,int,System.Type,string).myPatchClass'></a>

`myPatchClass` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,int,System.Type,string).myPatchMethod'></a>

`myPatchMethod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,string,int,System.Type,string)'></a>

## HarmonyExt.PatchPrefix(this Harmony, Type, string, int, Type, string) Method

Add a prefix patch

```csharp
public static void PatchPrefix(this HarmonyLib.Harmony harmonyInstance, System.Type classToPatch, string methodToPatch, int methodOverloadIndex, System.Type myPatchClass, string myPatchMethod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,string,int,System.Type,string).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,string,int,System.Type,string).classToPatch'></a>

`classToPatch` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,string,int,System.Type,string).methodToPatch'></a>

`methodToPatch` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,string,int,System.Type,string).methodOverloadIndex'></a>

`methodOverloadIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,string,int,System.Type,string).myPatchClass'></a>

`myPatchClass` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,string,int,System.Type,string).myPatchMethod'></a>

`myPatchMethod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,string,System.Type,string)'></a>

## HarmonyExt.PatchPrefix(this Harmony, Type, string, Type, string) Method

Add a prefix patch

```csharp
public static void PatchPrefix(this HarmonyLib.Harmony harmonyInstance, System.Type classToPatch, string methodToPatch, System.Type myPatchClass, string myPatchMethod);
```
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,string,System.Type,string).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,string,System.Type,string).classToPatch'></a>

`classToPatch` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,string,System.Type,string).methodToPatch'></a>

`methodToPatch` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,string,System.Type,string).myPatchClass'></a>

`myPatchClass` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix(thisHarmonyLib.Harmony,System.Type,string,System.Type,string).myPatchMethod'></a>

`myPatchMethod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,int,string)'></a>

## HarmonyExt.PatchPrefix<TClassToPatch,TMyPatchClass>(this Harmony, int, string) Method

Add a prefix patch

```csharp
public static void PatchPrefix<TClassToPatch,TMyPatchClass>(this HarmonyLib.Harmony harmonyInstance, int constructorIndex, string myPatchMethod);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,int,string).TClassToPatch'></a>

`TClassToPatch`

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,int,string).TMyPatchClass'></a>

`TMyPatchClass`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,int,string).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,int,string).constructorIndex'></a>

`constructorIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,int,string).myPatchMethod'></a>

`myPatchMethod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,int,string)'></a>

## HarmonyExt.PatchPrefix<TClassToPatch,TMyPatchClass>(this Harmony, string, int, string) Method

Add a prefix patch

```csharp
public static void PatchPrefix<TClassToPatch,TMyPatchClass>(this HarmonyLib.Harmony harmonyInstance, string methodToPatch, int methodOverloadIndex, string myPatchMethod);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,int,string).TClassToPatch'></a>

`TClassToPatch`

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,int,string).TMyPatchClass'></a>

`TMyPatchClass`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,int,string).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,int,string).methodToPatch'></a>

`methodToPatch` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,int,string).methodOverloadIndex'></a>

`methodOverloadIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,int,string).myPatchMethod'></a>

`myPatchMethod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,string)'></a>

## HarmonyExt.PatchPrefix<TClassToPatch,TMyPatchClass>(this Harmony, string, string) Method

Add a prefix patch

```csharp
public static void PatchPrefix<TClassToPatch,TMyPatchClass>(this HarmonyLib.Harmony harmonyInstance, string methodToPatch, string myPatchMethod);
```
#### Type parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,string).TClassToPatch'></a>

`TClassToPatch`

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,string).TMyPatchClass'></a>

`TMyPatchClass`
#### Parameters

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,string).harmonyInstance'></a>

`harmonyInstance` [HarmonyLib.Harmony](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.Harmony 'HarmonyLib.Harmony')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,string).methodToPatch'></a>

`methodToPatch` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Extensions.HarmonyExt.PatchPrefix_TClassToPatch,TMyPatchClass_(thisHarmonyLib.Harmony,string,string).myPatchMethod'></a>

`myPatchMethod` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')