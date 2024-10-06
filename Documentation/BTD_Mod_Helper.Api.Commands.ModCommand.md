#### [BloonsTD6 Mod Helper](README.md 'README')
### [BTD_Mod_Helper.Api.Commands](README.md#BTD_Mod_Helper.Api.Commands 'BTD_Mod_Helper.Api.Commands')

## ModCommand Class

```csharp
public abstract class ModCommand : BTD_Mod_Helper.Api.ModContent
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [ModContent](BTD_Mod_Helper.Api.ModContent.md 'BTD_Mod_Helper.Api.ModContent') &#129106; ModCommand

Derived  
&#8627; [ExportCommand](BTD_Mod_Helper.Api.Commands.ExportCommand.md 'BTD_Mod_Helper.Api.Commands.ExportCommand')  
&#8627; [ModCommand&lt;T&gt;](BTD_Mod_Helper.Api.Commands.ModCommand_T_.md 'BTD_Mod_Helper.Api.Commands.ModCommand<T>')  
&#8627; [TestCommand](BTD_Mod_Helper.Api.Commands.TestCommand.md 'BTD_Mod_Helper.Api.Commands.TestCommand')
### Fields

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.SubCommands'></a>

## ModCommand.SubCommands Field

List of Sub-commands that this command has

```csharp
public readonly Dictionary<string,ModCommand> SubCommands;
```

#### Field Value
[System.Collections.Generic.Dictionary&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')[ModCommand](BTD_Mod_Helper.Api.Commands.ModCommand.md 'BTD_Mod_Helper.Api.Commands.ModCommand')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'System.Collections.Generic.Dictionary`2')
### Properties

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.Command'></a>

## ModCommand.Command Property

The string name of this command

```csharp
public abstract string Command { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.Help'></a>

## ModCommand.Help Property

Short text description of this command

```csharp
public abstract string Help { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.IsAvailable'></a>

## ModCommand.IsAvailable Property

Whether the command is available to users

```csharp
public virtual bool IsAvailable { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.Options'></a>

## ModCommand.Options Property

Optional arguments for this command

```csharp
public System.Collections.Generic.IEnumerable<CommandLine.OptionAttribute> Options { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[CommandLine.OptionAttribute](https://docs.microsoft.com/en-us/dotnet/api/CommandLine.OptionAttribute 'CommandLine.OptionAttribute')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.ParentCommand'></a>

## ModCommand.ParentCommand Property

Other ModCommand that this is nested under, or null if a root command

```csharp
public virtual BTD_Mod_Helper.Api.Commands.ModCommand ParentCommand { get; }
```

#### Property Value
[ModCommand](BTD_Mod_Helper.Api.Commands.ModCommand.md 'BTD_Mod_Helper.Api.Commands.ModCommand')

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.SuggestionLine'></a>

## ModCommand.SuggestionLine Property

Line of text that appears as a suggestion

```csharp
public string SuggestionLine { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.Values'></a>

## ModCommand.Values Property

Positional values for this command

```csharp
public System.Collections.Generic.IEnumerable<CommandLine.ValueAttribute> Values { get; }
```

#### Property Value
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[CommandLine.ValueAttribute](https://docs.microsoft.com/en-us/dotnet/api/CommandLine.ValueAttribute 'CommandLine.ValueAttribute')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')
### Methods

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.CloseConsole()'></a>

## ModCommand.CloseConsole() Method

Closes the command console

```csharp
protected static void CloseConsole();
```

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.Execute(string)'></a>

## ModCommand.Execute(string) Method

Runs this command

```csharp
public abstract bool Execute(ref string resultText);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.Execute(string).resultText'></a>

`resultText` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether this command successfully executed

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.ExplainSubcommands(string)'></a>

## ModCommand.ExplainSubcommands(string) Method

Fails the command and displays which subbcommands are available to the user

```csharp
protected bool ExplainSubcommands(out string resultText);
```
#### Parameters

<a name='BTD_Mod_Helper.Api.Commands.ModCommand.ExplainSubcommands(string).resultText'></a>

`resultText` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')