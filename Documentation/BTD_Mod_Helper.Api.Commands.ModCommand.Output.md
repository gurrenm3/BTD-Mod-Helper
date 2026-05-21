#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Commands](README.md#BTD_Mod_Helper.Api.Commands 'BTD_Mod_Helper.Api.Commands').[ModCommand](BTD_Mod_Helper.Api.Commands.ModCommand.md 'BTD_Mod_Helper.Api.Commands.ModCommand')

## ModCommand.Output Class

Class that represents the output of a ModCommand execution. This gets passed by reference between Coroutines

```csharp
public class ModCommand.Output
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Output
### Fields

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.Output.exception'></a>

## ModCommand.Output.exception Field

Exception that caused the command to fail, if any

```csharp
public Exception exception;
```

#### Field Value
[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.Output.resultText'></a>

## ModCommand.Output.resultText Field

Custom result text to display to the user, if not null

```csharp
public string resultText;
```

#### Field Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.Output.success'></a>

## ModCommand.Output.success Field

Whether the command has succeeded. True by default; users will need to actively specify a failure.

```csharp
public bool success;
```

#### Field Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')