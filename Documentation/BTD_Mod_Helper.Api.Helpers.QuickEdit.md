#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Helpers](README.md#BTD_Mod_Helper.Api.Helpers 'BTD_Mod_Helper.Api.Helpers')

## QuickEdit Class

Utility for allowing the user to quickly edit some input in an external program

```csharp
public static class QuickEdit
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; QuickEdit
### Methods

<a name='BTD_Mod_Helper.Api.Helpers.QuickEdit.EditText(string,string,bool)'></a>

## QuickEdit.EditText(string, string, bool) Method

Prompts the user to edit some text in their selected external program

```csharp
public static string EditText(string text, string fileName, bool deleteAfter=true);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Helpers.QuickEdit.EditText(string,string,bool).text'></a>

`text` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Original text

<a name='BTD_Mod_Helper.Api.Helpers.QuickEdit.EditText(string,string,bool).fileName'></a>

`fileName` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Name for temporary file

<a name='BTD_Mod_Helper.Api.Helpers.QuickEdit.EditText(string,string,bool).deleteAfter'></a>

`deleteAfter` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether to try deleting the file when edits conclude

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
The edited text