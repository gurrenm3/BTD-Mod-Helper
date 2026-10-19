#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api](README.md#BTD_Mod_Helper.Api 'BTD_Mod_Helper.Api')

## ModSaveData Class

Mod Content class to easily save and load data that should persist between sessions. All saved data are strings.

```csharp
public abstract class ModSaveData : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModSaveData
### Methods

<a name='BTD_Mod_Helper.Api.ModSaveData.Load(string)'></a>

## ModSaveData.Load(string) Method

Loads this ModSaveData from the provided encoded string.

```csharp
public abstract void Load(string data);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.ModSaveData.Load(string).data'></a>

`data` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The encoded save data.

<a name='BTD_Mod_Helper.Api.ModSaveData.Register()'></a>

## ModSaveData.Register() Method

<inheritdoc/>

```csharp
public override void Register();
```

<a name='BTD_Mod_Helper.Api.ModSaveData.Save()'></a>

## ModSaveData.Save() Method

Saves this ModSaveData using the returned encoded string.

```csharp
public abstract string Save();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The encoded save data.