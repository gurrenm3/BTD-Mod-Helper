#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Commands](README.md#BTD_Mod_Helper.Api.Commands 'BTD_Mod_Helper.Api.Commands')

## TestCommand Class

Root command where test related actions are

```csharp
public class TestCommand : BTD_Mod_Helper.Api.Commands.ModCommand
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; [ModCommand](BTD_Mod_Helper.Api.Commands.ModCommand.md 'BTD_Mod_Helper.Api.Commands.ModCommand') &#129106; TestCommand
### Properties

<a name='BTD_Mod_Helper.Api.Commands.TestCommand.Command'></a>

## TestCommand.Command Property

The string name of this command

```csharp
public override string Command { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Commands.TestCommand.Help'></a>

## TestCommand.Help Property

Short text description of this command

```csharp
public override string Help { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='BTD_Mod_Helper.Api.Commands.TestCommand.Execute(string)'></a>

## TestCommand.Execute(string) Method

Runs this command

```csharp
public override bool Execute(ref string resultText);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Commands.TestCommand.Execute(string).resultText'></a>

`resultText` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether this command successfully executed