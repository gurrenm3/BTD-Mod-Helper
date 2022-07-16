#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## MoreAccessTools Class

Further methods along the lines of Harmony's [HarmonyLib.AccessTools](https://docs.microsoft.com/en-us/dotnet/api/HarmonyLib.AccessTools 'HarmonyLib.AccessTools')

```csharp
public static class MoreAccessTools
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; MoreAccessTools
### Methods

<a name='BTD_Mod_Helper.Api.MoreAccessTools.SafeGetNestedClassMethod(System.Type,string,string,int)'></a>

## MoreAccessTools.SafeGetNestedClassMethod(Type, string, string, int) Method

Safely gets the MethodInfo for a method within a nested class. This is recommended to use because over  
directly targeting it with typeof and nameof because the nested class names can change randomly.

```csharp
public static System.Reflection.MethodInfo SafeGetNestedClassMethod(System.Type outerType, string nestedTypeName, string methodName, int index=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.MoreAccessTools.SafeGetNestedClassMethod(System.Type,string,string,int).outerType'></a>

`outerType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

The outer type whose name won't change

<a name='BTD_Mod_Helper.Api.MoreAccessTools.SafeGetNestedClassMethod(System.Type,string,string,int).nestedTypeName'></a>

`nestedTypeName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The name of nested type, not including the _s

<a name='BTD_Mod_Helper.Api.MoreAccessTools.SafeGetNestedClassMethod(System.Type,string,string,int).methodName'></a>

`methodName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The desired method name within the nested type

<a name='BTD_Mod_Helper.Api.MoreAccessTools.SafeGetNestedClassMethod(System.Type,string,string,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

If multiple nested classes share a name portion, use the one at this index, default 0

#### Returns
[System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo')  
The MethodInfo, or null alongside a console warning if one couldn't be found

<a name='BTD_Mod_Helper.Api.MoreAccessTools.TryGetNestedClassMethod(System.Type,string,string,System.Reflection.MethodInfo,int)'></a>

## MoreAccessTools.TryGetNestedClassMethod(Type, string, string, MethodInfo, int) Method

Safely gets the MethodInfo for a method within a nested class. This is recommended to use because over  
directly targeting it with typeof and nameof because the nested class names can change randomly.

```csharp
public static bool TryGetNestedClassMethod(System.Type outerType, string nestedClassName, string methodName, out System.Reflection.MethodInfo method, int index=0);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.MoreAccessTools.TryGetNestedClassMethod(System.Type,string,string,System.Reflection.MethodInfo,int).outerType'></a>

`outerType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

The outer type whose name won't change

<a name='BTD_Mod_Helper.Api.MoreAccessTools.TryGetNestedClassMethod(System.Type,string,string,System.Reflection.MethodInfo,int).nestedClassName'></a>

`nestedClassName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.MoreAccessTools.TryGetNestedClassMethod(System.Type,string,string,System.Reflection.MethodInfo,int).methodName'></a>

`methodName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The desired method name within the nested type

<a name='BTD_Mod_Helper.Api.MoreAccessTools.TryGetNestedClassMethod(System.Type,string,string,System.Reflection.MethodInfo,int).method'></a>

`method` [System.Reflection.MethodInfo](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.MethodInfo 'System.Reflection.MethodInfo')

<a name='BTD_Mod_Helper.Api.MoreAccessTools.TryGetNestedClassMethod(System.Type,string,string,System.Reflection.MethodInfo,int).index'></a>

`index` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

If multiple nested classes share a name portion, use the one at this index, default 0

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
The MethodInfo, or null alongside a console warning if one couldn't be found